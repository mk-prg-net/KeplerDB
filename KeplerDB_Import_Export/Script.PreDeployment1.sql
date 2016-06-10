/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

--USE master;
--GO
---- Get the SQL Server data path.
--DECLARE @data_path nvarchar(256);
--SET @data_path = (SELECT SUBSTRING(physical_name, 1, CHARINDEX(N'master.mdf', LOWER(physical_name)) - 1)
--                  FROM master.sys.master_files
--                  WHERE database_id = 1 AND file_id = 1);

-- -- Execute the CREATE DATABASE statement. 
--ALTER DATABASE KeplerDB_Import_Export ADD FILEGROUP fg1 CONTAINS FILESTREAM 
--go


--alter database KeplerDB_Import_Export add file ( NAME = 'fsYourDatabase', FILENAME = 'c:\KeplerIE\fs1') to filegroup fg1;
--go
