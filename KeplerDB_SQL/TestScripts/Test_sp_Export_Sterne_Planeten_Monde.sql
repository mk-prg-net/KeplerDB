USE [KeplerDB]
GO

DECLARE	@return_value int,
		@Success bit,
		@ErrMsg nvarchar(max),
		@res xml ---(max)

EXEC	@return_value = [dbo].[sp_Export_Sterne_Planeten_Monde]
		@Success = @Success OUTPUT,
		@ErrMsg = @ErrMsg OUTPUT,
		@res = @res OUTPUT

SELECT	@Success as N'@Success',
		@ErrMsg as N'@ErrMsg',
		@res as N'@res'

SELECT	'Return Value' = @return_value

GO