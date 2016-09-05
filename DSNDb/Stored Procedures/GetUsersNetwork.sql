CREATE PROCEDURE [dbo].[GetUsersNetwork]
	@id int
AS
	SELECT I.Id, I.Name, I.Title , I.Organization 
	FROM [Graph] AS G INNER JOIN [Individual] AS I ON G.Id2 = I.Id
	WHERE G.Id1 = @id;
	
	SELECT O.Id, O.Name, O.Description
	FROM [Graph] AS G INNER JOIN [Organization] AS O ON G.Id2 = O.Id
	WHERE G.Id1 = @id;
		 
RETURN 0
