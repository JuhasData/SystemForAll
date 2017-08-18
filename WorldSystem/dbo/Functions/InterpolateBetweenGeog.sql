create function InterpolateBetweenGeog(@start geography, @end geography, @distance float) returns geography
as external name SQLSpatialTools.[SQLSpatialTools.Functions].InterpolateBetweenGeog