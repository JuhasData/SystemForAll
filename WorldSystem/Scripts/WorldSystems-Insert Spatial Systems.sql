
INSERT INTO WorldSystems(
Spatial_Reference_Id,
Well_Known_Text)
VALUES
(4326,'GEOGCS["WGS 84",
DATUM[
"World Geodetic System 1984",
SPHEROID["WGS 84", 6378137.0, 298.257223563, AUTHORITY["EPSG","7030"]],
AUTHORITY["EPSG","6326"]
],
PRIMEM["Greenwich", 0.0, AUTHORITY["EPSG","8901"]],
UNIT["degree", 0.017453292519943295],
AXIS["Geodetic longitude", EAST],
AXIS["Geodetic latitude", NORTH],
AUTHORITY["EPSG","4326"]
]'),
(32631,
'PROJCS["WGS 84 / UTM zone 31N",
GEOGCS["WGS 84",
DATUM[
"WGS_1984",
SPHEROID["WGS 84", 6378137, 298.257223563, AUTHORITY["EPSG","7030"]],
AUTHORITY["EPSG","6326"]
],
PRIMEM["Greenwich", 0, AUTHORITY["EPSG","8901"]],
UNIT["degree", 0.01745329251994328, AUTHORITY["EPSG","9122"]],
AUTHORITY["EPSG","4326"]
],
PROJECTION["Transverse_Mercator"],
PARAMETER["latitude_of_origin",0],
PARAMETER["central_meridian",3],
PARAMETER["scale_factor",0.9996],
PARAMETER["false_easting", 500000],
PARAMETER["false_northing",0],
UNIT["metre", 1, AUTHORITY["EPSG","9001"]],
AUTHORITY["EPSG","32631"]
]'),
(27700,
'PROJCS["OSGB 1936 / British National Grid",
GEOGCS["OSGB 1936",
DATUM[
"OSGB 1936",
SPHEROID["Airy 1830", 6377563.396, 299.3249646, AUTHORITY["EPSG","7001"]],
TOWGS84[446.448, -125.157, 542.06, 0.15, 0.247, 0.842, -4.2261596151967575],
AUTHORITY["EPSG","6277"]
],
PRIMEM["Greenwich", 0.0, AUTHORITY["EPSG","8901"]],
UNIT["degree", 0.017453292519943295],
AXIS["Geodetic longitude", EAST],
AXIS["Geodetic latitude", NORTH],
AUTHORITY["EPSG","4277"]
],
PROJECTION["Transverse Mercator"],
PARAMETER["central_meridian", -2.0],
PARAMETER["latitude_of_origin", 49.0],
PARAMETER["scale_factor", 0.9996012717],
PARAMETER["false_easting", 400000.0],
PARAMETER["false_northing", -100000.0],
UNIT["m", 1.0],
AXIS["Easting", EAST],
AXIS["Northing", NORTH],
AUTHORITY["EPSG","27700"]
]');
GO
