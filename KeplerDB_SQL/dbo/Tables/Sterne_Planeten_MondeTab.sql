CREATE TABLE [dbo].[Sterne_Planeten_MondeTab] (
    [Aequatordurchmesser_in_km]           FLOAT (53) NOT NULL,
    [Polardurchmesser_in_km]              FLOAT (53) NOT NULL,
    [Oberflaechentemperatur_in_K]         FLOAT (53) NOT NULL,
    [Rotationsperiode_in_Stunden]         FLOAT (53) NOT NULL,
    [Fallbeschleunigung_in_meter_pro_sec] FLOAT (53) NOT NULL,
    [Rotationsachsenneigung_in_Grad]      FLOAT (53) NOT NULL,
    [HimmelskoerperID]                    INT        NOT NULL,
    [Leuchtkraft_in_Lsonne]               FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([HimmelskoerperID] ASC),
    CONSTRAINT [FK_Sterne_Planeten_MondeTab_HimmelskoerperTab] FOREIGN KEY ([HimmelskoerperID]) REFERENCES [dbo].[HimmelskoerperTab] ([ID]) ON DELETE CASCADE
);

