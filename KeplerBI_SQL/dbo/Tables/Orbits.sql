CREATE TABLE [dbo].[Orbits] (
    [SatelliteId]                         INT        NOT NULL,
    [CentralBodyId]                       INT        NOT NULL,
    [SemiMajorAxisInKilometer]            FLOAT (53) NOT NULL,
    [MeanVelocitiOfCirculationInKmPerSec] FLOAT (53) NOT NULL,
    CONSTRAINT [PK_dbo.Orbits] PRIMARY KEY CLUSTERED ([SatelliteId] ASC),
    CONSTRAINT [FK_dbo.Orbits_dbo.CelestialBodyBases_CentralBodyId] FOREIGN KEY ([CentralBodyId]) REFERENCES [dbo].[CelestialBodyBases] ([ID]),
    CONSTRAINT [FK_dbo.Orbits_dbo.CelestialBodyBases_SatelliteId] FOREIGN KEY ([SatelliteId]) REFERENCES [dbo].[CelestialBodyBases] ([ID]),
    CONSTRAINT [FK_dbo.Orbits_dbo.CelesticalBodySystems_CentralBodyId] FOREIGN KEY ([CentralBodyId]) REFERENCES [dbo].[CelesticalBodySystems] ([CentralBodyId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SatelliteId]
    ON [dbo].[Orbits]([SatelliteId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CentralBodyId]
    ON [dbo].[Orbits]([CentralBodyId] ASC);

