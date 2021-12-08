#Definition and Motivation:
A singleton is a class designed to only ever have one instance. Single instances
are often used to model shared resources, like the file system or a shared network resource or when it's logical to have multiple instance, but the cost of creating one is too heavy.

## Structure and characteristics:
 - ![Singleton Structure](https://i.imgur.com/oneopr4.png)
 - Has single, private, parameterless constructor
 - Marked as sealed (performance)
 - The only reference to the single is a private static field.
 - The rest of the application "gets" the singleton through a public static method.
 - At any time, only 0 or 1 instance of the singleton exist in the app.
 - Created without parameters.
 - Assumes lazy instantiation as the default.

## Flavors:
 - Naive implementation: it's not thread safe. Meaning multiple thread could each create a new singleton instance.
 - Thread safe implementation with locks (still has issue: https://csharpindepth.com/articles/singleton#dcl).
 - Another approach is to use C# static constructors:
   - Static constructors runs once per app domain.
   - Called when the first time any static member of a type is referenced.
   - Make sure to use an explicit static constructor to avoid issues with the C# compiler and beforeFieldInit.
   - BeforeFieldInit is a compiler trick that let's the compiler add a call to the static constructor sooner (default behavior)

## Anti-Pattern?:
  - Difficult to test due to shared state
  - Doesn't follow Separation of Concern
  - Doesn't follow Single Responsibility
  - Doesn't follow DRY
  - Better alternatives exist

## Singleton vs Static Class:
  - Singletons implement interfaces, statics can't.
  - Singletons can be instantiated (only once) and used as arguments and variables, statics can't.
  - Singletons supports polymorphism, statics are procedural.
  - Singleton can have state, statics only access the global state
  - Singleton can be serialized.

## Singletons and IoC/DI Containers:
  - .NET Core has built-in support for IoC/DI Containers.
  - Containers manage abstraction-implementation mapping (IFoo <-> FooImpl1, IFoo <-> FooImpl2).
  - Containers manages instance lifetime
  - In apps that leverage containers, classes typically request dependencies via the constructor (ideally request all of the dependencies)
  - => Manage lifetime using containers, not class design