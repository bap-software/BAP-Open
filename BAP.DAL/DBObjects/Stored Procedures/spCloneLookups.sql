/****** Object:  StoredProcedure [dbo].[spCloneLookups]    Script Date: 11/28/2016 8:28:21 PM ******/
DROP PROCEDURE [dbo].[spCloneLookups]
GO

/****** Object:  StoredProcedure [dbo].[spCloneLookups]    Script Date: 11/28/2016 8:28:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Victor Mamray
-- Create date: 11/27/2016
-- Description:	Clone dictionaries from source organization to target one
-- =============================================
CREATE PROCEDURE [dbo].[spCloneLookups] 
	-- Add the parameters for the stored procedure here
	@sourceOrgId int
	,@targetOrgId int
	,@userId nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
   
	INSERT INTO [dbo].[Lookup] ([Name],[Description],[TenantUnit],[TenantUnitId],[CreateDate],[CreatedBy],[LastModifiedDate],[LastModifiedBy],[LookupType],[IntRangeFrom],[IntRangeTo],[FloatRangeFrom],[FloatRangeTo],[FloatRangeStep],[DateRangeFrom],[DateRangeTo],[RangePrefix],[EntityName],[EntityValueField],[EntityNameField],[EntityFilter],[EntityOrderBy],[ParentLookup_Id],[EntityAssembly],[EntityClass],[OwnerGroup],[OwnerPermissions])
	SELECT
          [Name]
           ,[Description]
           ,'Organization' as [TenantUnit]
           ,@targetOrgId as [TenantUnitId]
           ,GETDATE() as [CreateDate]
           ,@userId as [CreatedBy]
           ,GETDATE() as [LastModifiedDate]
           ,@userId as [LastModifiedBy]
           ,[LookupType]
           ,[IntRangeFrom]
           ,[IntRangeTo]
           ,[FloatRangeFrom]
           ,[FloatRangeTo]
           ,[FloatRangeStep]
           ,[DateRangeFrom]
           ,[DateRangeTo]
           ,[RangePrefix]
           ,[EntityName]
           ,[EntityValueField]
           ,[EntityNameField]
           ,[EntityFilter]
           ,[EntityOrderBy]
           ,[ParentLookup_Id]
           ,[EntityAssembly]
           ,[EntityClass]
           ,[OwnerGroup]
           ,[OwnerPermissions]
	FROM 
		[dbo].[Lookup]
	WHERE 
		[TenantUnit] = 'Organization'
		AND [TenantUnitId] = @sourceOrgId
	
	
	INSERT INTO [dbo].[LookupValue] ([Key],[Text],[Description],[CultureCode],[Order],[TenantUnit],[TenantUnitId],[CreateDate],[CreatedBy],[LastModifiedDate],[LastModifiedBy],[Parent_Id],[ParentKey],[OwnerGroup],[OwnerPermissions])
	SELECT
           L1.[Key]
           ,L1.[Text]
           ,L1.[Description]
           ,L1.[CultureCode]
           ,L1.[Order]
           ,'Organization' as [TenantUnit]
           ,@targetOrgId as [TenantUnitId]
           ,GETDATE() as [CreateDate]
           ,@userId as [CreatedBy]
           ,GETDATE() as [LastModifiedDate]
           ,@userId as [LastModifiedBy]
           ,(SELECT TOP 1 AL2.Id FROM [dbo].[Lookup] AL1 INNER JOIN [dbo].[Lookup] AL2 ON AL1.Name = AL2.Name WHERE AL1.TenantUnit = 'Organization' AND AL1.TenantUnitId = @sourceOrgId AND AL2.TenantUnit = 'Organization' AND AL2.TenantUnitId = @targetOrgId AND AL1.Id = L1.Parent_Id) as Parent_Id
           ,L1.[ParentKey]
           ,L1.[OwnerGroup]
           ,L1.[OwnerPermissions]
    FROM
		[dbo].[LookupValue] L1
	WHERE
		L1.[TenantUnit] = 'Organization'
		AND L1.[TenantUnitId] = @sourceOrgId

	

END

GO


