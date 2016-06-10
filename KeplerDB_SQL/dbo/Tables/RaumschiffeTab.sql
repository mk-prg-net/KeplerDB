CREATE TABLE [dbo].[RaumschiffeTab] (
    [Start_der_Mission]     DATETIME NOT NULL,
    [HimmelskoerperID]      INT      NOT NULL,
    [Land_ID]               INT      NOT NULL,
    [RaumschiffAufgaben_ID] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([HimmelskoerperID] ASC),
    CONSTRAINT [FK_RaumschiffeTab_HimmelskoerperTab] FOREIGN KEY ([HimmelskoerperID]) REFERENCES [dbo].[HimmelskoerperTab] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [LandRaumschiffe] FOREIGN KEY ([Land_ID]) REFERENCES [dbo].[LaenderTab] ([ID])
);

