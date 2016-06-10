CREATE TABLE [dbo].[LaenderTab] (
    [ID]                 INT            IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (MAX) NOT NULL,
    [Laenderkennzeichen] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

