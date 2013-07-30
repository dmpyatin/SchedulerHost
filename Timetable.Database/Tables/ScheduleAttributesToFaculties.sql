CREATE TABLE [dbo].[ScheduleAttributesToFaculties]
(
	[ScheduleAttribute_Id] INT NOT NULL , 
    [Faculty_Id] INT NOT NULL, 
    PRIMARY KEY ([Faculty_Id], [ScheduleAttribute_Id]), 
    CONSTRAINT [FK_ScheduleAttributesToFaculties_ToFaculty] FOREIGN KEY (Faculty_Id) REFERENCES Faculties(Id), 
    CONSTRAINT [FK_ScheduleAttributesToFaculties_ToScheduleAttributes] FOREIGN KEY ([ScheduleAttribute_Id]) REFERENCES ScheduleAttributes(Id)
)

GO

CREATE INDEX [IX_ScheduleAttributesToFaculties_ScheduleAttribute_Id] ON [dbo].[ScheduleAttributesToFaculties] (ScheduleAttribute_Id)

GO

CREATE INDEX [IX_ScheduleAttributesToFaculties_Faculty_Id] ON [dbo].[ScheduleAttributesToFaculties] (Faculty_Id)
