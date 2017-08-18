backup Database WorldSystem
to disk = 'c:\temp\WorldSystem.bak'
with encryption
(
Algorithm = AES_256,
Server certificate = WorldSystemBackupCert
)
Go