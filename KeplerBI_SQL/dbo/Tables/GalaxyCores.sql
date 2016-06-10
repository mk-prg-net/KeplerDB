CREATE TABLE [dbo].[GalaxyCores] (
    [ID] INT NOT NULL,
    CONSTRAINT [PK_dbo.GalaxyCores] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.GalaxyCores_dbo.CelestialBodyBases_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[CelestialBodyBases] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[GalaxyCores]([ID] ASC);

