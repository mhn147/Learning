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