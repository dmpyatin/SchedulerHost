CREATE TABLE [dbo].[ScheduleAttributesToGroups]
(
	[ScheduleAttribute_Id] INT NOT NULL , 
    [Group_Id] INT NOT NULL, 
    PRIMARY KEY ([ScheduleAttribute_Id], [Group_Id]), 
    CONSTRAINT [FK_ScheduleAttributesToGroups_ToGroup] FOREIGN KEY ([Group_Id]) REFERENCES Groups(Id), 
    CONSTRAINT [FK_ScheduleAttributesToGroups_ToScheduleAttribute] FOREIGN KEY ([ScheduleAttribute_Id]) REFERENCES [ScheduleAttributes](Id)
)
