CREATE PROCEDURE GetBooksPaged
    @SearchQuery NVARCHAR(100) = NULL,
    @AuthorId UNIQUEIDENTIFIER = NULL,
    @SortBy NVARCHAR(50) = NULL,
    @PageNumber INT = 1,
    @PageSize INT = 10
AS
BEGIN
    DECLARE @SortColumn NVARCHAR(50);
    
    SET @SortColumn = COALESCE(@SortBy, 'Id'); -- Default to 'Id' if 'SortBy' is NULL

    SELECT 
        Id,
        Name,
        Description,
        ContentUrl,
        AuthorId
    FROM 
        Books
    WHERE 
        (@SearchQuery IS NULL OR Name LIKE '%' + @SearchQuery + '%')
        AND (@AuthorId IS NULL OR AuthorId = @AuthorId)
    ORDER BY 
        CASE 
            WHEN @SortColumn = 'Name' THEN Name
            ELSE Id -- Default sorting by 'Id'
        END
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END
