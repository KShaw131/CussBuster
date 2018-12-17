CREATE DATABASE CussBusterDB
GO

USE CussBusterDB
GO

CREATE TABLE wordType
(
    Id INT NOT NULL PRIMARY KEY,
    TypeName VARCHAR(100)
)
GO

CREATE TABLE curseWords
(
    Id INT IDENTITY NOT NULL PRIMARY KEY,
    CurseWord VARCHAR(100),
    Severity INT,
    TypeId INT FOREIGN KEY REFERENCES wordType(Id),
    InsertedDate DATETIME,
    InsertedBy VARCHAR(100),
    UpdatedDate DATETIME,
    UpdatedBy VARCHAR(100)
)
GO

--Seeding static table

INSERT INTO wordType (Id, TypeName)
VALUES(1, "racist");

INSERT INTO wordType (Id, TypeName)
VALUES(2, "vulgar");

INSERT INTO wordType (Id, TypeName)
VALUES(3, "xenophobic");

--Seeding data into curseWords table

INSERT INTO curseWords (CurseWord, Severity, TypeId, InsertedDate, InsertedBy, UpdatedDate, UpdatedBy)
VALUES("Fuck", 10, 2, GETUTCDATE(), "Kelly Shaw", null, null);

INSERT INTO curseWords (CurseWord, Severity, TypeId, InsertedDate, InsertedBy, UpdatedDate, UpdatedBy)
VALUES("Ass", 2, 2, GETUTCDATE(), "Kelly Shaw", null, null);

INSERT INTO curseWords (CurseWord, Severity, TypeId, InsertedDate, InsertedBy, UpdatedDate, UpdatedBy)
VALUES("Shit", 8, 2, GETUTCDATE(), "Kelly Shaw", null, null);

INSERT INTO curseWords (CurseWord, Severity, TypeId, InsertedDate, InsertedBy, UpdatedDate, UpdatedBy)
VALUES("Nigga", 5, 1, GETUTCDATE(), "Kelly Shaw", null, null);

INSERT INTO curseWords (CurseWord, Severity, TypeId, InsertedDate, InsertedBy, UpdatedDate, UpdatedBy)
VALUES("Cracker", 3, 1, GETUTCDATE(), "Kelly Shaw", null, null);