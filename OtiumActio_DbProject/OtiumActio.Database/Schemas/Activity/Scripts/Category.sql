DECLARE @Cat_Id INT = 1;

SET IDENTITY_INSERT [Activity].[Tbl_Category] ON

MERGE INTO [Activity].[Tbl_Category] AS TARGET
USING (VALUES
(@Cat_Id, 'Naturvanrding'),
(@Cat_Id+1, 'Idrott'),
(@Cat_Id+2, 'Bio'),
(@Cat_Id+3, 'Matlagning'),
(@Cat_Id+4, 'Föreläsning')

)
AS Source ([Cat_Id], [Cat_Name])
ON TARGET.Cat_Id = Source.Cat_Id
WHEN MATCHED AND (TARGET.[Cat_Name] <> Source.[Cat_Name]
OR ISNULL(TARGET.Cat_Id, -1) <> ISNULL(Source.Cat_Name, -1)
) THEN 
UPDATE SET [Cat_Id] = Source.Cat_Id,
		[Cat_Name] = Source.Cat_Name
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Cat_Id], [Cat_Name])
VALUES ([Cat_Id], [Cat_Name])
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

SET IDENTITY_INSERT [Activity].[Tbl_Category] OFF
