CREATE SECURITY POLICY [GlobalsFilter]
ADD FILTER PREDICATE dbo.fn_SelectGlobalsRowsasPublicandOwner(User)
on dbo.Globals
WITH (STATE = ON, SCHEMABINDING = ON)