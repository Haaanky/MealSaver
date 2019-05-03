CREATE TABLE [FoodObj].[ContactForm]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(64) NULL, 
    [Email] NVARCHAR(64) NOT NULL, 
    [Question] NVARCHAR(MAX) NOT NULL
)
