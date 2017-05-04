Carsales
============

Carsales is a clone website built with [ASP.NET Core MVC](https://github.com/aspnet/Mvc) that lists cars and submits car enquiries.


## Installation

### Nuget packages

If you can, restore the Nuget package dependencies/dlls of all projects with your IDE, then build the solution. Otherwise, at the root of the solution, run:
```sh
$ dotnet restore
$ dotnet build
```

### Bower packages

In a command line window, run:

```sh
$ cd Carsales.Web
$ bower install
```

The command will install the following [Bower](https://bower.io/) packages:

* [Bootstrap](http://getbootstrap.com/)
* [jQuery](https://jquery.com/)
* [jQuery Validation](https://jqueryvalidation.org/)


### SQLite

Go to https://www.sqlite.org/download.html and follow the installation guideline if you need to install SQLite.

If you want to reset the database, delete the `Carsales.db` file first:
```sh
$ rm -f bin/Debug/netcoreapp1.1/Carsales.db
```

To initialize the database, run:
```sh
$ dotnet ef database update
```

The database will get populated automatically the first time you run the website (see `DbInitializer.cs`).

### .NET Core

Go to https://www.microsoft.com/net/core, select your OS and follow the installation guide. At the time of writing, the latest version is .NET Core 1.1.


## Usage

Start the website with your IDE (Debug > Start Without Debugging) or execute:
```sh
$ dotnet run
```

Carsales is now up and running at http://localhost:5000/.

To run the tests:
```sh
$ cd ../Carsales.Web.UnitTests
$ dotnet xunit
```

## Concepts

### Dependency Injection

The Dependency Inversion Principle states that:
```
High level modules should not depend on low-level modules, both should depend on abstractions.
```

.NET Core MVC comes with a built-in Dependency Injection container that creates requested objects with their dependencies. The container registers all types at the application start and build a complex dependency graph between them. When an instance is requested, it goes through the dependency graph to new up all the dependant types before finally instantiating the requested type.

### Repositories

Repositories are an extra layer that aims to encapsulate the business/data access logic in one place for better code reusability and extension.
Carsales uses one repository per domain entity: one for Cars and one for Enquiries.

### AutoMapper

[AutoMapper](http://automapper.org/)'s purpose is two-fold:

* mapping one object's properties to another object
* cleaning up your controllers' actions by getting rid of mapping code that bloats them up and organize them in Profiles

### Unit Tests

The `Carsales.Web.UnitTests` project contains unit tests using [xUnit](https://xunit.github.io/) and [Moq](https://github.com/moq/moq4).
I have structured my tests so that there's a test class per class being tested and a nested class for each method being tested. Easy to read and a nice way to keep track of what has been tested.


## Notes

### Carsales.Web.Core

The Carsales.Web.Core folder couldn't be exported to its own `Carsales.Core` project due to [dependency issues](https://github.com/dotnet/coreclr/issues/10037) between .NET Core App and .NET Standard Library projects.

The End.