IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE TABLE [Company] (
        [CompanyId] int NOT NULL IDENTITY,
        [CompanyName] nvarchar(max) NULL,
        [Acronym] nvarchar(max) NULL,
        [CurrencyBase] nvarchar(max) NULL,
        [CurrenyGroup] nvarchar(max) NULL,
        [Operative] bit NOT NULL,
        CONSTRAINT [PK_Company] PRIMARY KEY ([CompanyId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE TABLE [Customer] (
        [CustomerId] int NOT NULL IDENTITY,
        [CustomerName] nvarchar(max) NULL,
        [CustomerGroupCode] nvarchar(max) NULL,
        [CountryCode] nvarchar(max) NULL,
        [CustomerGroupName] nvarchar(max) NULL,
        [LicensingArea] nvarchar(max) NULL,
        CONSTRAINT [PK_Customer] PRIMARY KEY ([CustomerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE TABLE [ExchangeRate] (
        [ExchangeRateId] int NOT NULL IDENTITY,
        [Year] int NOT NULL,
        [Scenario] nvarchar(max) NULL,
        [CurrencyAcronym] nvarchar(max) NULL,
        [ExRate] float NOT NULL,
        [InterCompanyRate] float NOT NULL,
        CONSTRAINT [PK_ExchangeRate] PRIMARY KEY ([ExchangeRateId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE TABLE [LedgerType] (
        [LedgerTypeId] int NOT NULL IDENTITY,
        [LedgerTypeCode] nvarchar(max) NULL,
        [Scenario] nvarchar(max) NULL,
        [Statutory] bit NOT NULL,
        CONSTRAINT [PK_LedgerType] PRIMARY KEY ([LedgerTypeId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE TABLE [PharmaForm] (
        [PharmaFormId] int NOT NULL IDENTITY,
        [PharmaFormAcronym] nvarchar(max) NULL,
        [PharmaFormName] nvarchar(max) NULL,
        CONSTRAINT [PK_PharmaForm] PRIMARY KEY ([PharmaFormId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE TABLE [ProductGroup] (
        [ProductGroupId] int NOT NULL IDENTITY,
        [ProductGroupCode] int NOT NULL,
        [ProductGroupAcronym] nvarchar(max) NULL,
        [ProductGroupName] nvarchar(max) NULL,
        CONSTRAINT [PK_ProductGroup] PRIMARY KEY ([ProductGroupId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE TABLE [UnToBulk] (
        [UnToBulkId] int NOT NULL IDENTITY,
        [ConversionRate] int NOT NULL,
        CONSTRAINT [PK_UnToBulk] PRIMARY KEY ([UnToBulkId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE TABLE [UnToKg] (
        [UnToKgId] int NOT NULL IDENTITY,
        [ConversionRate] float NOT NULL,
        CONSTRAINT [PK_UnToKg] PRIMARY KEY ([UnToKgId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE TABLE [Item] (
        [ItemMasterId] int NOT NULL IDENTITY,
        [ItemNumber] int NOT NULL,
        [ShortItem] nvarchar(max) NULL,
        [ItemDescription] nvarchar(max) NULL,
        [UnitOfMeasure] nvarchar(max) NULL,
        [PharmaFormId] int NOT NULL,
        [ProductGroupId] int NOT NULL,
        [UnToBulkId] int NOT NULL,
        [UnToKgId] int NOT NULL,
        CONSTRAINT [PK_Item] PRIMARY KEY ([ItemMasterId]),
        CONSTRAINT [FK_Item_PharmaForm_PharmaFormId] FOREIGN KEY ([PharmaFormId]) REFERENCES [PharmaForm] ([PharmaFormId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Item_ProductGroup_ProductGroupId] FOREIGN KEY ([ProductGroupId]) REFERENCES [ProductGroup] ([ProductGroupId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Item_UnToBulk_UnToBulkId] FOREIGN KEY ([UnToBulkId]) REFERENCES [UnToBulk] ([UnToBulkId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Item_UnToKg_UnToKgId] FOREIGN KEY ([UnToKgId]) REFERENCES [UnToKg] ([UnToKgId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE TABLE [Budget] (
        [BudgetId] int NOT NULL IDENTITY,
        [Year] int NOT NULL,
        [FreeOfCharge] nvarchar(max) NULL,
        [Currency] nvarchar(max) NULL,
        [UnitPrice] real NOT NULL,
        [MonthNr] nvarchar(max) NULL,
        [UnitOfMeasure] nvarchar(max) NULL,
        [QuantityKg] real NOT NULL,
        [Amount] int NOT NULL,
        [TotalImport] real NOT NULL,
        [LastUser] nvarchar(max) NULL,
        [ProgramId] int NOT NULL,
        [LastUpdate] datetime2 NOT NULL,
        [ItemMasterId] int NOT NULL,
        [CompanyId] int NOT NULL,
        [LedgerTypeId] int NOT NULL,
        [CustomerId] int NOT NULL,
        [ExchangeRateId] int NOT NULL,
        CONSTRAINT [PK_Budget] PRIMARY KEY ([BudgetId]),
        CONSTRAINT [FK_Budget_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([CompanyId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Budget_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Budget_ExchangeRate_ExchangeRateId] FOREIGN KEY ([ExchangeRateId]) REFERENCES [ExchangeRate] ([ExchangeRateId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Budget_Item_ItemMasterId] FOREIGN KEY ([ItemMasterId]) REFERENCES [Item] ([ItemMasterId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Budget_LedgerType_LedgerTypeId] FOREIGN KEY ([LedgerTypeId]) REFERENCES [LedgerType] ([LedgerTypeId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE INDEX [IX_Budget_CompanyId] ON [Budget] ([CompanyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE INDEX [IX_Budget_CustomerId] ON [Budget] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE INDEX [IX_Budget_ExchangeRateId] ON [Budget] ([ExchangeRateId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE INDEX [IX_Budget_ItemMasterId] ON [Budget] ([ItemMasterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE INDEX [IX_Budget_LedgerTypeId] ON [Budget] ([LedgerTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE INDEX [IX_Item_PharmaFormId] ON [Item] ([PharmaFormId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE INDEX [IX_Item_ProductGroupId] ON [Item] ([ProductGroupId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE INDEX [IX_Item_UnToBulkId] ON [Item] ([UnToBulkId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    CREATE INDEX [IX_Item_UnToKgId] ON [Item] ([UnToKgId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012063010_mig')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211012063010_mig', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [Budget] DROP CONSTRAINT [FK_Budget_Item_ItemMasterId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [Item] DROP CONSTRAINT [FK_Item_PharmaForm_PharmaFormId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [Item] DROP CONSTRAINT [FK_Item_ProductGroup_ProductGroupId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [Item] DROP CONSTRAINT [FK_Item_UnToBulk_UnToBulkId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [Item] DROP CONSTRAINT [FK_Item_UnToKg_UnToKgId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [Item] DROP CONSTRAINT [PK_Item];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    EXEC sp_rename N'[Item]', N'ItemMaster';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    EXEC sp_rename N'[ItemMaster].[IX_Item_UnToKgId]', N'IX_ItemMaster_UnToKgId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    EXEC sp_rename N'[ItemMaster].[IX_Item_UnToBulkId]', N'IX_ItemMaster_UnToBulkId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    EXEC sp_rename N'[ItemMaster].[IX_Item_ProductGroupId]', N'IX_ItemMaster_ProductGroupId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    EXEC sp_rename N'[ItemMaster].[IX_Item_PharmaFormId]', N'IX_ItemMaster_PharmaFormId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [ItemMaster] ADD CONSTRAINT [PK_ItemMaster] PRIMARY KEY ([ItemMasterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [Budget] ADD CONSTRAINT [FK_Budget_ItemMaster_ItemMasterId] FOREIGN KEY ([ItemMasterId]) REFERENCES [ItemMaster] ([ItemMasterId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [ItemMaster] ADD CONSTRAINT [FK_ItemMaster_PharmaForm_PharmaFormId] FOREIGN KEY ([PharmaFormId]) REFERENCES [PharmaForm] ([PharmaFormId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [ItemMaster] ADD CONSTRAINT [FK_ItemMaster_ProductGroup_ProductGroupId] FOREIGN KEY ([ProductGroupId]) REFERENCES [ProductGroup] ([ProductGroupId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [ItemMaster] ADD CONSTRAINT [FK_ItemMaster_UnToBulk_UnToBulkId] FOREIGN KEY ([UnToBulkId]) REFERENCES [UnToBulk] ([UnToBulkId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    ALTER TABLE [ItemMaster] ADD CONSTRAINT [FK_ItemMaster_UnToKg_UnToKgId] FOREIGN KEY ([UnToKgId]) REFERENCES [UnToKg] ([UnToKgId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012095705_cambionometabellaitem')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211012095705_cambionometabellaitem', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013070742_beast')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211013070742_beast', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013071359_newdb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211013071359_newdb', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013071643_double')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UnToBulk]') AND [c].[name] = N'ConversionRate');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [UnToBulk] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [UnToBulk] ALTER COLUMN [ConversionRate] float NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013071643_double')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211013071643_double', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013075347_companyconflict')
BEGIN
    ALTER TABLE [Budget] ADD [FBudgetBudgetId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013075347_companyconflict')
BEGIN
    CREATE INDEX [IX_Budget_FBudgetBudgetId] ON [Budget] ([FBudgetBudgetId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013075347_companyconflict')
BEGIN
    ALTER TABLE [Budget] ADD CONSTRAINT [FK_Budget_Budget_FBudgetBudgetId] FOREIGN KEY ([FBudgetBudgetId]) REFERENCES [Budget] ([BudgetId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013075347_companyconflict')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211013075347_companyconflict', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013080457_companyconflict1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211013080457_companyconflict1', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013081154_companyconflict2')
BEGIN
    ALTER TABLE [Budget] DROP CONSTRAINT [FK_Budget_Budget_FBudgetBudgetId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013081154_companyconflict2')
BEGIN
    DROP INDEX [IX_Budget_FBudgetBudgetId] ON [Budget];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013081154_companyconflict2')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'FBudgetBudgetId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Budget] DROP COLUMN [FBudgetBudgetId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211013081154_companyconflict2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211013081154_companyconflict2', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    ALTER TABLE [Budget] DROP CONSTRAINT [FK_Budget_ExchangeRate_ExchangeRateId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    DROP TABLE [ExchangeRate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    DROP INDEX [IX_Budget_ExchangeRateId] ON [Budget];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'Amount');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Budget] DROP COLUMN [Amount];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'QuantityKg');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Budget] DROP COLUMN [QuantityKg];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    EXEC sp_rename N'[Budget].[TotalImport]', N'TotalAmount', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    EXEC sp_rename N'[Budget].[ExchangeRateId]', N'Quantity', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'UnitOfMeasure');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Budget] ALTER COLUMN [UnitOfMeasure] nvarchar(max) NOT NULL;
    ALTER TABLE [Budget] ADD DEFAULT N'' FOR [UnitOfMeasure];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'MonthNr');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Budget] ALTER COLUMN [MonthNr] nvarchar(max) NOT NULL;
    ALTER TABLE [Budget] ADD DEFAULT N'' FOR [MonthNr];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'FreeOfCharge');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Budget] ALTER COLUMN [FreeOfCharge] nvarchar(max) NOT NULL;
    ALTER TABLE [Budget] ADD DEFAULT N'' FOR [FreeOfCharge];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'Currency');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Budget] ALTER COLUMN [Currency] nvarchar(max) NOT NULL;
    ALTER TABLE [Budget] ADD DEFAULT N'' FOR [Currency];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015085421_removedtableexchangerate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211015085421_removedtableexchangerate', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211021052233_migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211021052233_migration', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211022114716_friday')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211022114716_friday', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211026120455_db')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211026120455_db', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [Ago] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [Apr] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [Dec] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [Feb] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [Jan] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [Jul] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [Jun] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [Mar] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [May] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [Nov] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [Oct] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    ALTER TABLE [Budget] ADD [Sept] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211108111347_MonthlyDetails')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211108111347_MonthlyDetails', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211109092137_TotalMonths')
BEGIN
    ALTER TABLE [Budget] ADD [TotalMonths] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211109092137_TotalMonths')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211109092137_TotalMonths', N'5.0.11');
END;
GO

COMMIT;
GO

