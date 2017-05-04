Carsales
============

Carsales is a clone website built with [ASP.NET Core MVC](https://github.com/aspnet/Mvc) that lists cars and submits car enquiries.


## Installation

### Bower packages

Carsales uses the following [Bower](https://bower.io/) packages:

* [Bootstrap](http://getbootstrap.com/)
* [jQuery](https://jquery.com/)
* [jQuery Validation](https://jqueryvalidation.org/)

To install them, go to your command line and run the command below in the `Carsales.Web` project's folder:

```sh
bower install
```

### SQLite

Carsales uses an [SQLite](https://www.sqlite.org/) database that lives in `Carsales.Web/bin/Debug/netcoreapp1.1/Carsales.db`.

Click [here](https://www.sqlite.org/download.html) if you need to install SQLite on your operating system.

To initialize the database, execute this command in the `Carsales.Web` project's folder:
```sh
dotnet ef database update
```

If you want to reset the database, delete the `Carsales.Web/bin/Debug/netcoreapp1.1/Carsales.db` file first and execute the command above.

Then, the database gets populated automatically the first time you run the website (see `DbInitializer.cs`).


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