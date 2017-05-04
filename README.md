Carsales
============

Carsales is a clone website built with [ASP.NET Core MVC](https://github.com/aspnet/Mvc) that lists cars and submits car enquiries.


## Installation

### Bower packages

Go to your CLI and run the command below in the `Carsales.Web` project's folder:

```sh
bower install
```

The command will install the following [Bower](https://bower.io/) packages:

* [Bootstrap](http://getbootstrap.com/)
* [jQuery](https://jquery.com/)
* [jQuery Validation](https://jqueryvalidation.org/)


### SQLite

Go to https://www.sqlite.org/download.html and follow the installation guideline if you need to install SQLite on your OS.

To initialize the database, execute this command in your `Carsales.Web` project's folder:
```sh
dotnet ef database update
```

If you want to reset the database, delete the `Carsales.Web/bin/Debug/netcoreapp1.1/Carsales.db` file first and execute the command above.

The database will get populated automatically the first time you run the website (see `DbInitializer.cs`).

### .NET Core

Go to https://www.microsoft.com/net/core, select your OS and follow the installation guide. At the time of writing, the latest version is .NET Core 1.1.


## Usage

If you can, build your project with your IDE and run it. Otherwise, run this command in your `Carsales.Web` project's folder:
```sh
dotnet build
```

To run the website, run this command:
```sh
dotnet run
```

Now, go to http://localhost:5000/. And voila!


## Concepts

### Dependency Injection

The Dependency Inversion Principle states that:
```
High level modules should not depend on low-level modules, both should depend on abstractions.
```

.NET Core MVC comes with a built-in Dependency Injection container that creates requested objects with their dependencies. The container registers all types at the application start and build a complex dependency graph between them. When an instance is requested, it goes through the dependency graph to new up all the dependant types before finally instantiating the requested type.

### Repositories

Carsales uses repositories. They are an extra layer that aims to encapsulate the business/data access logic in one place for better code reusability and extension.

### AutoMapper

Carsales uses AutoMapper. Its purpose is two-fold:

* mapping one object's properties to another object
* cleaning up your controllers' actions by getting rid of mapping code that bloats them up and organize them in Profiles

### Unit Tests with xUnit and Moq

The `Carsales.Web.UnitTests` project contains unit tests for our controllers' methods. It uses the unit testing framework `xUnit` and the mocking framework `Moq`.


## Notes

### Carsales.Web.Core

The Carsales.Web.Core folder couldn't be exported to its own `Carsales.Core` project due to [dependency issues](https://github.com/dotnet/coreclr/issues/10037) between .NET Core App and .NET Standard Library projects.

The End.