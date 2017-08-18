create function InterpolateBetweenGeom(@start geometry, @end geometry, @distance float) returns geometry
as external name SQLSpatialTools.[SQLSpatialTools.Functions].InterpolateBetweenGeom