﻿create function FilterArtifactsGeography(@g geography, @filterEmptyShapes bit, @filterPoints bit, @lineStringTolerance float(53), @ringTolerance float(53)) returns geography
as external name SQLSpatialTools.[SQLSpatialTools.Functions].FilterArtifactsGeography