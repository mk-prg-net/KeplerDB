CREATE TABLE [dbo].[Moons] (
    [ID] INT NOT NULL,
    CONSTRAINT [PK_dbo.Moons] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Moons_dbo.CelestialBodyBases_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[CelestialBodyBases] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[Moons]([ID] ASC);

