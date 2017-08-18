CREATE TABLE [dbo].[WorldSystem] (
	[Spatial_Reference_Id]            INT      NOT NULL,
	[Well_Known_Text]                 NVARCHAR (MAX) NULL,
    [Coordinate_System]               FLOAT (53) NULL,
    [Datum]                           NCHAR (10) NULL,
    [Prime_Meridan]                   NCHAR (10) NULL,
    [Projection]                      NCHAR (10) NULL,
    [Unit_of_Measure]                 NCHAR (10) NULL,
    [Authority_Name]                  NCHAR (10) NULL,
    [Unit_Conversion_Factor]          NCHAR (10) NULL, 
	ValidFrom datetime2 GENERATED ALWAYS AS ROW START NOT NULL,
	ValidTo datetime2 GENERATED ALWAYS AS ROW END NOT NULL,
	PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo),
    CONSTRAINT [PK_WorldSystem] PRIMARY KEY ([Spatial_Reference_Id])
)
WITH (SYSTEM_VERSIONING = ON
	(HISTORY_TABLE = dbo.WorldSystemHistory))

GO
