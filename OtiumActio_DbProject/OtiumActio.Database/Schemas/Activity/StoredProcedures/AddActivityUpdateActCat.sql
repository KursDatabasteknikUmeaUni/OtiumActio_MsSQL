CREATE PROCEDURE AddActivityUpdateActCat
(   
@id int,
    @category int,
    @description VARCHAR(50) ,
    @participants TINYINT,
    @date DATETIME
)
AS  
BEGIN
SET IDENTITY_INSERT [Activity].[Tbl_Activity]  ON
INSERT INTO [Activity].[Tbl_Activity] 
(
Ac_Id,
Ac_CategoryId,Ac_Description,Ac_Participants,Ac_Date)  
VALUES
(
@id,
@category,@description,@participants,@date)
SET IDENTITY_INSERT [Activity].[Tbl_Activity]  OFF

--	BEGIN TRY
--		BEGIN TRANSACTION
--		SAVE TRANSACTION UpdateActivityCategory;
--		SELECT @@TRANCOUNT AS [TranCount];
--		UPDATE ActivityCategory
--		SET ActivityCategory.Acat_ActivityId = @id
--		FROM [Activity].[Tbl_ActivityCategory] ActivityCategory
--		INNER JOIN Tbl_Activity Activity 
--		ON  ActivityCategory.Acat_CategoryId = @category
--		COMMIT TRANSACTION 
--    END TRY
--    BEGIN CATCH
--        SELECT
--        ERROR_NUMBER() AS ErrorNumber,
--        ERROR_STATE() AS ErrorState,
--        ERROR_SEVERITY() AS ErrorSeverity,
--        ERROR_PROCEDURE() AS ErrorProcedure,
--        ERROR_LINE() AS ErrorLine,
--        ERROR_MESSAGE() AS ErrorMessage;
--    ROLLBACK TRANSACTION UpdateActivityCategory
--        END CATCH
END
----EXEC UpdateActivityCategoryTable