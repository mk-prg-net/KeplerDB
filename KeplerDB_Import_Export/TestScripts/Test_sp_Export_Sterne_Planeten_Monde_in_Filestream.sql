USE [KeplerDB_Import_Export]
GO

DECLARE @Success bit
DECLARE @ErrMsg nvarchar(max)

-- TODO: Set parameter values here.

EXECUTE [dbo].[sp_Export_Sterne_Planeten_Monde_To_Filestream] 
   @Success OUTPUT
  ,@ErrMsg OUTPUT

  Select @Success, @ErrMsg
GO
