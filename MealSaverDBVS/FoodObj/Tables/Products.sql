﻿CREATE TABLE [FoodObj].[Products]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL, 
    [Type] NVARCHAR(64) NOT NULL, 
    [Amount(KG)] FLOAT NOT NULL, 
    [UserID] NVARCHAR(450) NOT NULL, 
    [Date] DATE NOT NULL,

)
