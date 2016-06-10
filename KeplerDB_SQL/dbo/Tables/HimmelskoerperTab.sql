CREATE TABLE [dbo].[HimmelskoerperTab] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (MAX) NOT NULL,
    [Masse_in_kg]          FLOAT (53)     NOT NULL,
    [HimmelskoerperTyp_ID] INT            NOT NULL,
    [SpektralklasseId]     INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [HimmelskoerperHimmelskoerperTyp] FOREIGN KEY ([HimmelskoerperTyp_ID]) REFERENCES [dbo].[HimmelskoerperTypenTab] ([ID]),
    CONSTRAINT [HimmelskoerperSpektralklasse] FOREIGN KEY ([SpektralklasseId]) REFERENCES [dbo].[SpektralklasseTab] ([ID])
);

