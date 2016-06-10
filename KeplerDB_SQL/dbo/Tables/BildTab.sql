CREATE TABLE [dbo].[BildTab] (
    [HimmelskoerperID]  INT             IDENTITY (1, 1) NOT NULL,
    [Bilddaten]         VARBINARY (MAX) NOT NULL,
    [Himmelskoerper_ID] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([HimmelskoerperID] ASC),
    CONSTRAINT [HimmelskoerperBild] FOREIGN KEY ([Himmelskoerper_ID]) REFERENCES [dbo].[HimmelskoerperTab] ([ID])
);

