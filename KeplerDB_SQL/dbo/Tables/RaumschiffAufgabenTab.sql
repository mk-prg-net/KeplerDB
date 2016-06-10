CREATE TABLE [dbo].[RaumschiffAufgabenTab] (
    [Aufgaben_ID]                  INT NOT NULL,
    [Raumschiffe_HimmelskoerperID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Aufgaben_ID] ASC, [Raumschiffe_HimmelskoerperID] ASC),
    CONSTRAINT [FK_RaumschiffAufgabenTab_AufgabenTab] FOREIGN KEY ([Aufgaben_ID]) REFERENCES [dbo].[AufgabenTab] ([ID]),
    CONSTRAINT [FK_RaumschiffAufgabenTab_RaumschiffeTab] FOREIGN KEY ([Raumschiffe_HimmelskoerperID]) REFERENCES [dbo].[RaumschiffeTab] ([HimmelskoerperID])
);

