﻿create function IsValidGeographyFromGeometry(@inputGeometry geometry) returns bit
as external name SQLSpatialTools.[SQLSpatialTools.Functions].IsValidGeographyFromGeometry