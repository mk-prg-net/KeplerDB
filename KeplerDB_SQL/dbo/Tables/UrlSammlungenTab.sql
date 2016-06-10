CREATE TABLE [dbo].[UrlSammlungenTab] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [Kurzbeschreibung]  NVARCHAR (MAX) NOT NULL,
    [Url]               NVARCHAR (MAX) NOT NULL,
    [UrlTyp]            INT            NOT NULL,
    [Himmelskoerper_ID] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [HimmelskoerperUrlSammlung] FOREIGN KEY ([Himmelskoerper_ID]) REFERENCES [dbo].[HimmelskoerperTab] ([ID])
);

