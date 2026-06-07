using Microsoft.EntityFrameworkCore;
using OperationsFlow.Data;

namespace OperationsFlow.Services;

public class DatabaseSchemaService
{
    private readonly OperationsFlowDbContext _db;

    public DatabaseSchemaService(OperationsFlowDbContext db)
    {
        _db = db;
    }

    public async Task EnsureDocumentAttachmentsTableAsync()
    {
        if (IsSqlServer())
        {
            await EnsureDocumentAttachmentsTableForSqlServerAsync();
            return;
        }

        await EnsureDocumentAttachmentsTableForSqliteAsync();
    }

    private bool IsSqlServer()
    {
        return _db.Database.ProviderName?.Contains("SqlServer", StringComparison.OrdinalIgnoreCase) == true;
    }

    private async Task EnsureDocumentAttachmentsTableForSqlServerAsync()
    {
        await _db.Database.ExecuteSqlRawAsync("""
            IF OBJECT_ID(N'DocumentAttachments', N'U') IS NULL
            BEGIN
                CREATE TABLE [DocumentAttachments] (
                    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_DocumentAttachments] PRIMARY KEY,
                    [ModuleName] NVARCHAR(120) NOT NULL,
                    [RecordId] INT NULL,
                    [RecordReference] NVARCHAR(240) NOT NULL,
                    [OriginalFileName] NVARCHAR(260) NOT NULL,
                    [StoredFileName] NVARCHAR(260) NOT NULL,
                    [StoredRelativePath] NVARCHAR(500) NOT NULL,
                    [PublicUrl] NVARCHAR(500) NOT NULL,
                    [ContentType] NVARCHAR(160) NOT NULL,
                    [FileSizeBytes] BIGINT NOT NULL,
                    [StorageProvider] NVARCHAR(80) NOT NULL,
                    [UploadedBy] NVARCHAR(160) NOT NULL,
                    [UploadedDate] DATETIME2 NOT NULL,
                    [Notes] NVARCHAR(2000) NOT NULL,
                    [Status] NVARCHAR(80) NOT NULL,
                    [IsEvidence] BIT NOT NULL,
                    [IsControlledDocument] BIT NOT NULL,
                    [IsDeleted] BIT NOT NULL,
                    [DeletedDate] DATETIME2 NULL,
                    [DeletedBy] NVARCHAR(160) NOT NULL
                );
            END
            """);

        await EnsureSqlServerIndexAsync(
            indexName: "IX_DocumentAttachments_ModuleName",
            sql: """
                CREATE INDEX [IX_DocumentAttachments_ModuleName]
                ON [DocumentAttachments] ([ModuleName]);
                """);

        await EnsureSqlServerIndexAsync(
            indexName: "IX_DocumentAttachments_RecordId",
            sql: """
                CREATE INDEX [IX_DocumentAttachments_RecordId]
                ON [DocumentAttachments] ([RecordId]);
                """);

        await EnsureSqlServerIndexAsync(
            indexName: "IX_DocumentAttachments_ModuleName_RecordId",
            sql: """
                CREATE INDEX [IX_DocumentAttachments_ModuleName_RecordId]
                ON [DocumentAttachments] ([ModuleName], [RecordId]);
                """);

        await EnsureSqlServerIndexAsync(
            indexName: "IX_DocumentAttachments_UploadedDate",
            sql: """
                CREATE INDEX [IX_DocumentAttachments_UploadedDate]
                ON [DocumentAttachments] ([UploadedDate]);
                """);

        await EnsureSqlServerIndexAsync(
            indexName: "IX_DocumentAttachments_IsDeleted",
            sql: """
                CREATE INDEX [IX_DocumentAttachments_IsDeleted]
                ON [DocumentAttachments] ([IsDeleted]);
                """);
    }

    private async Task EnsureSqlServerIndexAsync(string indexName, string sql)
    {
        var exists = await _db.Database
            .SqlQueryRaw<int>(
                """
                SELECT COUNT(1) AS [Value]
                FROM sys.indexes
                WHERE [name] = {0}
                AND [object_id] = OBJECT_ID(N'DocumentAttachments')
                """,
                indexName)
            .SingleAsync();

        if (exists == 0)
        {
            await _db.Database.ExecuteSqlRawAsync(sql);
        }
    }

    private async Task EnsureDocumentAttachmentsTableForSqliteAsync()
    {
        await _db.Database.ExecuteSqlRawAsync("""
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

        await _db.Database.ExecuteSqlRawAsync("""
            CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_ModuleName"
            ON "DocumentAttachments" ("ModuleName");
            """);

        await _db.Database.ExecuteSqlRawAsync("""
            CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_RecordId"
            ON "DocumentAttachments" ("RecordId");
            """);

        await _db.Database.ExecuteSqlRawAsync("""
            CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_ModuleName_RecordId"
            ON "DocumentAttachments" ("ModuleName", "RecordId");
            """);

        await _db.Database.ExecuteSqlRawAsync("""
            CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_UploadedDate"
            ON "DocumentAttachments" ("UploadedDate");
            """);

        await _db.Database.ExecuteSqlRawAsync("""
            CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_IsDeleted"
            ON "DocumentAttachments" ("IsDeleted");
            """);
    }
}