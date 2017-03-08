-- =============================================
-- Author:		Martin Korneffel
-- Create date: 2.12.2014
-- Description:	Liefert die Erdmasse
-- =============================================
CREATE FUNCTION [dbo].[Erdmasse] 
(
	-- Add the parameters for the function here
	
)
RETURNS float
AS
BEGIN
	-- Declare the return variable here
	DECLARE @EM float

	-- Add the T-SQL statements to compute the return value here
	SELECT @EM = [Masse_in_kg]
	from [dbo].[HimmelskoerperTab]
	where [Name] = 'Erde'

	-- Return the result of the function
	RETURN @EM

END
GO