create function ConvexHullGeography(@geog geography) returns geography
as external name SQLSpatialTools.[SQLSpatialTools.Functions].ConvexHullGeography