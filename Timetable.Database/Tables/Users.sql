CREATE TABLE [dbo].[Users] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Login]        NVARCHAR (100) NOT NULL,
    [Password]     NVARCHAR (MAX) NOT NULL,
    [Active]       BIT            DEFAULT ((1)) NOT NULL,
    [LastVisit]    DATETIME       DEFAULT (getdate()) NOT NULL,
    [Registration] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Логин', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'Login';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Пароль', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'Password';


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Индекс пользователя',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Активен',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = N'Active'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Дата последнего посещения',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = N'LastVisit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Дата регистрации',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = N'Registration'
GO

CREATE INDEX [IX_Users_Id] ON [dbo].[Users] (Id)

GO

CREATE INDEX [IX_Users_Login] ON [dbo].[Users] (Login)

GO