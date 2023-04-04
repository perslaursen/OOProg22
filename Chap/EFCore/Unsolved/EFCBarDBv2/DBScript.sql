
CREATE TABLE [dbo].[Ingredient] (
    [Id]             INT           IDENTITY(1,1)  NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
    [PricePerCl]     INT           NOT NULL,
    [AlcoholPercent] FLOAT (53)    NOT NULL
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

CREATE TABLE [dbo].[Drink] (
    [Id]                     INT           IDENTITY(1,1)  NOT NULL,
    [Name]                   NVARCHAR (50) NOT NULL,
    [AlcoholicPartId]        INT           NULL,
    [AlcoholicPartAmount]    INT           NULL,
    [NonAlcoholicPartId]     INT           NULL,
    [NonAlcoholicPartAmount] INT           NULL
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Drink_Ingredient_Alc] FOREIGN KEY ([AlcoholicPartId]) REFERENCES [dbo].[Ingredient] ([Id]),
    CONSTRAINT [FK_Drink_Ingredient_NonAlc] FOREIGN KEY ([NonAlcoholicPartId]) REFERENCES [dbo].[Ingredient] ([Id])
);

GO


INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Rum', 15, 40)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Vodka', 15, 40)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Gin', 15, 40)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Triple Sec', 20, 30)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Cola', 1, 0)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Lime Juice', 2, 0)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Cranberry Juice', 2, 0)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Ginger Beer', 2, 4)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Mineral Water', 1, 0)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Fanta', 1, 0)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Sprite', 1, 0)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Lemon', 1, 0)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Tonic', 2, 0)
INSERT INTO [dbo].[Ingredient] ([Name], [PricePerCl], [AlcoholPercent]) VALUES (N'Whiskey', 20, 45)

GO

INSERT INTO [dbo].[Drink] ([Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (N'Cuba Libre', 1, 3, 5, 20)
INSERT INTO [dbo].[Drink] ([Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (N'Russia Libre', 2, 3, 5, 20)
INSERT INTO [dbo].[Drink] ([Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (N'The Day After', NULL, NULL, 9, 20)
INSERT INTO [dbo].[Drink] ([Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (N'Red Mule', 2, 3, 10, 3)
INSERT INTO [dbo].[Drink] ([Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (N'Double Straight', 14, 6, NULL, NULL)
INSERT INTO [dbo].[Drink] ([Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (N'Pearly Temple', NULL, NULL, 11, 20)
INSERT INTO [dbo].[Drink] ([Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (N'High Spirit', 2, 6, 11, 20)
INSERT INTO [dbo].[Drink] ([Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (N'Watered down', 14, 3, 9, 3)
INSERT INTO [dbo].[Drink] ([Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (N'Carribean Gold', 1, 6, 10, 20)
INSERT INTO [dbo].[Drink] ([Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (N'Siberian Zone', 2, 6, NULL, NULL)

GO


