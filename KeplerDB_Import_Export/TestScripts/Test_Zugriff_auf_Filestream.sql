use KeplerDB_Import_Export
go

DECLARE @root nvarchar(100);
DECLARE @fullpath nvarchar(1000);

SELECT @root = FileTableRootPath();

SELECT name, [file_stream].GetFileNamespacePath(), [file_stream]
    FROM [dbo].[Bildergalerie]


insert into [dbo].[Bildergalerie]([name], file_stream)
values('MyTxt.txt', Cast('HAllo Welt' as varbinary(max)))