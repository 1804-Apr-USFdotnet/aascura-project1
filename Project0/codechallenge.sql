CREATE DATABASE code_challenge;
GO

USE code_challenge;
GO

CREATE SCHEMA [User];
GO

CREATE SCHEMA [Content];
GO

CREATE TABLE [User].[user] 
( id			INT PRIMARY KEY IDENTITY(0,1)
, username		CHAR(32)	UNIQUE NOT NULL
, [password]	CHAR(32)	NOT NULL
, joinDate		DATETIME2		NOT NULL	
);

CREATE TABLE [Content].[comments]
( id			INT PRIMARY KEY IDENTITY (0,1)
, commentText	NVARCHAR(MAX) NOT NULL
, userId		INT FOREIGN KEY REFERENCES [User].[user](id) NOT NULL
, [dateTime]	DATETIME2	NOT NULL
);

INSERT INTO [User].[user] (username, [password], joinDate) VALUES
('MasterBlaster','Unsafe Password',GETDATE()),
('BobSaget', 'password', GETDATE()),
('NotAGovtAgent', 'bR52[Fsg5m02pQvZ', GETDATE());

INSERT INTO [Content].[comments] (commentText, userId, dateTime) VALUES
('man i love the internet', (SELECT id FROM [User].[user] WHERE [username] = 'MasterBlaster'), GETDATE()),
('Yes, I too love the internet.  Tell me of your doings.', (SELECT id FROM [User].[user] WHERE [username] = 'NotAGovtAgent'), GETDATE()),
('I think we may have a plant', (SELECT id FROM [User].[user] WHERE [username] = 'BobSaget'), GETDATE()),
('whoa are u the real bob saget', (SELECT id FROM [User].[user] WHERE [username] = 'MasterBlaster'), GETDATE())
;

SELECT * FROM [Content].[comments];

SELECT * FROM [Content].comments WHERE userId = (SELECT id FROM [User].[user] WHERE username = 'NotAGovtAgent');

UPDATE [User].[user]
SET username = 'RickAstley' WHERE username = 'BobSaget';

INSERT INTO [Content].[comments] (commentText, userId, dateTime) VALUES
('You must be mistaken.', (SELECT id FROM [User].[user] WHERE [username] = 'RickAstley'), GETDATE());