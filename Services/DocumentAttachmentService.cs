using Microsoft.EntityFrameworkCore;
using OperationsFlow.Data;
using OperationsFlow.Models;
using OperationsFlow.Services.Storage;

namespace OperationsFlow.Services;

public class DocumentAttachmentService
{
    private readonly OperationsFlowDbContext db;
    private readonly IFileStorageService fileStorageService;
    private readonly ActivityLogService activityLogService;

    public DocumentAttachmentService(
        OperationsFlowDbContext db,
        IFileStorageService fileStorageService,
        ActivityLogService activityLogService)
    {
        this.db = db;
        this.fileStorageService = fileStorageService;
        this.activityLogService = activityLogService;
    }

    public async Task<List<DocumentAttachment>> GetAllActiveAsync()
    {
        await EnsureDocumentAttachmentsTableAsync();

        return await db.DocumentAttachments
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.UploadedDate)
            .ThenByDescending(x => x.Id)
            .ToListAsync();
    }

    public async Task<List<DocumentAttachment>> GetForRecordAsync(string moduleName, int recordId)
    {
        await EnsureDocumentAttachmentsTableAsync();

        return await db.DocumentAttachments
            .AsNoTracking()
            .Where(x =>
                !x.IsDeleted &&
                x.ModuleName == moduleName &&
                x.RecordId == recordId)
            .OrderByDescending(x => x.UploadedDate)
            .ThenByDescending(x => x.Id)
            .ToListAsync();
    }

    public async Task<DocumentAttachment?> GetByIdAsync(int id)
    {
        await EnsureDocumentAttachmentsTableAsync();

        return await db.DocumentAttachments
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<DocumentAttachmentCreateResult> CreateFromStorageResultAsync(
        FileStorageSaveResult storageResult,
        string moduleName,
        int? recordId,
        string recordReference,
        string uploadedBy,
        string notes,
        bool isEvidence,
        bool isControlledDocument)
    {
        await EnsureDocumentAttachmentsTableAsync();

        if (!storageResult.Success)
        {
            return DocumentAttachmentCreateResult.Failed(storageResult.ErrorMessage);
        }

        var attachment = new DocumentAttachment
        {
            ModuleName = string.IsNullOrWhiteSpace(moduleName) ? "General" : moduleName,
            RecordId = recordId,
            RecordReference = recordReference ?? "",
            OriginalFileName = storageResult.OriginalFileName,
            StoredFileName = storageResult.StoredFileName,
            StoredRelativePath = storageResult.StoredRelativePath,
            PublicUrl = storageResult.PublicUrl,
            ContentType = storageResult.ContentType,
            FileSizeBytes = storageResult.FileSizeBytes,
            StorageProvider = storageResult.Provider,
            UploadedBy = string.IsNullOrWhiteSpace(uploadedBy) ? "Demo User" : uploadedBy,
            UploadedDate = DateTime.Now,
            Notes = notes ?? "",
            Status = "Active",
            IsEvidence = isEvidence,
            IsControlledDocument = isControlledDocument,
            IsDeleted = false
        };

        db.DocumentAttachments.Add(attachment);
        await db.SaveChangesAsync();

        await activityLogService.LogAsync(
            moduleName: "Document Library",
            recordId: attachment.Id,
            recordReference: attachment.OriginalFileName,
            actionType: "Created",
            description: $"Uploaded document attachment '{attachment.OriginalFileName}' to {attachment.ModuleName} / {attachment.DisplayRecordReference} using {attachment.StorageProvider} storage.");

        return DocumentAttachmentCreateResult.Created(attachment);
    }

    public async Task<bool> SoftDeleteAsync(int id, string deletedBy)
    {
        await EnsureDocumentAttachmentsTableAsync();

        var attachment = await db.DocumentAttachments
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

        if (attachment == null)
        {
            return false;
        }

        attachment.IsDeleted = true;
        attachment.DeletedDate = DateTime.Now;
        attachment.DeletedBy = string.IsNullOrWhiteSpace(deletedBy) ? "Demo User" : deletedBy;
        attachment.Status = "Deleted";

        await db.SaveChangesAsync();

        await activityLogService.LogAsync(
            moduleName: "Document Library",
            recordId: attachment.Id,
            recordReference: attachment.OriginalFileName,
            actionType: "Updated",
            description: $"Soft-deleted document attachment '{attachment.OriginalFileName}'.");

        return true;
    }

    public async Task<Stream?> OpenReadAsync(DocumentAttachment attachment)
    {
        return await fileStorageService.OpenReadAsync(attachment.StoredRelativePath);
    }

    public string GetPublicUrl(DocumentAttachment attachment)
    {
        if (!string.IsNullOrWhiteSpace(attachment.PublicUrl))
        {
            return attachment.PublicUrl;
        }

        return fileStorageService.GetPublicUrl(attachment.StoredRelativePath);
    }

    private async Task EnsureDocumentAttachmentsTableAsync()
    {
        await db.Database.ExecuteSqlRawAsync("""
            CREATE TABLE IF NOT EXISTS "DocumentAttachments" (
                "Id" INTEGER NOT NULL CONSTRAINT "PK_DocumentAttachments" PRIMARY KEY AUTOINCREMENT,
                "ModuleName" TEXT NOT NULL,
                "RecordId" INTEGER NULL,
                "RecordReference" TEXT NOT NULL,
                "OriginalFileName" TEXT NOT NULL,
                "StoredFileName" TEXT NOT NULL,
                "StoredRelativePath" TEXT NOT NULL,
                "PublicUrl" TEXT NOT NULL,
                "ContentType" TEXT NOT NULL,
                "FileSizeBytes" INTEGER NOT NULL,
                "StorageProvider" TEXT NOT NULL,
                "UploadedBy" TEXT NOT NULL,
                "UploadedDate" TEXT NOT NULL,
                "Notes" TEXT NOT NULL,
                "Status" TEXT NOT NULL,
                "IsEvidence" INTEGER NOT NULL,
                "IsControlledDocument" INTEGER NOT NULL,
                "IsDeleted" INTEGER NOT NULL,
                "DeletedDate" TEXT NULL,
                "DeletedBy" TEXT NOT NULL
            );
        """);

        await db.Database.ExecuteSqlRawAsync("""
            CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_ModuleName"
            ON "DocumentAttachments" ("ModuleName");
        """);

        await db.Database.ExecuteSqlRawAsync("""
            CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_RecordId"
            ON "DocumentAttachments" ("RecordId");
        """);

        await db.Database.ExecuteSqlRawAsync("""
            CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_ModuleName_RecordId"
            ON "DocumentAttachments" ("ModuleName", "RecordId");
        """);

        await db.Database.ExecuteSqlRawAsync("""
            CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_UploadedDate"
            ON "DocumentAttachments" ("UploadedDate");
        """);

        await db.Database.ExecuteSqlRawAsync("""
            CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_IsDeleted"
            ON "DocumentAttachments" ("IsDeleted");
        """);
    }
}

public class DocumentAttachmentCreateResult
{
    public bool IsSuccessful { get; set; }

    public DocumentAttachment? Attachment { get; set; }

    public string ErrorMessage { get; set; } = "";

    public static DocumentAttachmentCreateResult Created(DocumentAttachment attachment)
    {
        return new DocumentAttachmentCreateResult
        {
            IsSuccessful = true,
            Attachment = attachment
        };
    }

    public static DocumentAttachmentCreateResult Failed(string errorMessage)
    {
        return new DocumentAttachmentCreateResult
        {
            IsSuccessful = false,
            ErrorMessage = errorMessage
        };
    }
}