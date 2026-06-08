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
    private readonly DatabaseSchemaService databaseSchemaService;

    public DocumentAttachmentService(
        OperationsFlowDbContext db,
        IFileStorageService fileStorageService,
        ActivityLogService activityLogService,
        DatabaseSchemaService databaseSchemaService)
    {
        this.db = db;
        this.fileStorageService = fileStorageService;
        this.activityLogService = activityLogService;
        this.databaseSchemaService = databaseSchemaService;
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
            .Where(x => !x.IsDeleted && x.ModuleName == moduleName && x.RecordId == recordId)
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

        var cleanUploadedBy = string.IsNullOrWhiteSpace(uploadedBy)
            ? "Unknown User"
            : uploadedBy;

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
            UploadedBy = cleanUploadedBy,
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
            description: $"Uploaded document attachment '{attachment.OriginalFileName}' to {attachment.ModuleName} / {attachment.DisplayRecordReference} using {attachment.StorageProvider} storage.",
            createdBy: attachment.UploadedBy);

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

        var cleanDeletedBy = string.IsNullOrWhiteSpace(deletedBy)
            ? "Unknown User"
            : deletedBy;

        var storageDeleted = await fileStorageService.DeleteAsync(attachment.StoredRelativePath);

        if (!storageDeleted)
        {
            await activityLogService.LogAsync(
                moduleName: "Document Library",
                recordId: attachment.Id,
                recordReference: attachment.OriginalFileName,
                actionType: "Delete Failed",
                description: $"Could not delete physical document attachment '{attachment.OriginalFileName}' from {attachment.StorageProvider} storage.",
                createdBy: cleanDeletedBy);

            return false;
        }

        attachment.IsDeleted = true;
        attachment.DeletedDate = DateTime.Now;
        attachment.DeletedBy = cleanDeletedBy;
        attachment.Status = "Deleted";

        await db.SaveChangesAsync();

        await activityLogService.LogAsync(
            moduleName: "Document Library",
            recordId: attachment.Id,
            recordReference: attachment.OriginalFileName,
            actionType: "Deleted",
            description: $"Deleted document attachment '{attachment.OriginalFileName}' from {attachment.ModuleName} / {attachment.DisplayRecordReference} and removed the physical file from {attachment.StorageProvider} storage.",
            createdBy: cleanDeletedBy);

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
        await databaseSchemaService.EnsureDocumentAttachmentsTableAsync();
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