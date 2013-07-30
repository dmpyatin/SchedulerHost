CREATE TABLE [dbo].[Times]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Start] TIME(0) NOT NULL, 
    [End] TIME(0) NOT NULL
)
GO

CREATE INDEX [IX_Times_Id] ON [dbo].[Times] (Id)
