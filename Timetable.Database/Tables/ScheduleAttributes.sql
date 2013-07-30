CREATE TABLE [dbo].[ScheduleAttributes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [TutorialType_Id] INT NOT NULL, 
    [Tutorial_Id] INT NOT NULL, 
    [HoursPerWeek] INT NULL, 
    [SubgroupCount] INT NOT NULL DEFAULT 0, 
    [Department_Id] INT NOT NULL, 
    [Lecturer_Id] INT NOT NULL, 
    CONSTRAINT [FK_ScheduleAttributes_ToTutorialType] FOREIGN KEY ([TutorialType_Id]) REFERENCES [TutorialTypes]([Id]), 
    CONSTRAINT [FK_ScheduleAttributes_ToTutorial] FOREIGN KEY (Tutorial_Id) REFERENCES Tutorials(Id), 
    CONSTRAINT [FK_ScheduleAttributes_ToDepartment] FOREIGN KEY (Department_Id) REFERENCES [Departments](Id), 
    CONSTRAINT [FK_ScheduleAttributes_ToLecturer] FOREIGN KEY ([Lecturer_Id]) REFERENCES [Lecturers]([Id])
)

GO

CREATE INDEX [IX_ScheduleAttributes_Id] ON [dbo].[ScheduleAttributes] ([Id])
