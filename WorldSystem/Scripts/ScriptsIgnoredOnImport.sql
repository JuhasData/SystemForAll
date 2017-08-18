
-- Script assumes that current database contains zipcodes table with columns: code, state, shape_geom, shape_geog

select state, dbo.GeometryEnvelopeAggregate(shape_geom) from zipcodes group by state;
GO

-- For every state return its polygon by performing an union of all zip area belonging to that state.
-- Also buffer result by 0.5 meters to avoid tiny cracks along the borders of zip areas.
select state, dbo.GeographyUnionAggregate(shape_geog).STBuffer(0.5) from zipcodes group by state;
GO

-- Copyright (c) Microsoft Corporation.  All rights reserved.

-- Install the SQLSpatialTools assembly and all its functions into the current database

-- Enable CLR
sp_configure 'clr enabled', 1
GO

reconfigure
GO
-----------------------------------------

-- Rotate line by 30 degrees counter-clockwise around (0 0)
select AffineTransform::Rotate(45).Apply('LINESTRING (5 0, 10 0)').ToString()
GO

-- Returns: LINESTRING (3.5355339059327378 3.5355339059327373, 7.0710678118654755 7.0710678118654746)

-- Decrease line size 5 times
select AffineTransform::Scale(0.2, 0.2).Apply('LINESTRING (5 0, 10 0)').ToString()
GO

-- Returns: LINESTRING (1 0, 2 0)

-- Move line down by 2 units
select AffineTransform::Translate(0, -2).Apply('LINESTRING (5 0, 10 0)').ToString()
-- Returns: LINESTRING (5 -2, 10 -2)
GO

-- Copyright (c) Microsoft Corporation.  All rights reserved.

-- Drop the SQLSpatialTools assembly and all its functions from the current database

-- Drop the aggregates...
drop aggregate GeometryEnvelopeAggregate
GO

drop aggregate GeographyCollectionAggregate
GO

drop aggregate GeographyUnionAggregate
GO

-- Drop the functions...
drop function ShiftGeometry
GO

drop function LocateAlongGeog
GO

drop function LocateAlongGeom
GO

drop function InterpolateBetweenGeog
GO

drop function InterpolateBetweenGeom
GO

drop function VacuousGeometryToGeography
GO

drop function VacuousGeographyToGeometry
GO

drop function ConvexHullGeography
GO

drop function ConvexHullGeographyFromText
GO

drop function IsValidGeographyFromGeometry
GO

drop function IsValidGeographyFromText
GO

drop function MakeValidGeographyFromGeometry
GO

drop function MakeValidGeographyFromText
GO

drop function FilterArtifactsGeometry
GO

drop function FilterArtifactsGeography
GO

-- Drop the types...
drop type Projection
GO

drop type AffineTransform
GO

-- Drop the assembly...
drop assembly SQLSpatialTools
GO

-- Simple bow-tie polygon
declare @geog varchar(max) = 'POLYGON ((0 0, 10 2, 10 0, 0 2, 0 0))';

select dbo.IsValidGeographyFromText(@geog2, 4326);
-- returns 0 without throwing an exception

select dbo.MakeValidGeographyFromText(@geog2, 4326);
-- returns multipolygon of two triangles

GO

-- Project point and linestring using Albers Equal Area projection
declare @albers Projection
set @albers = Projection::AlbersEqualArea(0, 0, 0, 60)

select @albers.Project('POINT (45 30)').ToString()
select @albers.Unproject(@albers.Project('LINESTRING (10 0, 10 10)')).ToString()
select @albers.ToString()


GO
