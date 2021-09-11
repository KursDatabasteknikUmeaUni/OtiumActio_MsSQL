--CREATE SCHEMA Activity;

CREATE TABLE Activity.Activity (
    Id int IDENTITY(1,1) Not null,
    CategoryId int FOREIGN KEY REFERENCES Activity.ActivityCategory(CategoryId),
    Description varchar(50),
    Participants tinyint,
    Date datetime

    CONSTRAINT Activity_pk PRIMARY KEY  (Id)
);