Create procedure GetAllCategories   
@CategoryId Int = NUll  
as  
Begin  
 Select C.Id,   C.Name  
 From Activity.Category C  
 Where C.Id = ISNULL(@CategoryId, Id)  
End 