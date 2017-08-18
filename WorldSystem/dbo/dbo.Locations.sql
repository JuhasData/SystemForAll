CREATE TABLE [dbo].[Locations] (
    [Id]        INT               NOT NULL,
    [Name]      NVARCHAR (50)     NULL,
    [Session]   UNIQUEIDENTIFIER  NULL,
	[Location]	geometry		 NULL,
    [Globals]   [sys].[geometry]  NULL,
    [Type]      NVARCHAR (50)     NULL,
    [Latitude]  FLOAT (53)        NULL,
    [Longitude] FLOAT (53)        NULL,
    [Geo]       [sys].[geography] NULL,
	ValidFrom datetime2 GENERATED ALWAYS AS ROW START NOT NULL,
	ValidTo datetime2 GENERATED ALWAYS AS ROW END NOT NULL,
	PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo),
    CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Enforce_SRID_Geography_Locations] CHECK ([Geo].[STSrid]=(4326))
)
WITH (SYSTEM_VERSIONING = ON
	(HISTORY_TABLE = dbo.LocationHistory))


GO
CREATE SPATIAL INDEX [Location_Index]
    ON [dbo].[Locations] ([Geo])
    USING GEOGRAPHY_GRID
    WITH  (
            GRIDS = (LEVEL_1 = MEDIUM, LEVEL_2 = MEDIUM, LEVEL_3 = MEDIUM, LEVEL_4 = MEDIUM)
          );

