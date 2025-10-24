# DevEvents

This is a solution that implements a WebAPI to register events and their speakers.

This solution was built for study purposes following the good playlist [Curso Criando REST APIs com ASP.NET Core](https://youtube.com/playlist?list=PLI2XdbZhEq4n9A46xhfYPMdViA3H_v-mb&si=62Gzmj37RgehQ_XY) hosted on the YouTube channel [Luis Felipe (LuisDev)](https://youtube.com/@nextwave.education?si=HSCs1wLh1mtwX5E_)

## Stacks

In order to build this solution the following stacks were used:

* Net Core 9
* SQL Server Database
* Docker Image: mcr.microsoft.com/mssql/server:2022-latest (not included in this repository)

## Packages

The following Nuget packages were included in the project:

```bash
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.8" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.10" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="9.0.10" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.10" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.10" />
    <PackageReference Include="Scalar.AspNetCore" Version="2.9.0" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="9.0.6" />
    <PackageReference Include="Swashbuckle.AspNetCore.ReDoc" Version="9.0.6" />
    <PackageReference Include="Swashbuckle.AspNetCore.SwaggerUI" Version="9.0.6" />
```

> **Microsoft.EntityFrameworkCore.InMemory** was used to persist data in momory before implementing database persistence

## API Documentation

Three different ways of documentation have been implemented. Choose the one that suits you best.

* Swagger
* ReDoc
* Scalar (my favorite)