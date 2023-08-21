# Microservice-products

This folder contains Microservice-products project, which is written in C#.

How to run locally:

1. Clone repo
2. Install dotnet sdks
3. Run following command to install EF tools globally to machine: dotnet tool install --global dotnet-ef
4. Setup Postgres 14 db with values mentioned in appsettings.Development.json (you can use script in microservice-deployment repo to create and run postgres in docker container)
5. In project folder: cd ProductApi
6. Run "dotnet run"

How to run tests:

1. Clone repo
2. Install dotnet sdks
3. In project folder run: "dotnet test"

Recommended tools for Vscode:

- Formatter: Csharpier
