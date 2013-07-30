CREATE TABLE [dbo].[TutorialTypes] (
    [Id]       INT            NOT NULL IDENTITY (1,1),
    [Name] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Индексный ключ',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'TutorialTypes',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Наименование',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'TutorialTypes',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO

CREATE INDEX [IX_TutorialTypes_Id] ON [dbo].[TutorialTypes] (Id)
