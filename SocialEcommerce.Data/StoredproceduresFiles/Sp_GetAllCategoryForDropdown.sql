USE [SocialEcommerceDb]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetAllCategoryForDropdown]    Script Date: 21-10-2020 15:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Sp_GetAllCategoryForDropdown]
			@id Int = 0 
			AS
			BEGIN
	
				SET NOCOUNT ON;
				WITH cteCategory(ID, CategoryName, ParentCategoryID, Level, CategoryWithSubcategory)
				AS
				(
					SELECT c.Id, c.CategoryName,c.ParentCategoryId, 1, CONVERT(varchar(255), c.CategoryName)
					FROM Categories c
					WHERE ParentCategoryId IS NULL AND IsActive = 1 AND IsDelete = 0
		
					UNION ALL
		
					SELECT c.ID, c.CategoryName, c.ParentCategoryID, cte.Level + 1, CONVERT(varchar(255), cte.CategoryWithSubcategory + ' >> ' + c.CategoryName)
					FROM
					Categories c
					 
					INNER JOIN cteCategory cte ON cte.ID = c.ParentCategoryId
					WHERE c.IsActive = 1 AND c.IsDelete = 0
				),
	
				CTE_Results as 
				(
					SELECT ID , CategoryWithSubcategory,Level, ParentCategoryID
					FROM cteCategory
				)

				SELECT *
				INTO #tmp_filtered_LoadData
				FROM CTE_Results AS CPC

				IF @id IS NULL OR @id = 0
				BEGIN
					SELECT * FROM #tmp_filtered_LoadData ORDER BY #tmp_filtered_LoadData.ParentCategoryID ASC
				END
				ELSE
				BEGIN
					SELECT * FROM #tmp_filtered_LoadData where ID = @id ORDER BY #tmp_filtered_LoadData.ParentCategoryID ASC
				END
	
			END
			
