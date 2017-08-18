CREATE TABLE [dbo].[WorldSystem] (
	[Spatial_Reference_Id]            INT        NOT NULL,
	[Well_Known_Text]                 NVARCHAR (MAX) NOT NULL,
    [Coordinate_System]               FLOAT (53) NULL,
    [Datum]                           NCHAR (10) NULL,
    [Prime_Meridan]                   NCHAR (10) NULL,
    [Projection]                      NCHAR (10) NULL,
    [Unit_of_Measure]                 NCHAR (10) NULL,
    [Authority_Name]                  NCHAR (10) NULL,
    [Unit_Conversion_Factor]          NCHAR (10) NULL
);

GO
