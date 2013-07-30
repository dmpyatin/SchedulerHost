CREATE TABLE [dbo].[Lecturers] (
    [Id]            INT            NOT NULL IDENTITY (1,1),
    [Lastname]       NVARCHAR (MAX) NOT NULL,
    [Firstname]          NVARCHAR (MAX) NOT NULL,
    [Middlename]       NVARCHAR (MAX) NULL,
    [Contacts]          NVARCHAR (MAX) NULL,
    [Department_Id] INT            NULL,
    [Rank_Id]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Lecturers_ToDepartments] FOREIGN KEY (Department_Id) REFERENCES Departments(Id), 
    CONSTRAINT [FK_Lecturers_ToRanks] FOREIGN KEY (Rank_Id) REFERENCES Ranks(Id)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Индексный ключ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lecturers', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Фамилия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lecturers', @level2type = N'COLUMN', @level2name = 'Lastname';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Имя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lecturers', @level2type = N'COLUMN', @level2name = 'Firstname';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Отчество', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lecturers', @level2type = N'COLUMN', @level2name = 'Middlename';


GO



GO



GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Контакт. инф.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lecturers', @level2type = N'COLUMN', @level2name = 'Contacts';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Кафедра(FK)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lecturers', @level2type = N'COLUMN', @level2name = 'Department_Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Должность(FK)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lecturers', @level2type = N'COLUMN', @level2name = 'Rank_Id';


GO

CREATE INDEX [IX_Lecturers_Id] ON [dbo].[Lecturers] (Id)
