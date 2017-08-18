CREATE FUNCTION dbo.fn_FetchGeometryTilesZoomDepth(@GeoData GEOMETRY, @Zoom INT, @Depth INT)
RETURNS @retTiles TABLE (Zoom INT, TileX INT, TileY INT)
AS
BEGIN
   DECLARE @Left FLOAT, @Right FLOAT, @Top FLOAT, @Bottom FLOAT
   DECLARE @CurrentXTile INT, @CurrentYTile INT, @Quanttiles INT
   DECLARE @Envelope GEOMETRY, @RightTop GEOMETRY, @LeftBottom GEOMETRY
   DECLARE @CurTileGeom GEOMETRY, @res GEOMETRY
   DECLARE @tiletop FLOAT,@tilebottom FLOAT,@tileleft FLOAT, @tileright FLOAT
   DECLARE @LeftTilePos INT,@RightTilePos INT,@TopTilePos INT
   DECLARE @BottomTilePos INT
   SET @envelope = @GeoData.STEnvelope()
   SET @RightTop =  @envelope.STPointN(3)           
   SET @LeftBottom = @envelope.STPointN(1)
   SET @Right = @RightTop.STX
   SET @Left = @LeftBottom.STX
   SET @Top = @RightTop.STY
   SET @Bottom = @LeftBottom.STY
   SET @LeftTilePos   =    tile.GetXTilePos( @Left,@Zoom)
   SET @RightTilePos  =    tile.GetXTilePos( @Right,@Zoom)
   SET @TopTilePos    =    tile.GetYTilePos( @Top,@Zoom)
   SET @BottomTilePos =    tile.GetYTilePos( @Bottom,@Zoom)
   SET @CurrentXTile = @LeftTilePos
   WHILE @CurrentXTile <= @RightTilePos
   BEGIN
     SET @currentYTile = @TopTilePos
     WHILE @CurrentYTile <= @BottomTilePos          
     BEGIN                  
       INSERT INTO @retTiles (Zoom, TileX, TileY)
       SELECT * 
       FROM tile.fn_GetTilesByTileNumZoomDepth(@GeoData,@Zoom,@CurrentXTile,@CurrentYTile,@Depth)      
       SET @CurrentYTile = @CurrentYTile + 1
     END
     SET @CurrentXTile =@CurrentXTile + 1
   END 
RETURN
END