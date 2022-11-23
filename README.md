# CleanTracker

Cleantracker is an issue tracker API developed with the purpose of practising DDD and Clean Architecture principles.

# Requirements
* .Net 6.0
* Docker

# How to run
## API
To start the API, run the WebApi run configuration in Visual Studio (2022).

*To use the database the sqlserver feature in appsettings.json has to be set to true when starting the API. If set to false, a faked database will be used*
## Database
You can either use a faked database or a dockerized SQL server:

### Docker
Set sqlserver to true in appsettings.json

To start the Database, navigate to the Docker folder from the CleanTracker root folder:

``cd Docker && docker-compose up ``

Open a terminal and navigate to the Infrastructure folder and apply dotnet migrations

``cd ./src/Infrastructure && dotnet-ef database update``

### Faked database
Set sqlserver to false in appsettings.json and run the WebApi poject

## To verify that it is working

Go to https://localhost:7157/swagger/index.html and Get the issue with ID ECC973D2-1B60-45F8-9A0C-05F9F042C494.

Using curl: ``curl -X 'GET' \
  'https://localhost:7157/api/v1/Issue/ECC973D2-1B60-45F8-9A0C-05F9F042C494' \
  -H 'accept: */*'
  ``



