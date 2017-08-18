CREATE function dbo.GetYTilePos(@Latitude FLOAT, @Zoom INT)
RETURNS INT
AS
BEGIN
  DECLARE @A FLOAT, @B FLOAT, @C FLOAT, @D FLOAT, @E FLOAT, @F FLOAT, @G FLOAT, @tileY FLOAT
  SET @D   = 128 * POWER(2, @Zoom)                      
  SET @A =  Sin(PI() / 180 * @Latitude)
  SET @B =  -0.9999
  SET @C =   0.9999
  IF @A < @B SET @A = @B
  IF @A > @C SET @A = @C
  SET @F = @A
  SET @G = Round(@D + 0.5 * Log((1.0 + @F) / (1.0 - @F)) * (-256) * POWER(2, @Zoom) / (2 * PI()),0)       SET @tileY  = Floor(@G / 256)                         
  return @tileY
END