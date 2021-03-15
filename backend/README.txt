Setup instructions
-------------------
Using Sql Management Studio or similar, create a sysadmin user on your local database:
findMyDocAdmin
dEs3cent!234

In the appsettings.json, ensure that the connection string matches your local sql database:

---------------------------------------------------------------
{
  "ConnectionString": {
    "FindMyDocDB": "server=.\\SQLEXPRESS;database=FindMyDocDB;User ID=findMyDocAdmin;password=dEs3cent!234;" <-- Swap out the server for the name of your local server
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
-----------------------------------------------------------------

Build solution. Run IIS Express and it should start up on localhost:3000. Leave it running for front end to connect to.