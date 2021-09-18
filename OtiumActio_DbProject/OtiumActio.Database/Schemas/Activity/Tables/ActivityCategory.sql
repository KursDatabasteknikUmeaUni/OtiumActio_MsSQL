CREATE TABLE [Activity].[Tbl_ActivityCategory] (
    [Acat_Id] INT IDENTITY(1,1) NOT NULL,
    [Acat_CategoryId] INT FOREIGN KEY REFERENCES Activity.Tbl_Category(Cat_Id),
    [Acat_ActivityId] INT FOREIGN KEY REFERENCES Activity.Tbl_Activity(Ac_Id)

    CONSTRAINT [PK_Tbl_ActivityCategory] PRIMARY KEY  ([Acat_Id] ASC)
);

