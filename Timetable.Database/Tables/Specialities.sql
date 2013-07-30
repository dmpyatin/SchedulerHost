CREATE TABLE [dbo].[Specialities] (
    [Id]            INT            NOT NULL IDENTITY (1,1),
    [Name]          NVARCHAR (MAX) NOT NULL,
    [ShortName]     NVARCHAR (MAX) NULL,
    [Code]        NVARCHAR (MAX) NOT NULL,
    [Department_Id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Specialities_ToTable] FOREIGN KEY (Department_Id) REFERENCES Departments(Id)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Индекс специальности', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Specialities', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Наименование', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Specialities', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Краткое наименование', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Specialities', @level2type = N'COLUMN', @level2name = N'ShortName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Шифр', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Specialities', @level2type = N'COLUMN', @level2name = 'Code';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Кафедра', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Specialities', @level2type = N'COLUMN', @level2name = 'Department_Id';


GO

CREATE INDEX [IX_Specialities_Id] ON [dbo].[Specialities] (Id)
