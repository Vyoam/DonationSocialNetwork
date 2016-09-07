CREATE TABLE [dbo].[Need]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [User_Id] INT NOT NULL, 
    [Title] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(50) NULL, 
    [Actual Amount] INT NOT NULL, 
    [Balance Amount] INT NOT NULL, 
    [Facilitator_Id] INT NOT NULL, 
    [Approval_Status] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Need_ToUser] FOREIGN KEY (User_Id) REFERENCES [User](Id)
)
