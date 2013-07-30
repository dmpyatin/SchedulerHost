CREATE TABLE [dbo].[Tutorials] (
    [Id]        INT            NOT NULL IDENTITY (1,1),
    [Name]      NVARCHAR (MAX) NOT NULL,
    [ShortName] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Индекс предмета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tutorials', @level2type = N'COLUMN', @level2name = N'Id';

GO


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Наименование', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tutorials', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Краткое наименование', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tutorials', @level2type = N'COLUMN', @level2name = N'ShortName';
GO

CREATE INDEX [IX_Tutorials_I] ON [dbo].[Tutorials] (Id)
