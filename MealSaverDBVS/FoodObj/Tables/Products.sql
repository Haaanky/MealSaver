CREATE TABLE [FoodObj].[Products]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL, 
    [Type] NVARCHAR(64) NOT NULL, 
    [Amount] FLOAT NOT NULL, 
    [UnitOfMeasurement] NVARCHAR(16) NOT NULL,
    [Date] DATETIME NOT NULL, 
    [UserID] NVARCHAR(450) REFERENCES dbo.AspNetUsers(Id) NOT NULL
)
