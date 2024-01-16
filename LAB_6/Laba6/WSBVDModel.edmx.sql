
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/13/2023 23:46:46
-- Generated from EDMX file: D:\Study\ASPLabs\Laba6\Laba6\Laba6\WSSAAModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WSSAA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Note__student_id__3C69FB99]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Note] DROP CONSTRAINT [FK__Note__student_id__3C69FB99];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Note]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Note];
GO
IF OBJECT_ID(N'[dbo].[Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Student];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Note'
CREATE TABLE [dbo].[Note] (
    [id] int  NOT NULL,
    [subj] nchar(10)  NOT NULL,
    [note1] int  NOT NULL,
    [student_id] int  NULL
);
GO

-- Creating table 'Student'
CREATE TABLE [dbo].[Student] (
    [id] int  NOT NULL,
    [Name] nchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Note'
ALTER TABLE [dbo].[Note]
ADD CONSTRAINT [PK_Note]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Student'
ALTER TABLE [dbo].[Student]
ADD CONSTRAINT [PK_Student]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [student_id] in table 'Note'
ALTER TABLE [dbo].[Note]
ADD CONSTRAINT [FK__Note__student_id__3C69FB99]
    FOREIGN KEY ([student_id])
    REFERENCES [dbo].[Student]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Note__student_id__3C69FB99'
CREATE INDEX [IX_FK__Note__student_id__3C69FB99]
ON [dbo].[Note]
    ([student_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------