CREATE TABLE [dbo].[Departments] (
    [Id]         INT            NOT NULL IDENTITY (1,1),
    [Name]       NVARCHAR (MAX) NOT NULL,
    [ShortName]  NVARCHAR (MAX) NULL,
    [Faculty_Id] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Departments_ToFaculty] FOREIGN KEY ([Faculty_Id]) REFERENCES [Faculties]([Id]),
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Индексный ключ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Departments', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Название кафедры', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Departments', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Краткое наим.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Departments', @level2type = N'COLUMN', @level2name = N'ShortName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Факультет', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Departments', @level2type = N'COLUMN', @level2name = N'Faculty_Id';


GO

CREATE INDEX [IX_Departments_Id] ON [dbo].[Departments] (Id)
