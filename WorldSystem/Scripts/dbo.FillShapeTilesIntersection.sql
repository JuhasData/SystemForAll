CREATE PROC dbo.FillShapeTilesIntersection( @StartZoom INT, @EndZoom INT)
AS
BEGIN
DECLARE @Shape GEOMETRY   
DECLARE @CurrentZoom INT
DECLARE @ObjectTypeID INT
DECLARE @fillArgb NVARCHAR(10), @strokeArgb NVARCHAR(10)            
IF @ObjectTypeID IS NOT NULL
BEGIN        
  SET @CurrentZoom = @StartZoom                               
  DECLARE shape_cursor
  CURSOR FOR
  SELECT o.Shape, fillARGB, strokeARGB
  FROM dbo.Shape o                                            
  OPEN shape_cursor
  FETCH NEXT FROM shape_cursor INTO @Shape, @fillArgb, @strokeArgb
  WHILE @@FETCH_STATUS = 0
  BEGIN
    SET @CurrentZoom = @StartZoom
    WHILE @CurrentZoom  <= @EndZoom
    BEGIN
      INSERT INTO dbo.tileOverlap (Zoom, X,Y,Data)
      SELECT t.Zoom, t.TileX AS X,t.TileY AS Y, 
             dbo.ShapeTile(@Shape, t.Zoom, t.TileX, t.TileY, @fillArgb, @strokeArgb ,2) AS Data
      FROM (SELECT * FROM  dbo.fn_FetchGeometryTiles(@Shape,@CurrentZoom)) t
	  SET @CurrentZoom = @CurrentZoom + 1
    END                              
    FETCH NEXT FROM shape_cursor INTO @Shape, @fillArgb, @strokeArgb 
  END
  CLOSE shape_cursor;
  DEALLOCATE shape_cursor;                     
  DELETE dbo.TileOverlap
  END
END