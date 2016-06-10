-- mko, 6.6.2016
-- Liefert den Abstand Erde Sonne in Metern gemessen. Wird als eine astronomische 
-- Einheit bezeichnet
CREATE FUNCTION [dbo].[AU]
(	
)
RETURNS float
AS
BEGIN
	RETURN  149597870700.0
END
