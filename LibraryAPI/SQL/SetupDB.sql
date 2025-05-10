-- Create the database
CREATE DATABASE LibraryDB;
GO

USE LibraryDB;
GO

-- Create Authors table
CREATE TABLE Authors (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(255) NOT NULL
);
GO

-- Create Books table
CREATE TABLE Books (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    ContentUrl NVARCHAR(1024),
    AuthorId UNIQUEIDENTIFIER,
    FOREIGN KEY (AuthorId) REFERENCES Authors(Id)
);
GO