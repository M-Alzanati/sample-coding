# Example Coding Task Task Template

This template should be used for coding tasks of Example.

Three projects are included in this solution:
- Example.CodingTask.Host: A .NET Core 6 Web Application
- Example.CodingTask.Data: A .NET Core 6class library which includes the first implementation of DB Context and User table.
- Example.CodingTask.Utilities: A .NET Core 6 class library which includes the Hash Service.

Database initialization has been implemented and configured in startup.

Basic authentication has been implemented and wired to the User table in DbContext.

An example API controller has been implemented as PingController which includes two GET methods, one without Authorization and the other one with Authorization.

By default, db connection string is configured for SQL Express. This can be changed in appSettings.Development.json .

Following users are provisioned during startup:

|UserName|Password|
|-|-|
|User1|Password1|
|User2|Password2|

Example AJAX calls to ping APIs (with and without Authorization) are present under Example.CodingTask.Host/Views/index.html

**Build FrontEnd**
```bash
$ cd src/Frontend
# install the project's dependencies
$ npm i
# run project at https://localhost:4200
$ ng serve --ssl
```
**Build Backend**
```bash
$ cd src/Backend
# Create database
$ dotnet ef database update --project Example.CodingTask.Data

# Change connection string in DefaultConnection in Example.CodingTask.Data/appsettings

# Change connection string in DefaultConnection in Example.CodingTask.Host/appsettings.Development
```

**Please note that running the migrations will create outdated matches, so please update records in the database**