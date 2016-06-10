CREATE TABLE [dbo].[Stars] (
    [ID]                          INT        NOT NULL,
    [SpectralClass]               INT        NOT NULL,
    [LuminosityInMulitiplesOfSun] FLOAT (53) NOT NULL,
    CONSTRAINT [PK_dbo.Stars] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Stars_dbo.CelestialBodyBases_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[CelestialBodyBases] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[Stars]([ID] ASC);

