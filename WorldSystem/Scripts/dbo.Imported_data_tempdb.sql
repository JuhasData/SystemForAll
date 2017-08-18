CREATE TABLE #Imported_Data (
Location geometry
);
INSERT INTO #Imported_Data VALUES
(geometry::STGeomFromText('LINESTRING(122 74, 123 72)', 0)),
(geometry::STGeomFromText('LINESTRING(140 65, 132 63)', 0));
GO

UPDATE #Imported_Data
SET Location.STSrid = 32731;
GO

SELECT
Location.STAsText(),
Location.STSrid
FROM #Imported_Data;

