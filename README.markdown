# FactoryPlus #

## Introduction ##

FactoryPlus is a library for creating objects used in testing in .NET programs.  It serves as an implementation of the [Object Mother](http://martinfowler.com/bliki/ObjectMother.html) pattern.   

FactoryPlus is inspired by [factory_girl](https://github.com/thoughtbot/factory_girl/), but will aim for simplicity with a small subset of useful features.

## Basic Usage ##


**Define how to create an object**

```c#
Factory.Define(() => new User() { Name = "Test" });
```

**Create an object**

```c#
User user = Factory.Get<User>();
```

**Named instances**

```c#
Factory.Define("adminUser", () => new User() { Name = "Test", Role = Roles.Admin });
User user = Factory.Get<User>("adminUser"); 
```

## License ##

FactoryPlus is licensed under the [MIT License](http://www.opensource.org/licenses/mit-license.php).
