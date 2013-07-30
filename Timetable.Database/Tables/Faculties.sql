CREATE TABLE [dbo].[Faculties] (
    [Id]   INT            NOT NULL IDENTITY (1,1),
    [Name] NVARCHAR (MAX) NOT NULL,
    [ShortName] NVARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Индекс факультета',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Faculties',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Наименование',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Faculties',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Краткое наим.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Faculties',
    @level2type = N'COLUMN',
    @level2name = N'ShortName'
GO

CREATE INDEX [IX_Faculties_Id] ON [dbo].[Faculties] (Id)
