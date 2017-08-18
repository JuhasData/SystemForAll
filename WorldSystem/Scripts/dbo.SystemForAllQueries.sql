SELECT
 well_known_text
FROM
 sys.spatial_reference_systems
WHERE
 authority_name = 'EPSG'
 AND
 authorized_spatial_reference_id = 4326;


 GO

DECLARE @LineString geometry = 'LINESTRING(0 0, 8 6)';
DECLARE @CircularString1 geometry = 'CIRCULARSTRING(0 0, 4 3, 8 6)';

DECLARE @MultiPoint1 geometry = 'MULTIPOINT(0 0, 2 4, 10 8)';
SELECT
 @LineString.STEquals(@CircularString1), -- Returns 1 (true)
 @MultiPoint1.STEquals(@MultiPoint1); -- Returns 1 (true) 

 GO

 SELECT geometry::Parse('POINT(30 40)'); 

 GO

 SELECT
 unit_of_measure
FROM
 sys.spatial_reference_systems
WHERE
 authority_name = 'EPSG'
 AND
 authorized_spatial_reference_id = 4326;

 GO

SELECT Globals.Point0, Globals.Point1, Globals.Point2,Globals.Point3, Globals.Point4, Globals.Point5,Globals.Point6,Globals.Point7, 
Globals.Point8,Globals.Point9,Globals.Point10, Globals.Point11,Globals.Point12,Globals.Point13,Globals.Point14,Globals.Point15,
Globals.Point16,Globals.Point17,Globals.Point18,Globals.Point19,Globals.Point20,Globals.Point21,Globals.Point22,Globals.Point23,
Globals.Point24,Globals.Point25,Globals.Point26
FROM Globals where Globals.Id=3

--INNER JOIN Locations
--ON Globals.Session=Locations.Session

GO

DECLARE @g geometry = geometry::STPointFromText('POINT(14 9 7)', 0);
SELECT
 @g.STAsBinary(); 
Go
 -- Declare point containing x, y, and z coordinates
DECLARE @g geometry = geometry::STPointFromText('POINT(14 9 7)', 0);
-- Convert to WKB using STAsBinary()
DECLARE @WKB varbinary(max) = @g.STAsBinary();
-- Now create a new geometry instance from this WKB
DECLARE @h geometry = geometry::STPointFromWKB(@WKB, 0);
--Retrieve the Well-Known Text of the new geometry
SELECT @h.AsTextZM();

GO

DECLARE @g geometry = geometry::STPointFromText('POINT(14 9 7)', 0);
SELECT @g.AsBinaryZM();

GO

DECLARE @gml xml =
'<Point xmlns="http://www.opengis.net/gml">
 <pos>47.6 -122.3</pos>
</Point>';
SELECT
geography::GeomFromGml(@gml, 4269); 

GO

DECLARE @polygon geography = 'POLYGON((-4 50, 2 50, 2 60, -4 60, -4 50))';
SELECT @polygon.AsGml(); 

GO

DECLARE @Precise geometry;
SET @Precise = geometry::Point(10.23456789012345, 0, 0);
DECLARE @SuperPrecise geometry;
SET @SuperPrecise = geometry::Point(10.234567890123456789012345678901234567, 0, 0);
SELECT @Precise.STEquals(@SuperPrecise);

GO
CREATE FUNCTION dbo.RoundGeography (
@g geography,
@precision int
) RETURNS geography
AS EXTERNAL NAME
WorldSystem.[WorldSystem.ProSpatial.UserDefinedFunctions].RoundGeography;
GO

DECLARE @line1 geometry = 'LINESTRING(0 13, 431 310)';
DECLARE @line2 geometry = 'LINESTRING(0 502, 651 1)';

SELECT @line1
UNION ALL SELECT @line2;
GO


DECLARE @rectangle geometry = 'POLYGON((-10 5, 10 5, 10 15, -10 15, -10 5))';
DECLARE @square geometry = 'POLYGON((0 0, 1000 0, 1000 1000, 0 1000, 0 0))';
SELECT @rectangle.STIntersection(@square).STArea();
-- 99.9999999999713
DECLARE @square2 geometry = 'POLYGON((0 0, 100000 0, 100000 100000, 0 100000, 0 0))';
SELECT @rectangle.STIntersection(@square2).STArea();
-- 99.9999999962893
DECLARE @square3 geometry = 'POLYGON((0 0, 1e9 0, 1e9 1e9, 0 1e9, 0 0))';
SELECT @rectangle.STIntersection(@square3).STArea();
-- 99.9999690055833
DECLARE @square4 geometry = 'POLYGON((0 0, 1e12 0, 1e12 1e12, 0 1e12, 0 0))';
SELECT @rectangle.STIntersection(@square4).STArea();
-- 99.9691756255925
DECLARE @square5 geometry = 'POLYGON((0 0, 1e15 0, 1e15 1e15, 0 1e15, 0 0))';
SELECT @rectangle.STIntersection(@square5).STArea();
-- 67.03125
GO

