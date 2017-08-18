create function IsValidGeographyFromText(@inputWKT nvarchar(max), @srid int) returns bit
as external name SQLSpatialTools.[SQLSpatialTools.Functions].IsValidGeographyFromText