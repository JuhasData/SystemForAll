-- Create aggregates.

create aggregate GeometryEnvelopeAggregate(@geom geometry) returns geometry
external name SQLSpatialTools.[SQLSpatialTools.GeometryEnvelopeAggregate]