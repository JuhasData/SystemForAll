create function VacuousGeometryToGeography(@toConvert geometry, @targetSrid int) returns geography
as external name SQLSpatialTools.[SQLSpatialTools.Functions].VacuousGeometryToGeography