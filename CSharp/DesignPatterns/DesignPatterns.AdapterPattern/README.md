# Problem?
Incompatible interfaces between a client and a service-provider (interface called).

# Definition:
 - Adapters convert the interface of one class (service-provider) into an interface a client expects.
 - Adapters also known as wrappers, because they wrap incompatible object into a compatible one.

# Kinds of Adapters:
## Object Adapters (most used):
 - Hold an instance of the adaptee.
 - Implement an adapter interface or inherit the adapter it.
 - Use composition and single inheritance.
 - ![Object Adapters Structure](https://i.imgur.com/Ea4qg1v.png)

## Class Adapters:
 - Inherit from the Adaptee.
 - Inherit from the Adapter type.
 - Require multiple inheritance.
 - ![Class Adapters Structure](https://i.imgur.com/KZYG4hs.png)
 - To implement this in c# (no multiple inheritance) we can make the Target an interface.