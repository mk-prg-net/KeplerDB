CREATE TABLE [dbo].[Asteroids] (
    [ID]     INT        NOT NULL,
    [Albedo] FLOAT (53) NOT NULL,
    CONSTRAINT [PK_dbo.Asteroids] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Asteroids_dbo.CelestialBodyBases_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[CelestialBodyBases] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[Asteroids]([ID] ASC);

