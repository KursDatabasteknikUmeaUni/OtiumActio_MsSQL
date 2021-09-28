CREATE PROCEDURE GetCategoryName(@categoryId int)  
AS  
 select Cat.Cat_Name from [Activity].[Tbl_Category] Cat where Cat_Id = @categoryId 