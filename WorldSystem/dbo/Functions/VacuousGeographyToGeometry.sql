create function VacuousGeographyToGeometry(@toConvert geography, @targetSrid int) returns geometry
as external name SQLSpatialTools.[SQLSpatialTools.Functions].VacuousGeographyToGeometry