CREATE TABLE [dbo].[Logs] (
    [Id]       INT            NOT NULL IDENTITY (1,1),
    [User_Id]  INT            NOT NULL,
    [Message]  NVARCHAR (MAX) NULL,
    [DateTime] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Logs_ToUser] FOREIGN KEY ([User_Id]) REFERENCES Users(Id),
);


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Индекс лога',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Logs',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'ИндексЮзера(FK)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Logs',
    @level2type = N'COLUMN',
    @level2name = N'User_Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Сообщение',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Logs',
    @level2type = N'COLUMN',
    @level2name = N'Message'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Дата лога',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Logs',
    @level2type = N'COLUMN',
    @level2name = N'DateTime'
GO

CREATE INDEX [IX_Logs_Id] ON [dbo].[Logs] (Id)
