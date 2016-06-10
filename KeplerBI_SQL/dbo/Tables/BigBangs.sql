CREATE TABLE [dbo].[BigBangs] (
    [ID] INT NOT NULL,
    CONSTRAINT [PK_dbo.BigBangs] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.BigBangs_dbo.CelestialBodyBases_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[CelestialBodyBases] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[BigBangs]([ID] ASC);

