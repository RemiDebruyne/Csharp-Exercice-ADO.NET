CREATE DATABASE exerciceCommandes;
GO

CREATE TABLE [dbo].[clients]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[prenom] VARCHAR(50) NOT NULL,
	[nom] VARCHAR(50) NOT NULL,
	[adresse] VARCHAR(50) NOT NULL,
	[cp] VARCHAR(50) NOT NULL,
	[ville] VARCHAR(50) NOT NULL,
	[telephone] VARCHAR(50) NOT NULL,
);
GO

CREATE TABLE [dbo].[commandes]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[client_id] INT, 
	[date] DATETIME NOT NULL,
	[total] DEC,
	CONSTRAINT FK_commande_client_id FOREIGN KEY([client_id]) REFERENCES clients(id)
);
GO