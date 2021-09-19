SET IDENTITY_INSERT [Activity].[Tbl_Category] ON
DECLARE @Cat_Id INT = 1;

INSERT INTO [Activity].[Tbl_Category](Cat_Id, Cat_Name) 
VALUES
(@Cat_Id ,'Naturvanrding'),
(@Cat_Id+1, 'Idrott'),
(@Cat_Id+2, 'Bio'),
(@Cat_Id+3, 'Matlagning'),
(@Cat_Id+4, 'Föreläsning');

SET IDENTITY_INSERT [Activity].[Tbl_Category] OFF
GO