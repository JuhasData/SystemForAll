﻿CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'Neocomb078654321'
GO

CREATE CERTIFICATE SystemForAllCert WITH SUBJECT = 'SystemForAll Master Certificate';
GO

CREATE DATABASE ENCRYPTION KEY
WITH ALGORITHM = AES_128
ENCRYPTION BY SERVER CERTIFICATE SystemForAllCert;
GO

