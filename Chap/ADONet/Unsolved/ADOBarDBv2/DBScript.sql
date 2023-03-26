
CREATE TABLE [dbo].[Drink] (
    [Id]                     INT           NOT NULL,
    [Name]                   NVARCHAR (50) NOT NULL,
    [AlcoholicPartId]        INT           NULL,
    [AlcoholicPartAmount]    INT           NULL,
    [NonAlcoholicPartId]     INT           NULL,
    [NonAlcoholicPartAmount] INT           NULL
);

CREATE TABLE [dbo].[Ingredient] (
    [Id]             INT           NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
    [PricePerCl]     INT           NOT NULL,
    [AlcoholPercent] FLOAT (53)    NOT NULL
);

INSERT INTO [dbo].[Drink] ([Id], [Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (1, N'Cuba Libre', 1, 3, 5, 20)
INSERT INTO [dbo].[Drink] ([Id], [Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (2, N'Russia Libre', 2, 3, 5, 20)
INSERT INTO [dbo].[Drink] ([Id], [Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (3, N'The Day After', NULL, NULL, 9, 20)
INSERT INTO [dbo].[Drink] ([Id], [Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (4, N'Red Mule', 2, 3, 10, 3)
INSERT INTO [dbo].[Drink] ([Id], [Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (5, N'Double Straight', 14, 6, NULL, NULL)
INSERT INTO [dbo].[Drink] ([Id], [Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (6, N'Pearly Temple', NULL, NULL, 11, 20)
INSERT INTO [dbo].[Drink] ([Id], [Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (7, N'High Spirit', 2, 6, 11, 20)
INSERT INTO [dbo].[Drink] ([Id], [Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (8, N'Watered down', 14, 3, 9, 3)
INSERT INTO [dbo].[Drink] ([Id], [Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (9, N'Carribean Gold', 1, 6, 10, 20)
INSERT INTO [dbo].[Drink] ([Id], [Name], [AlcoholicPartId], [AlcoholicPartAmount], [NonAlcoholicPartId], [NonAlcoholicPartAmount]) VALUES (10, N'Siberian Zone', 2, 6, NULL, NULL)

INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (1, N'Rum', 15, 40)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (2, N'Vodka', 15, 40)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (3, N'Gin', 15, 40)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (4, N'Triple Sec', 20, 30)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (5, N'Cola', 1, 0)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (6, N'Lime Juice', 2, 0)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (7, N'Cranberry Juice', 2, 0)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (8, N'Ginger Beer', 2, 4)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (9, N'Mineral Water', 1, 0)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (10, N'Fanta', 1, 0)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (11, N'Sprite', 1, 0)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (12, N'Lemon', 1, 0)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (13, N'Tonic', 2, 0)
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [PricePerCl], [AlcoholPercent]) VALUES (14, N'Whiskey', 20, 45)




