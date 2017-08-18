CREATE FUNCTION [dbo].GetTileBounds
(@level int, @x int, @y int)
RETURNS geometry
AS
BEGIN
  DECLARE  @res GEOMETRY = NULL
  IF @level IS NOT NULL AND @x IS NOT NULL AND @y IS NOT NULL
  BEGIN
    DECLARE @n1  FLOAT = PI() - 2.0 * PI() * @y / POWER(2.0, @level);
    DECLARE @n2  FLOAT = PI() - 2.0 * PI() * (@y + 1) / POWER(2.0, @level);
    DECLARE @top FLOAT = (180.0 / PI() * ATAN(0.5 * (EXP(@n1) - EXP(-@n1))));
    DECLARE @bottom FLOAT = (180.0 / PI() * ATAN(0.5 * (EXP(@n2) - EXP(-@n2))));
    DECLARE @tileWidth FLOAT = 360 / CONVERT(float, POWER(2, @level))
    DECLARE @left FLOAT = @tileWidth * @x - 180,
          @right FLOAT = @tileWidth * (@x + 1) - 180
    SET @res = geometry::STPolyFromText('POLYGON (('
      + LTRIM(STR(@left, 25, 16)) + ' ' + LTRIM(STR(@top, 25, 16)) + ', '
      + LTRIM(STR(@left, 25, 16)) + ' ' + LTRIM(STR(@bottom, 25, 16)) + ', '
      + LTRIM(STR(@right, 25, 16)) + ' ' + LTRIM(STR(@bottom, 25, 16)) + ', '
      + LTRIM(STR(@right, 25, 16)) + ' ' + LTRIM(STR(@top, 25, 16)) + ', '
      + LTRIM(STR(@left, 25, 16)) + ' ' + LTRIM(STR(@top, 25, 16))
        + '))', 0)
END
  RETURN @res
END
