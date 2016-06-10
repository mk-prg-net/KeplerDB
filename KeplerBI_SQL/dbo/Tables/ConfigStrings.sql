CREATE TABLE [dbo].[ConfigStrings]
(
	Name nvarchar(128),
	Value nvarchar(max),
    CONSTRAINT [PK_dbo.ConfigString] PRIMARY KEY CLUSTERED ([Name] ASC),
)


