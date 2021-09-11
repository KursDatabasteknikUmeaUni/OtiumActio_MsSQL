CREATE TABLE Activity.ActivityCategory (
    Id int IDENTITY(1,1) Not null,
    CategoryId int Unique FOREIGN KEY REFERENCES Activity.Category(Id),
    ActivityId int Not null
    --int FOREIGN KEY REFERENCES Activity(Id)

    CONSTRAINT ActivityCategory_pk PRIMARY KEY  (Id)
);


--Added foreign key to ActivityId, after creating Activity table, by 
--Alter table Activity.ActivityCategory
--Add FOREIGN KEY (ActivityId) REFERENCES Activity.Activity(Id)