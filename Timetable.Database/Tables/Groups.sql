CREATE TABLE [dbo].[Groups] (
    [Id]            INT            NOT NULL IDENTITY (1,1),
    [Code]        NVARCHAR(MAX)    NOT NULL,
    [Course_Id] INT					NOT NULL,
    [Speciality_Id] INT            NOT NULL,
    [StudentsCount] INT NULL, 
    [Parent_Id] INT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Groups_ToGroup] FOREIGN KEY ([Parent_Id]) REFERENCES [Groups](Id), 
    CONSTRAINT [FK_Groups_ToCourse] FOREIGN KEY (Course_Id) REFERENCES Courses(Id), 
    CONSTRAINT [FK_Groups_ToSpeciality] FOREIGN KEY (Speciality_Id) REFERENCES Specialities(Id)
);
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Индекс группы', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Groups', @level2type = N'COLUMN', @level2name = N'Id';
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Номер группы', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Groups', @level2type = N'COLUMN', @level2name = 'Code';
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Курс', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Groups', @level2type = N'COLUMN', @level2name = 'Course_Id';
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Специальность(FK)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Groups', @level2type = N'COLUMN', @level2name = N'Speciality_Id';
GO



EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Количество студентов в группе',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Groups',
    @level2type = N'COLUMN',
    @level2name = N'StudentsCount'
GO

CREATE INDEX [IX_Groups_Id] ON [dbo].[Groups] (Id)
