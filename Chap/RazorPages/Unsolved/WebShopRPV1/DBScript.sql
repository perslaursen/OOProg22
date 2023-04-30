
CREATE TABLE [dbo].[Customer] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [Email]   NVARCHAR (MAX) NOT NULL,
    [Address] NVARCHAR (MAX) NOT NULL
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

CREATE TABLE [dbo].[Product] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (MAX) NOT NULL,
    [Price] FLOAT (53)     NOT NULL
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

CREATE TABLE [dbo].[Order] (
    [Id]         INT           IDENTITY(1,1)  NOT NULL,
    [CustomerId] INT NOT NULL,
    [ProductId]  INT NOT NULL,
    [Amount]     INT NOT NULL
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_Order_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

GO

CREATE TABLE [dbo].[User] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

INSERT INTO [dbo].[Product] ([Name], [Price]) VALUES (N'Mouse std', 155)
INSERT INTO [dbo].[Product] ([Name], [Price]) VALUES (N'Mat', 275)
INSERT INTO [dbo].[Product] ([Name], [Price]) VALUES (N'Keyboard', 450)
INSERT INTO [dbo].[Product] ([Name], [Price]) VALUES (N'Wide 43" Monitor', 6500)
INSERT INTO [dbo].[Product] ([Name], [Price]) VALUES (N'Gaming Laptop', 11950)

GO

INSERT INTO [dbo].[Customer] ([Name], [Email], [Address]) VALUES (N'Anne', N'anne@mail.dk', N'Annevej 56')
INSERT INTO [dbo].[Customer] ([Name], [Email], [Address]) VALUES (N'Bent', N'bent@mail.dk', N'Bentvej 47')
INSERT INTO [dbo].[Customer] ([Name], [Email], [Address]) VALUES (N'Curt', N'curt@mail.dk', N'Curtvej 11')
INSERT INTO [dbo].[Customer] ([Name], [Email], [Address]) VALUES (N'Dina', N'dina@mail.dk', N'Dinavej 80')

GO

INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (2, 5, 4)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (4, 4, 8)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (3, 1, 2)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (4, 2, 12)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (1, 3, 4)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (1, 3, 6)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (2, 1, 15)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (2, 3, 2)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (1, 1, 5)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (1, 2, 2)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (4, 1, 4)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (3, 4, 8)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (2, 5, 6)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (4, 3, 3)
INSERT INTO [dbo].[Order] ([CustomerId], [ProductId], [Amount]) VALUES (2, 2, 2)

GO