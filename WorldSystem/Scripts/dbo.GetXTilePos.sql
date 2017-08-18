CREATE FUNCTION dbo.GetXTilePos(@Longitude FLOAT, @Zoom INT)
RETURNS INT
AS
BEGIN      
  DECLARE @D FLOAT,@E FLOAT,@F FLOAT,@G FLOAT, @tileY INT, @tileX INT         
  SET @D = 128 * POWER(2, @Zoom)
  SET @E = ROUND(@D + @Longitude * 256 / 360 * POWER(2, @Zoom), 0)            
  SET @tileX  = Floor(@E / 256);          
  RETURN @tileX
END