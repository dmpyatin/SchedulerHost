CREATE TABLE [dbo].[ScheduleAttributesToCourses]
(
    [ScheduleAttribute_Id] INT NOT NULL , 
    [Course_Id] INT NOT NULL, 
    PRIMARY KEY ([Course_Id], [ScheduleAttribute_Id]), 
    CONSTRAINT [FK_ScheduleAttributesToCourses_ToTable] FOREIGN KEY (Course_Id) REFERENCES Courses(Id), 
    CONSTRAINT [FK_ScheduleAttributesToCourses_ToScheduleAttributes] FOREIGN KEY ([ScheduleAttribute_Id]) REFERENCES ScheduleAttributes(Id)
)

GO

CREATE INDEX [IX_ScheduleAttributesToCourses_ScheduleAttribute_Id] ON [dbo].[ScheduleAttributesToCourses] (ScheduleAttribute_Id)

GO

CREATE INDEX [IX_ScheduleAttributesToCourses_Course_Id] ON [dbo].[ScheduleAttributesToCourses] (Course_Id)
