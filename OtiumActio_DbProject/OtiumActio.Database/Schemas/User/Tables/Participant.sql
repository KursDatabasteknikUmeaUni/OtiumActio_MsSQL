--CREATE SCHEMA [User]

CREATE TABLE [User].Participant (
    Id int IDENTITY(1,1) Not null,
    ActivityId int FOREIGN KEY REFERENCES Activity.Activity(Id),
    FirstName varchar(50),
    LastName varchar(50),
    Age int,
    FavouritCategory int FOREIGN KEY REFERENCES Activity.Category(Id),

    CONSTRAINT Participant_pk PRIMARY KEY  (Id)
);