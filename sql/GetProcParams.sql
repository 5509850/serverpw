USE [alexandr_gorbunov]
GO

/****** Object:  StoredProcedure [dbo].[GetProcParams]    Script Date: 01/05/2016 22:43:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[GetProcParams]
	-- Add the parameters for the stored procedure here
	@Name NVarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT p.name AS ParameterName, 
	--t.name AS ParameterType 
	'ParameterType' = 
  CASE 
     WHEN t.name =  'int' THEN '56'
     WHEN t.name =  'datetime' OR t.name =  'smalldatetime'  THEN '58'
     WHEN t.name =  'uniqueidentifier' THEN '36'
     WHEN t.name =  'money' THEN '60'
     WHEN t.name =  'decimal' THEN '108'
     WHEN t.name =  'varchar' OR t.name =  'nvarchar' OR t.name =  'char' OR t.name =  'nchar' THEN '167'
     ELSE '167'
  END
FROM sys.parameters AS p
JOIN sys.types AS t ON t.user_type_id = p.user_type_id
WHERE object_id = OBJECT_ID(@Name)

END

GO


