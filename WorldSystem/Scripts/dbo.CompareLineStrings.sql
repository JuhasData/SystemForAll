CREATE FUNCTION CompareLineStrings (@l1 geometry, @l2 geometry)
RETURNS bit AS
BEGIN
-- Only test LineString geometries
IF NOT (@l1.STGeometryType() = 'LINESTRING' AND @l2.STGeometryType() = 'LINESTRING')
RETURN NULL
-- Startpoints differ by more than 1 unit
IF @l1.STStartPoint().STDistance(@l2.STStartPoint()) > 1
RETURN 0
-- Endpoints differ by more than 1 unit
IF @l1.STEndPoint().STDistance(@l2.STEndPoint()) > 1
RETURN 0
-- Length differs by more than 5%
IF ABS(@l1.STLength() - @l2.STLength() / @l1.STLength()) > 0.05
RETURN 0
-- Any part of l2 lies more than 0.1 units from l1
IF @l1.STBuffer(0.1).STDifference(@l2).STEquals('GEOMETRYCOLLECTION EMPTY') = 0
RETURN 0
-- All tests pass, so return success
RETURN 1
END