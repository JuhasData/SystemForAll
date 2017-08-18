create function LocateAlongGeom(@g geometry, @distance float) returns geometry
as external name SQLSpatialTools.[SQLSpatialTools.Functions].LocateAlongGeom