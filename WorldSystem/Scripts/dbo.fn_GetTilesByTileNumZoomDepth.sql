CREATE FUNCTION dbo.fn_GetTilesByTileNumZoomDepth 
(@GeoData GEOMETRY, @Zoom INT, @tileX INT, @tileY INT, @Depth INT)
RETURNS @retTiles TABLE (Zoom INT,   X INT,   Y INT)
AS
BEGIN
 DECLARE @currentTile TABLE (Zoom INT,   X INT,   Y INT)
 IF GEOGRAPHY::STGeomFromWKB(
    tile.GetTileBounds
      (@Zoom, @tileX, @tileY).STAsBinary(),4326).STIntersects
        (GEOGRAPHY::STGeomFromWKB
          (@GeoData.MakeValid().STUnion
            (@GeoData.STStartPoint()).STAsBinary(),4326)) = 1
 BEGIN
  INSERT INTO @currentTile SELECT @Zoom , @tileX , @tileY                   
  INSERT INTO @retTiles             
  SELECT d.zoom, d.X, d.Y FROM @currentTile c
  CROSS APPLY (SELECT * 
               FROM [tile].[fn_GetTilesForObjectByTileNumZoomDepth]
                 (@GeoData , c.Zoom + 1, c.X * 2, c.Y * 2, @Depth - 1) WHERE @Depth > 0) AS d
  INSERT INTO @retTiles      
  SELECT d.zoom, d.X, d.Y FROM @currentTile c
  CROSS APPLY (SELECT * 
               FROM [tile].[fn_GetTilesForObjectByTileNumZoomDepth]
                 (@GeoData , c.Zoom + 1, c.X * 2 + 1, c.Y * 2, @Depth - 1) WHERE @Depth > 0) AS d
  INSERT INTO @retTiles      
  SELECT d.zoom, d.X, d.Y FROM @currentTile c
  CROSS APPLY (SELECT * 
               FROM [tile].[fn_GetTilesForObjectByTileNumZoomDepth]
                 (@GeoData , c.Zoom + 1, c.X * 2, c.Y * 2 + 1, @Depth - 1) WHERE @Depth > 0) AS d
  INSERT INTO @retTiles      
  SELECT d.zoom, d.X, d.Y FROM @currentTile c
  CROSS APPLY (SELECT * 
               FROM [tile].[fn_GetTilesForObjectByTileNumZoomDepth]
                 (@GeoData , c.Zoom + 1, c.X * 2 + 1, c.Y * 2 + 1, @Depth - 1) WHERE @Depth > 0) AS d
  INSERT INTO @retTiles SELECT * FROM @currentTile
 END
 RETURN
END