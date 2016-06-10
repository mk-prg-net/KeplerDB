CREATE TABLE [dbo].[UmlaufbahnenTab] (
    [Laenge_grosse_Halbachse_in_km]                FLOAT (53) NOT NULL,
    [Exzentritzitaet]                              FLOAT (53) NOT NULL,
    [Umlaufdauer_in_Tagen]                         FLOAT (53) NOT NULL,
    [Mittlere_Umlaufgeschwindigkeit_in_km_pro_sec] FLOAT (53) NOT NULL,
    [TrabantID]                                    INT        NOT NULL,
    [Zentralobjekt_ID]                             INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([TrabantID] ASC),
    CONSTRAINT [TrabantUmlaufbahn] FOREIGN KEY ([TrabantID]) REFERENCES [dbo].[HimmelskoerperTab] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [UmlaufbahnZentralobjekt] FOREIGN KEY ([Zentralobjekt_ID]) REFERENCES [dbo].[HimmelskoerperTab] ([ID])
);

