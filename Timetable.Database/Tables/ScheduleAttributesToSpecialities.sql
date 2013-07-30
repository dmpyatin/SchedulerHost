CREATE TABLE [dbo].[ScheduleAttributesToSpecialities]
(
	[ScheduleAttribute_Id] INT NOT NULL , 
	[Speciality_Id] INT NOT NULL, 
	PRIMARY KEY ([Speciality_Id], [ScheduleAttribute_Id]), 
	CONSTRAINT [FK_ScheduleAttributesToSpecialities_ToTable] FOREIGN KEY (Speciality_Id) REFERENCES Specialities(Id), 
	CONSTRAINT [FK_ScheduleAttributesToSpecialities_ToScheduleAttributes] FOREIGN KEY ([ScheduleAttribute_Id]) REFERENCES ScheduleAttributes(Id)
)

GO

CREATE INDEX [IX_ScheduleAttributesToSpecialities_ScheduleAttribute_Id] ON [dbo].[ScheduleAttributesToSpecialities] (ScheduleAttribute_Id)

GO

CREATE INDEX [IX_ScheduleAttributesToSpecialities_Speciality_Id] ON [dbo].[ScheduleAttributesToSpecialities] (Speciality_Id)
