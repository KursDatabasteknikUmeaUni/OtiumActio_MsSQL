Create procedure GetAllActivities   
as  
Begin  
 Select A.Ac_Id,   A.Ac_Description, A.Ac_Date, A.Ac_CategoryId, A.Ac_Participants
 From [Activity].[Tbl_Activity] A 
End 