﻿-- Register the functions...
create function ShiftGeometry(@g geometry, @xShift float, @yShift float) returns geometry
as external name SQLSpatialTools.[SQLSpatialTools.Functions].ShiftGeometry