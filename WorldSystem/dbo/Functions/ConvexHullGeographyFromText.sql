create function ConvexHullGeographyFromText(@inputWKT nvarchar(max), @srid int) returns geography
as external name SQLSpatialTools.[SQLSpatialTools.Functions].ConvexHullGeographyFromText