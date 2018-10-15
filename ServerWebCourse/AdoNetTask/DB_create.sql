USE [master];

IF EXISTS(SELECT * FROM sys.databases WHERE [name]=N'DargeevDB')
	DROP DATABASE [DargeevDB];

CREATE DATABASE [DargeevDB];
USE [DargeevDB];

CREATE TABLE [dbo].[Category] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Product] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    [CategoryId] INT NOT NULL,
    [Price] INT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);

ALTER TABLE [dbo].[Product]
    ADD CONSTRAINT [FK_Category_Product] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]);

CREATE NONCLUSTERED INDEX [IX_Product] ON [dbo].[Product]
(
	[CategoryId] ASC
);

INSERT INTO [dbo].[Category]([Name])
VALUES (N'beer'), (N'snacks'), (N'shrimps');

INSERT INTO [dbo].[Product]([Name], [CategoryId], [Price])
VALUES (N'Krusovice', 1, 100), (N'Belgian stout', 1, 300), (N'Abakanskoe', 1, 50);

INSERT INTO [dbo].[Product]([Name], [CategoryId], [Price])
VALUES (N'Chips', 2, 30), (N'Salty fish', 2, 40), (N'Kirieshki', 2, 15);

INSERT INTO [dbo].[Product]([Name], [CategoryId], [Price])
VALUES (N'Korolevskie shrimps', 3, 990), (N'Grafskie shrimps', 3, 450);