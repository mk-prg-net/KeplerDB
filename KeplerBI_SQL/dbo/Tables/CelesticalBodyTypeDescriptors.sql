CREATE TABLE [dbo].[CelesticalBodyTypeDescriptors] (
    [Type] INT            NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.CelesticalBodyTypeDescriptors] PRIMARY KEY CLUSTERED ([Type] ASC)
);

