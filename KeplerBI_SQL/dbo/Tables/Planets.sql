CREATE TABLE [dbo].[Planets] (
    [ID]       INT NOT NULL,
    [HasRings] BIT NOT NULL,
    CONSTRAINT [PK_dbo.Planets] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Planets_dbo.CelestialBodyBases_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[CelestialBodyBases] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[Planets]([ID] ASC);

