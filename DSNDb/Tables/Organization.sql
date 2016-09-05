CREATE TABLE [dbo].[Organization]
(
	[Id] INT NOT NULL, 
    [Name] VARCHAR(MAX) NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Organization_User] FOREIGN KEY (Id) REFERENCES [User](Id) 
)