DECLARE @LineMustHave2Points geometry;
SET @LineMustHave2Points = geometry::STLineFromText('LINESTRING(3 2)', 0);

GO

DECLARE @Spike geometry
SET @Spike = geometry::STPolyFromText('POLYGON((0 0,1 1,2 2,0 0))', 0)
SELECT
@Spike.STAsText(),
@Spike.STIsValid()

GO
DECLARE @Spike geometry = 'POLYGON((0 0,1 1,2 2,0 0))';
SELECT @Spike.MakeValid().ToString()

GO
DECLARE @SelfIntersectingPolygon geometry;
SET @SelfIntersectingPolygon = 'POLYGON((0 0, 6 0, 3 5, 0 0), (2 2, 8
2, 8 4, 2 4, 2 2))';
SELECT @SelfIntersectingPolygon.MakeValid().ToString();
GO

BEGIN TRY
SELECT geometry::STPolyFromText('POLYGON((0 0, 10 2, 0 0))', 0);
END TRY
BEGIN CATCH
IF ERROR_NUMBER() = 123
-- Code to deal with error 123 here
SELECT 'Error 123 occurred'
ELSE IF ERROR_NUMBER() = 456
-- Code to deal with error 456 here
SELECT 'Error 456 occurred'
ELSE
SELECT ERROR_NUMBER() AS ErrorNumber;
END CATCH

GO

DECLARE @LowPrecision geometry;
SET @LowPrecision = geometry::STPointFromText('POINT(1 2)', 0);
DECLARE @HighPrecision geometry;
SET @HighPrecision = geometry::STPointFromText('POINT(1.2345678901234567890123456789
2.3456789012345678)', 0);
SELECT
DATALENGTH(@LowPrecision),
DATALENGTH(@HighPrecision);
Go

DECLARE @g geometry = 'LINESTRING(0 0, 5 10, 8 2)';
DECLARE @h geometry = 'LINESTRING(0 0, 10 0, 5 0)';
DECLARE @i geometry = 'POLYGON((0 0, 2 0, 2 2, 0 2, 0 0), (1 0, 3 0, 3 1, 1 1, 1 0))';
SELECT
@g.STIsValid() AS STIsValid, @g.IsValidDetailed() AS IsValidDetailed
UNION ALL SELECT
@h.STIsValid(), @h.IsValidDetailed()
UNION ALL SELECT
@h.STIsValid(), @i.IsValidDetailed();

GO

SELECT well_known_text
FROM sys.spatial_reference_systems
WHERE spatial_reference_id = 4181;

GO

CREATE FUNCTION dbo.RoundGeography (
@g geography,
@precision int
) RETURNS geography
AS EXTERNAL NAME
dbo.WorldSystem.RoundGeography;

GO

