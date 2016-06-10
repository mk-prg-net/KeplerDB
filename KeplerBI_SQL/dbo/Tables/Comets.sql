CREATE TABLE [dbo].[Comets] (
    [ID] INT NOT NULL,
    CONSTRAINT [PK_dbo.Comets] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Comets_dbo.CelestialBodyBases_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[CelestialBodyBases] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[Comets]([ID] ASC);

