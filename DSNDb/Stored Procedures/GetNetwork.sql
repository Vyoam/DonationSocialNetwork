CREATE PROCEDURE [dbo].[GetNetwork]
AS
	SELECT I.Id, I.Name, I.Title , I.Organization 
	FROM [User] AS U INNER JOIN [Individual] AS I ON U.Id = I.Id
	
	SELECT O.Id, O.Name, O.Description
	FROM [User] AS U INNER JOIN [Organization] AS O ON U.Id = O.Id
RETURN 0
