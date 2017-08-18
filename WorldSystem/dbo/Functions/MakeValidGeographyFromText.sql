create function MakeValidGeographyFromText(@inputWKT nvarchar(max), @srid int) returns geography
as external name SQLSpatialTools.[SQLSpatialTools.Functions].MakeValidGeographyFromText