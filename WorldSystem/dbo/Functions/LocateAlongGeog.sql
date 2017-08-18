create function LocateAlongGeog(@g geography, @distance float) returns geography
as external name SQLSpatialTools.[SQLSpatialTools.Functions].LocateAlongGeog