﻿create aggregate GeographyCollectionAggregate(@geog geography) returns geography
external name SQLSpatialTools.[SQLSpatialTools.GeographyCollectionAggregate]