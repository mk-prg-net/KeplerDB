CREATE TABLE [dbo].[CelestialBodyBases] (
    [ID]                            INT            IDENTITY (1, 1) NOT NULL,
    [Type]                          INT            NOT NULL,
    [Name]                          NVARCHAR (MAX) NULL,
    [MassInEarthmasses]             FLOAT (53)     NULL,
    [MeanSurfaceTemp]               FLOAT (53)     NULL,
    [GravityInMeterPerSec]          FLOAT (53)     NULL,
    [PolarDiameterInKilometer]      FLOAT (53)     NULL,
    [EquatorialDiameterInKilometer] FLOAT (53)     NULL,
    [Discriminator]                 NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.CelestialBodyBases] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.CelestialBodyBases_dbo.CelesticalBodyTypeDescriptors_Type] FOREIGN KEY ([Type]) REFERENCES [dbo].[CelesticalBodyTypeDescriptors] ([Type])
);


GO
CREATE NONCLUSTERED INDEX [IX_Type]
    ON [dbo].[CelestialBodyBases]([Type] ASC);

