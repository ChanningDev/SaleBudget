BEGIN TRANSACTION;
GO

ALTER TABLE [Budget] DROP CONSTRAINT [FK_Budget_Item_ItemMasterId];
GO

ALTER TABLE [Item] DROP CONSTRAINT [FK_Item_PharmaForm_PharmaFormId];
GO

ALTER TABLE [Item] DROP CONSTRAINT [FK_Item_ProductGroup_ProductGroupId];
GO

ALTER TABLE [Item] DROP CONSTRAINT [FK_Item_UnToBulk_UnToBulkId];
GO

ALTER TABLE [Item] DROP CONSTRAINT [FK_Item_UnToKg_UnToKgId];
GO

ALTER TABLE [Item] DROP CONSTRAINT [PK_Item];
GO

EXEC sp_rename N'[Item]', N'ItemMaster';
GO

EXEC sp_rename N'[ItemMaster].[IX_Item_UnToKgId]', N'IX_ItemMaster_UnToKgId', N'INDEX';
GO

EXEC sp_rename N'[ItemMaster].[IX_Item_UnToBulkId]', N'IX_ItemMaster_UnToBulkId', N'INDEX';
GO

EXEC sp_rename N'[ItemMaster].[IX_Item_ProductGroupId]', N'IX_ItemMaster_ProductGroupId', N'INDEX';
GO

EXEC sp_rename N'[ItemMaster].[IX_Item_PharmaFormId]', N'IX_ItemMaster_PharmaFormId', N'INDEX';
GO

ALTER TABLE [ItemMaster] ADD CONSTRAINT [PK_ItemMaster] PRIMARY KEY ([ItemMasterId]);
GO

ALTER TABLE [Budget] ADD CONSTRAINT [FK_Budget_ItemMaster_ItemMasterId] FOREIGN KEY ([ItemMasterId]) REFERENCES [ItemMaster] ([ItemMasterId]) ON DELETE CASCADE;
GO

ALTER TABLE [ItemMaster] ADD CONSTRAINT [FK_ItemMaster_PharmaForm_PharmaFormId] FOREIGN KEY ([PharmaFormId]) REFERENCES [PharmaForm] ([PharmaFormId]) ON DELETE CASCADE;
GO

ALTER TABLE [ItemMaster] ADD CONSTRAINT [FK_ItemMaster_ProductGroup_ProductGroupId] FOREIGN KEY ([ProductGroupId]) REFERENCES [ProductGroup] ([ProductGroupId]) ON DELETE CASCADE;
GO

ALTER TABLE [ItemMaster] ADD CONSTRAINT [FK_ItemMaster_UnToBulk_UnToBulkId] FOREIGN KEY ([UnToBulkId]) REFERENCES [UnToBulk] ([UnToBulkId]) ON DELETE CASCADE;
GO

ALTER TABLE [ItemMaster] ADD CONSTRAINT [FK_ItemMaster_UnToKg_UnToKgId] FOREIGN KEY ([UnToKgId]) REFERENCES [UnToKg] ([UnToKgId]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211012095705_cambionometabellaitem', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211013070742_beast', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211013071359_newdb', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UnToBulk]') AND [c].[name] = N'ConversionRate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [UnToBulk] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [UnToBulk] ALTER COLUMN [ConversionRate] float NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211013071643_double', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Budget] ADD [FBudgetBudgetId] int NULL;
GO

CREATE INDEX [IX_Budget_FBudgetBudgetId] ON [Budget] ([FBudgetBudgetId]);
GO

ALTER TABLE [Budget] ADD CONSTRAINT [FK_Budget_Budget_FBudgetBudgetId] FOREIGN KEY ([FBudgetBudgetId]) REFERENCES [Budget] ([BudgetId]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211013075347_companyconflict', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211013080457_companyconflict1', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Budget] DROP CONSTRAINT [FK_Budget_Budget_FBudgetBudgetId];
GO

DROP INDEX [IX_Budget_FBudgetBudgetId] ON [Budget];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'FBudgetBudgetId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Budget] DROP COLUMN [FBudgetBudgetId];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211013081154_companyconflict2', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Budget] DROP CONSTRAINT [FK_Budget_ExchangeRate_ExchangeRateId];
GO

DROP TABLE [ExchangeRate];
GO

DROP INDEX [IX_Budget_ExchangeRateId] ON [Budget];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'Amount');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Budget] DROP COLUMN [Amount];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'QuantityKg');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Budget] DROP COLUMN [QuantityKg];
GO

EXEC sp_rename N'[Budget].[TotalImport]', N'TotalAmount', N'COLUMN';
GO

EXEC sp_rename N'[Budget].[ExchangeRateId]', N'Quantity', N'COLUMN';
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'UnitOfMeasure');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Budget] ALTER COLUMN [UnitOfMeasure] nvarchar(max) NOT NULL;
ALTER TABLE [Budget] ADD DEFAULT N'' FOR [UnitOfMeasure];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'MonthNr');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Budget] ALTER COLUMN [MonthNr] nvarchar(max) NOT NULL;
ALTER TABLE [Budget] ADD DEFAULT N'' FOR [MonthNr];
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'FreeOfCharge');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Budget] ALTER COLUMN [FreeOfCharge] nvarchar(max) NOT NULL;
ALTER TABLE [Budget] ADD DEFAULT N'' FOR [FreeOfCharge];
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Budget]') AND [c].[name] = N'Currency');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Budget] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Budget] ALTER COLUMN [Currency] nvarchar(max) NOT NULL;
ALTER TABLE [Budget] ADD DEFAULT N'' FOR [Currency];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211015085421_removedtableexchangerate', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211021052233_migration', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211022114716_friday', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211026120455_db', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Budget] ADD [Ago] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Budget] ADD [Apr] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Budget] ADD [Dec] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Budget] ADD [Feb] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Budget] ADD [Jan] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Budget] ADD [Jul] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Budget] ADD [Jun] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Budget] ADD [Mar] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Budget] ADD [May] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Budget] ADD [Nov] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Budget] ADD [Oct] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Budget] ADD [Sept] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211108111347_MonthlyDetails', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Budget] ADD [TotalMonths] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211109092137_TotalMonths', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Company]') AND [c].[name] = N'CurrenyGroup');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Company] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Company] ALTER COLUMN [CurrenyGroup] nvarchar(max) NOT NULL;
ALTER TABLE [Company] ADD DEFAULT N'' FOR [CurrenyGroup];
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Company]') AND [c].[name] = N'CurrencyBase');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Company] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Company] ALTER COLUMN [CurrencyBase] nvarchar(max) NOT NULL;
ALTER TABLE [Company] ADD DEFAULT N'' FOR [CurrencyBase];
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Company]') AND [c].[name] = N'CompanyName');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Company] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Company] ALTER COLUMN [CompanyName] nvarchar(max) NOT NULL;
ALTER TABLE [Company] ADD DEFAULT N'' FOR [CompanyName];
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Company]') AND [c].[name] = N'Acronym');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Company] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Company] ALTER COLUMN [Acronym] nvarchar(max) NOT NULL;
ALTER TABLE [Company] ADD DEFAULT N'' FOR [Acronym];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211212090451_company', N'5.0.12');
GO

COMMIT;
GO

