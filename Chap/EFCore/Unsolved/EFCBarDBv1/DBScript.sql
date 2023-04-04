
CREATE TABLE [dbo].[DrinkFlat] (
    [Id]                     INT           IDENTITY(1,1)  NOT NULL,
    [Name]                   NVARCHAR (50) NOT NULL,
    [AlcoholicPart]          NVARCHAR (50) NOT NULL,
    [AlcoholicPartAmount]    INT           NOT NULL,
    [NonAlcoholicPart]       NVARCHAR (50) NOT NULL,
    [NonAlcoholicPartAmount] INT           NOT NULL
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

INSERT INTO [dbo].[DrinkFlat] ([Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (N'Cuba Libre', N'Rum', 3, N'Cola', 20)
INSERT INTO [dbo].[DrinkFlat] ([Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (N'Russia Libre', N'Vodka', 3, N'Cola', 20)
INSERT INTO [dbo].[DrinkFlat] ([Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (N'The Day After', N'None', 0, N'Water', 20)
INSERT INTO [dbo].[DrinkFlat] ([Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (N'Red Mule', N'Vodka', 3, N'Fanta', 20)
INSERT INTO [dbo].[DrinkFlat] ([Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (N'Double Straight', N'Whiskey', 6, N'None', 0)
INSERT INTO [dbo].[DrinkFlat] ([Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (N'Pearly Temple', N'None', 0, N'Sprite', 20)
INSERT INTO [dbo].[DrinkFlat] ([Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (N'High Spirit', N'Vodka', 6, N'Sprite', 20)
INSERT INTO [dbo].[DrinkFlat] ([Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (N'Watered Down', N'Whiskey', 3, N'Water', 3)
INSERT INTO [dbo].[DrinkFlat] ([Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (N'Carribean Gold', N'Rum', 6, N'Fanta', 20)
INSERT INTO [dbo].[DrinkFlat] ([Name], [AlcoholicPart], [AlcoholicPartAmount], [NonAlcoholicPart], [NonAlcoholicPartAmount]) VALUES (N'Siberian Zone', N'Vodka', 6, N'None', 0)
