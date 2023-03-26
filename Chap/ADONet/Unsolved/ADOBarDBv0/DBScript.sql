
CREATE TABLE [dbo].[DrinkFlat] (
    [Id]                     INT           NOT NULL,
    [Name]                   NVARCHAR (50) NOT NULL,
    [AlcoholicPart]          NVARCHAR (50) NOT NULL,
    [AlcoholicPartAmount]    INT           NOT NULL,
    [NonAlcoholicPart]       NVARCHAR (50) NOT NULL,
    [NonAlcoholicPartAmount] INT           NOT NULL
);

INSERT INTO [dbo].[DrinkFlat] ([Id], [Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (1, N'Cuba Libre', N'Rum', 3, N'Cola', 20)
INSERT INTO [dbo].[DrinkFlat] ([Id], [Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (2, N'Russia Libre', N'Vodka', 3, N'Cola', 20)
INSERT INTO [dbo].[DrinkFlat] ([Id], [Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (3, N'The Day After', N'None', 0, N'Water', 20)
INSERT INTO [dbo].[DrinkFlat] ([Id], [Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (4, N'Red Mule', N'Vodka', 3, N'Fanta', 20)
INSERT INTO [dbo].[DrinkFlat] ([Id], [Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (5, N'Double Straight', N'Whiskey', 6, N'None', 0)
INSERT INTO [dbo].[DrinkFlat] ([Id], [Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (6, N'Pearly Temple', N'None', 0, N'Sprite', 20)
INSERT INTO [dbo].[DrinkFlat] ([Id], [Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (7, N'High Spirit', N'Vodka', 6, N'Sprite', 20)
INSERT INTO [dbo].[DrinkFlat] ([Id], [Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (8, N'Watered Down', N'Whiskey', 3, N'Water', 3)
INSERT INTO [dbo].[DrinkFlat] ([Id], [Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (9, N'Carribean Gold', N'Rum', 6, N'Fanta', 20)
INSERT INTO [dbo].[DrinkFlat] ([Id], [Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (10, N'Siberian Zone', N'Vodka', 6, N'None', 0)
