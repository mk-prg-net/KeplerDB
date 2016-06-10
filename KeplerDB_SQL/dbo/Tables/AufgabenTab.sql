CREATE TABLE [dbo].[AufgabenTab] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [Aufgabenbeschreibung] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

