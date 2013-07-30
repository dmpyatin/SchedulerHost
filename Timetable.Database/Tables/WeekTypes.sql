CREATE TABLE [dbo].[WeekTypes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Name] NVARCHAR(MAX) NOT NULL
)

GO

CREATE INDEX [IX_WeekTypes_Id] ON [dbo].[WeekTypes] (Id)
