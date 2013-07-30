CREATE TABLE [dbo].[Auditoriums] (
    [Id]         INT            NOT NULL IDENTITY (1,1),
    [Number]     NVARCHAR (50)  NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [Capacity]   INT            NULL,
    [Info]       NVARCHAR (MAX) NULL,
    [Building_Id] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Auditoriums_ToBuildings] FOREIGN KEY ([Building_Id]) REFERENCES [Buildings]([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Индекс аудитории', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Auditoriums', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Номер', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Auditoriums', @level2type = N'COLUMN', @level2name = N'Number';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Название', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Auditoriums', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Вместимость', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Auditoriums', @level2type = N'COLUMN', @level2name = N'Capacity';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Доп. инф.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Auditoriums', @level2type = N'COLUMN', @level2name = N'Info';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Корпус(FK)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Auditoriums', @level2type = N'COLUMN', @level2name = 'Building_Id';


GO

CREATE INDEX [IX_Auditoriums_Id] ON [dbo].[Auditoriums] (Id)

GO

CREATE INDEX [IX_Auditoriums_Number] ON [dbo].[Auditoriums] (Number)
