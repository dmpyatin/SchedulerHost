CREATE TABLE [dbo].[AuditoriumApplicabilities] (
    [Id]            INT NOT NULL IDENTITY (1,1),
    [Auditorium_Id] INT NOT NULL,
    [TutorialType_Id]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_AuditoriumApplicabilities_ToAuditorium] FOREIGN KEY ([Auditorium_Id]) REFERENCES [Auditoriums]([Id]), 
    CONSTRAINT [FK_AuditoriumApplicabilities_ToTutorialType] FOREIGN KEY ([TutorialType_Id]) REFERENCES [TutorialTypes]([Id])
);


GO
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Аудитория(FK)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AuditoriumApplicabilities', @level2type = N'COLUMN', @level2name = N'Auditorium_Id';


GO
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Вид занятий(FK)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AuditoriumApplicabilities', @level2type = N'COLUMN', @level2name = 'TutorialType_Id';


GO

CREATE INDEX [IX_AuditoriumApplicabilities_Id] ON [dbo].[AuditoriumApplicabilities] (Id)
