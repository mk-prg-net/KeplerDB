CREATE TABLE [dbo].[Galaxies] (
    [ID] INT NOT NULL,
    CONSTRAINT [PK_dbo.Galaxies] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Galaxies_dbo.CelestialBodyBases_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[CelestialBodyBases] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[Galaxies]([ID] ASC);

