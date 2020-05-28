# Hahn.ApplicatonProcess.Application

Project created following the application for the position of developer in Hahn Softwareentwicklung.
It is built in ASP.NET Core 3.1 hosting an [aurelia-cli](https://aurelia.io) app. 

# Restore Nuget and npm packages
Run `cd .\Hahn.ApplicatonProcess.Application\` 

Run `dotnet restore`

Run `dotnet build`

Run `cd .\Hahn.ApplicatonProcess.May2020.Web\`

## Run dev app

Run `dotnet run`, then open `http://localhost:5000`

## Run production app

Run `dotnet publish`

Run `cd .\bin\Debug\netcoreapp3.1\publish\`

Run `.\Hahn.ApplicatonProcess.May2020.Web.exe`, then open `http://localhost:5000`