EXEC sp_configure 'clr enabled', '1';
GO
RECONFIGURE;
GO
ALTER DATABASE WorldSystems SET TRUSTWORTHY OFF
GO
DECLARE @Norwich geography;
SET @Norwich = geography::STPointFromText('POINT(1.369338 53.035498)', 4326);
SELECT dbo.GeographyToGeometry(@Norwich, 32631).ToString();
Go
DECLARE @Oxford geography;
SET @Oxford = geography::STPointFromText('POINT(-1.256804 51.752143)', 4326);
SELECT dbo.GeographyToGeometry(@Oxford, 27700).ToString();
GO
DECLARE @Line geometry;
SET @Line = 'Linestring(0 0, 5 2, 8 3)';
SELECT @Line.STGeometryType();
GO
DECLARE @CircularString geometry;
SET @CircularString = 'CIRCULARSTRING(0 0, 3 5, 6 1)';
SELECT
@CircularString.InstanceOf('Curve'), -- 1
@CircularString.InstanceOf('CircularString'), -- 1
@CircularString.InstanceOf('LineString'); -- 0
GO
DECLARE @DeliveryRoute geometry;
SET @DeliveryRoute = geometry::STLineFromText(
'LINESTRING(586960 4512940, 586530 4512160, 585990 4512460,
586325 4513096, 587402 4512517, 587480 4512661)', 32618);
SELECT
@DeliveryRoute AS Shape,
@DeliveryRoute.STIsSimple() AS IsSimple;
GO
DECLARE @DeliveryRoute geometry;
SET @DeliveryRoute = geometry::STLineFromText(
'LINESTRING(586960 4512940, 587480 4512661, 587402 4512517,
586325 4513096, 585990 4512460, 586530 4512160)', 32618);
SELECT
@DeliveryRoute AS Shape,
@DeliveryRoute.STIsSimple() AS IsSimple;
GO
DECLARE @Snowdon geography;
SET @Snowdon = geography::STMLineFromText(
'MULTILINESTRING(
(-4.07668 53.06804 3445, -4.07694 53.06832 3445, -4.07681 53.06860 3445,
-4.07668 53.06869 3445, -4.07651 53.06860 3445, -4.07625 53.06832 3445,
-4.07661 53.06804 3445, -4.07668 53.06804 3445),
(-4.07668 53.06776 3412, -4.07709 53.06795 3412, -4.07717 53.06804 3412,
-4.07730 53.06832 3412, -4.07730 53.06860 3412, -4.07709 53.06890 3412,
-4.07668 53.06898 3412, -4.07642 53.06890 3412, -4.07597 53.06860 3412,
-4.07582 53.06832 3412, -4.07603 53.06804 3412, -4.07625 53.06791 3412,
-4.07668 53.06776 3412),
(-4.07709 53.06768 3379, -4.07728 53.06778 3379, -4.07752 53.06804 3379,
-4.07767 53.06832 3379, -4.07773 53.06860 3379, -4.07771 53.06890 3379,
-4.07728 53.06918 3379, -4.07657 53.06918 3379, -4.07597 53.06890 3379,
-4.07582 53.06879 3379, -4.07541 53.06864 3379, -4.07537 53.06860 3379,
-4.07526 53.06832 3379, -4.07556 53.06804 3379, -4.07582 53.06795 3379,
-4.07625 53.06772 3379, -4.07668 53.06757 3379, -4.07709 53.06768 3379))',
4326);
SELECT
@Snowdon AS Shape,
@Snowdon.STIsClosed() AS IsClosed;
Go
DECLARE @BermudaTriangle geography;
SET @BermudaTriangle = geography::STPolyFromText(
'POLYGON((-66.07 18.45, -64.78 32.3, -80.21 25.78, -66.07 18.45))',
4326);
SELECT
@BermudaTriangle AS Shape,
@BermudaTriangle.STNumPoints() AS NumPoints;
GO
DECLARE @Colorado geometry;
SET @Colorado = geometry::STGeomFromText('POLYGON((-102.0423 36.9931, -102.0518
41.0025, -109.0501 41.0006, -109.0452 36.9990, -102.0423 36.9931))', 4326);
SELECT
@Colorado AS Shape,
@Colorado.STCentroid() AS Centroid,
@Colorado.STCentroid().STAsText() AS WKT;
GO
DECLARE @Utah geography;
SET @Utah = geography::STPolyFromText(
'POLYGON((-109 37, -109 41, -111 41, -111 42, -114 42, -114 37, -109 37))', 4326);
SELECT
@Utah AS Shape,
@Utah.EnvelopeCenter() AS EnvelopeCenter,
@Utah.EnvelopeCenter().STAsText() AS WKT;
GO
DECLARE @Antenna geography;
SET @Antenna =
geography::STPointFromText('POINT(-89.64778 39.83167 34.7 1000131)', 4269);
SELECT
@Antenna.HasM AS HasM,
@Antenna.M AS M,
@Antenna.HasZ AS HasZ,
@Antenna.Z AS Z;
GO
DECLARE @A geometry;
SET @A = geometry::STPolyFromText(
'POLYGON((0 0, 4 0, 6 5, 14 5, 16 0, 20 0, 13 20, 7 20, 0 0),
(7 8,13 8,10 16,7 8))', 0);
SELECT
@A AS Shape,
@A.STBoundary() AS Boundary,
@A.STBoundary().STAsText() AS WKT;
Go
DECLARE @Polygon geometry;
SET @Polygon = geometry::STGeomFromText('POLYGON((10 2,10 4,5 4,5 2,10 2))',0);
SELECT
@Polygon AS Shape,
@Polygon.STPointOnSurface() AS PointOnSurface,
@Polygon.STPointOnSurface().STAsText() AS WKT;
GO
DECLARE @A geometry;
SET @A = geometry::STPolyFromText(
'POLYGON((0 0, 4 0, 6 5, 14 5, 16 0, 20 0, 13 20, 7 20, 0 0),
(7 8,13 8,10 16,7 8))', 0);
SELECT
@A AS Shape,
@A.STBoundary() AS Boundary,
@A.STBoundary().STAsText() AS WKT;
GO
DECLARE @NorthernHemisphere geography
SET @NorthernHemisphere =
geography::STGeomFromText('POLYGON((0 0.1,90 0.1,180 0.1, -90 0.1, 0 0.1))',4326)
SELECT
@NorthernHemisphere AS Shape,
@NorthernHemisphere.EnvelopeAngle() AS EnvelopeAngle;
GO
DECLARE @LineString geometry;
SET @LineString =
'LINESTRING(130 33, 131 33.5, 131.5 32.9, 133 32.5, 135 33, 137 32, 138 31, 140 30)';
SELECT
@LineString.Reduce(1).ToString() AS SimplifiedLine;