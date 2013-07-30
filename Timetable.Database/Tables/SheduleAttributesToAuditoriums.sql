CREATE TABLE [dbo].[SheduleAttributesToAuditoriums]
(
	[Auditorium_Id] INT NOT NULL , 
    [ScheduleAttribute_Id] INT NOT NULL, 
    PRIMARY KEY ([Auditorium_Id], [ScheduleAttribute_Id]), 
    CONSTRAINT [FK_SheduleAttributesToAuditoriums_ToTable] FOREIGN KEY (Auditorium_Id) REFERENCES Auditoriums(Id), 
    CONSTRAINT [FK_SheduleAttributesToAuditoriums_ToScheduleAttributes] FOREIGN KEY ([ScheduleAttribute_Id]) REFERENCES ScheduleAttributes(Id)
)

GO

CREATE INDEX [IX_SheduleAttributesToAuditoriums_Auditorium_Id] ON [dbo].[SheduleAttributesToAuditoriums] (Auditorium_Id)

GO

CREATE INDEX [IX_SheduleAttributesToAuditoriums_ScheduleAttribute_Id] ON [dbo].[SheduleAttributesToAuditoriums] (ScheduleAttribute_Id)
