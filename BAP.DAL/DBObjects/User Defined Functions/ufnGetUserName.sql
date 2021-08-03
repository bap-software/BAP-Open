-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Victor Mamray
-- Create date: 03/25/2016
-- Description:	Returns user name by ID
-- =============================================
CREATE FUNCTION ufnGetUserName 
(
	@UserId nvarchar(128)
)
RETURNS nvarchar(256)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result nvarchar(256)

	-- Add the T-SQL statements to compute the return value here
	SELECT @result = UserName FROM [dbo].[AspNetUsers] WHERE Id = @UserId

	-- Return the result of the function
	RETURN @result

END
GO

