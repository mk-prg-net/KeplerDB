CREATE FUNCTION [dbo].[EarthMoonMass]
(
)
RETURNS float
AS
BEGIN
		-- Declare the return variable here
	DECLARE @MM float

	-- Add the T-SQL statements to compute the return value here
	SELECT @MM = [Masse_in_kg]
	from [dbo].[HimmelskoerperTab]
	where [Name] = 'Mond'

	-- Return the result of the function
	RETURN @MM
END
