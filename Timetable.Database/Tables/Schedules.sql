CREATE TABLE [dbo].[Schedules]
(	
    [Auditorium_Id] INT NOT NULL, 
    [DayOfWeek] INT NOT NULL, 
	[EndDate] DATE NULL, 
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [ScheduleAttribute_Id] INT NOT NULL,
	[StartDate] DATE NULL, 
	[Time_Id] INT NOT NULL, 
	[WeekType_Id] INT NOT NULL, 
    CONSTRAINT [FK_Schedules_ToAuditoriums] FOREIGN KEY (Auditorium_Id) REFERENCES Auditoriums(Id), 
    CONSTRAINT [FK_Schedules_ToTable_1] FOREIGN KEY (WeekType_Id) REFERENCES WeekTypes(Id), 
    CONSTRAINT [FK_Schedules_ToTable_2] FOREIGN KEY (Time_Id) REFERENCES Times(Id), 
    CONSTRAINT [FK_Schedules_ToScheduleAttributes] FOREIGN KEY ([ScheduleAttribute_Id]) REFERENCES ScheduleAttributes(Id)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Идентификатор аудитории',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Schedules',
    @level2type = N'COLUMN',
    @level2name = N'Auditorium_Id'
GO

GO

GO

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Идентификатор времени',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Schedules',
    @level2type = N'COLUMN',
    @level2name = 'Time_Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Дата занятия',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Schedules',
    @level2type = N'COLUMN',
    @level2name = 'StartDate'
GO


CREATE INDEX [IX_Schedules_Id] ON [dbo].[Schedules] (Id)
