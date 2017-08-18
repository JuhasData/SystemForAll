CREATE FUNCTION [dbo].[fn_SelectGlobalsRowsasPublicandOwner]
(
	@User AS varchar(50)
)

RETURNS TABLE
WITH SCHEMABINDING
AS 
Return SELECT 1 AS SelectGlobals_Result
where @User = USER_NAME()
or USER_NAME() = 'Public';

