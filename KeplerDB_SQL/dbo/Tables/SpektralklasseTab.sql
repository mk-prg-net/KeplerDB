CREATE TABLE [dbo].[SpektralklasseTab] (
    [ID]                                     INT            NOT NULL,
    [Name]                                   NVARCHAR (MAX) NOT NULL,
    [Farbe]                                  NVARCHAR (MAX) NOT NULL,
    [Tmin]                                   FLOAT (53)     NOT NULL,
    [Tmax]                                   FLOAT (53)     NOT NULL,
    [Masse_Hauptreihenstern_in_Sonnenmassen] FLOAT (53)     NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

