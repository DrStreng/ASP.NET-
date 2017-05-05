
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/11/2016 16:59:57
-- Generated from EDMX file: C:\Users\Strengol\Documents\Visual Studio 2015\Projects\WebApp\WebApp\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyDbUser];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RaidLokacja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Raid] DROP CONSTRAINT [FK_RaidLokacja];
GO
IF OBJECT_ID(N'[dbo].[FK_TypRaid]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Raid] DROP CONSTRAINT [FK_TypRaid];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Lokacja]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lokacja];
GO
IF OBJECT_ID(N'[dbo].[Raid]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Raid];
GO
IF OBJECT_ID(N'[dbo].[Table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table];
GO
IF OBJECT_ID(N'[dbo].[Typ]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Typ];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Lokacja'
CREATE TABLE [dbo].[Lokacja] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nazwa] varchar(max)  NOT NULL
);
GO

-- Creating table 'Raid'
CREATE TABLE [dbo].[Raid] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nazwa] varchar(max)  NOT NULL,
    [LokacjaId] int  NOT NULL,
    [TypId] int  NOT NULL
);
GO

-- Creating table 'Table'
CREATE TABLE [dbo].[Table] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] varchar(max)  NOT NULL,
    [Email] varchar(max)  NOT NULL,
    [Password] varchar(max)  NOT NULL,
    [Role] varchar(max)  NOT NULL
);
GO

-- Creating table 'Typ'
CREATE TABLE [dbo].[Typ] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nazwa] varchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Lokacja'
ALTER TABLE [dbo].[Lokacja]
ADD CONSTRAINT [PK_Lokacja]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Raid'
ALTER TABLE [dbo].[Raid]
ADD CONSTRAINT [PK_Raid]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Table'
ALTER TABLE [dbo].[Table]
ADD CONSTRAINT [PK_Table]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Typ'
ALTER TABLE [dbo].[Typ]
ADD CONSTRAINT [PK_Typ]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LokacjaId] in table 'Raid'
ALTER TABLE [dbo].[Raid]
ADD CONSTRAINT [FK_RaidLokacja]
    FOREIGN KEY ([LokacjaId])
    REFERENCES [dbo].[Lokacja]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RaidLokacja'
CREATE INDEX [IX_FK_RaidLokacja]
ON [dbo].[Raid]
    ([LokacjaId]);
GO

-- Creating foreign key on [TypId] in table 'Raid'
ALTER TABLE [dbo].[Raid]
ADD CONSTRAINT [FK_TypRaid]
    FOREIGN KEY ([TypId])
    REFERENCES [dbo].[Typ]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypRaid'
CREATE INDEX [IX_FK_TypRaid]
ON [dbo].[Raid]
    ([TypId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------