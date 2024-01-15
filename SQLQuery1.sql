-- on se positionne sur la base données
Use contactDB;
GO

-- Création de la table personnes
CREATE TABLE personnes (
	id INT IDENTITY(1,1) PRIMARY KEY,
	prenom VARCHAR(50) NOT NULL,
	nom VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL
);
GO

INSERT INTO 
	personnes (prenom, nom, email)
VALUES
	('emanuelle','Macron','manumicron@gmail.com');
GO

SELECT * FROM personnes;