CREATE TABLE [dbo].[Buildings] (
    [Id]      INT            NOT NULL IDENTITY (1,1),
    [Name]    NVARCHAR (MAX) NOT NULL,
    [Address] NVARCHAR (MAX) NULL,
    [ShortName] NVARCHAR(MAX) NULL, 
    [Info] NVARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Индекс корпуса', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buildings', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Название', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buildings', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Адрес', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buildings', @level2type = N'COLUMN', @level2name = N'Address';


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Кратное наименование',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Buildings',
    @level2type = N'COLUMN',
    @level2name = N'ShortName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Доп. инф.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Buildings',
    @level2type = N'COLUMN',
    @level2name = N'Info'
GO

CREATE INDEX [IX_Buildings_Id] ON [dbo].[Buildings] (Id)
