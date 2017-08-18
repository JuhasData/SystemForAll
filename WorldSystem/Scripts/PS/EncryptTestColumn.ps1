# Generated by SQL Server Management Studio at 6:08 PM on 4/27/2017

Import-Module SqlServer
# Set up connection and database SMO objects

$password = "<replace with your password>"
$sqlConnectionString = "Data Source=SYSTEMFORALLSQL\SYSTEMFORALL;Initial Catalog=WorldSystem;User ID=sa;Password=$password;MultipleActiveResultSets=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;Packet Size=4096;Application Name=`"Microsoft SQL Server Management Studio`""
$smoDatabase = Get-SqlDatabase -ConnectionString $sqlConnectionString

# If your encryption changes involve keys in Azure Key Vault, uncomment one of the lines below in order to authenticate:
#   * Prompt for a username and password:
#Add-SqlAzureAuthenticationContext -Interactive

#   * Enter a Client ID, Secret, and Tenant ID:
#Add-SqlAzureAuthenticationContext -ClientID '<Client ID>' -Secret '<Secret>' -Tenant '<Tenant ID>'

# Change encryption schema

$encryptionChanges = @()

# Add changes for table [dbo].[Test]
$encryptionChanges += New-SqlColumnEncryptionSettings -ColumnName dbo.Test.Test -EncryptionType Randomized -EncryptionKey "CEK_Auto1"

Set-SqlColumnEncryption -ColumnEncryptionSettings $encryptionChanges -InputObject $smoDatabase
