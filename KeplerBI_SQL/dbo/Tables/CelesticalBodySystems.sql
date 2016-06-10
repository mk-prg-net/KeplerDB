CREATE TABLE [dbo].[CelesticalBodySystems] (
    [CentralBodyId] INT NOT NULL,
    CONSTRAINT [PK_dbo.CelesticalBodySystems] PRIMARY KEY CLUSTERED ([CentralBodyId] ASC),
    CONSTRAINT [FK_dbo.CelesticalBodySystems_dbo.CelestialBodyBases_CentralBodyId] FOREIGN KEY ([CentralBodyId]) REFERENCES [dbo].[CelestialBodyBases] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_CentralBodyId]
    ON [dbo].[CelesticalBodySystems]([CentralBodyId] ASC);

