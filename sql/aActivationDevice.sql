USE [alexandr_gorbunov]
GO

/****** Object:  StoredProcedure [dbo].[aActivationDevice]    Script Date: 01/07/2016 23:08:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE  [dbo].[aActivationDevice]
	-- Add the parameters for the stored procedure here
	@deviceID bigint,
	@TypeDeviceID int,
	@Token nvarchar(512),
    @AndroidID  nvarchar(50),    
    @Macaddress nvarchar(50),     
    @ipAdress   nvarchar(50),  
    @version  nchar(10) 
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @counts int
	set @counts = 0
	
/*-1 deviceID not found
-2 AndroidID not valid
-3 appversion is old - need update from google play or site*/
	SELECT TOP 1 @counts = count(*)  FROM [dbo].[aConfig] where [ver] = @version
	if @counts = 0 
	begin
		SELECT -3 as 'result'
		return 0;
	end
	---------------------------------
	SELECT TOP 1 @counts = count(*) FROM [dbo].[aDevice] where [deviceID] = @deviceID
	if @counts = 0 
	begin
		SELECT -1 as 'result'
		return 0;
	end
	
	SELECT TOP 1 @counts = count(*) FROM [dbo].[aDevice] where AndroidIDMacaddress = @AndroidID
	if @counts = 0 
	begin
		SELECT -2 as 'result'
		return 0;
	end
	
	UPDATE [dbo].[aDevice] 	SET [isActive] = 1, [version] = @version WHERE  [deviceID] = @deviceID
	SELECT 0 as 'result'
END

GO


