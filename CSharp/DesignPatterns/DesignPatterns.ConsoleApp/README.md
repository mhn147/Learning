## Motivation?
 - Object creation logic becomes too convoluted.
 - Constructor is not descriptive (Name not descriptive)
 - Constructor optional parameter hell
 - Allows for a flexbible and extensible application (changing the implementation of the ShippingProvider, or introduction a new one, without having to change the 
 implementation of the ShippingCart).

## What is a Factory?
 - Objection creatiion (non-piecewise, unlike Builder) can be outsourced to:
   - A separate "static" function (Factory Method)
   - That may exist in a separate class (Factory)
   - Can create families of factories with Abstract Factory
 => A component responsible solely for the wholesale (not piecewise) creation of objects.

## Flavors:
 - Simple Factory (Simple Factory Class)
 - Factory Method (Most Used)
 - Abstract Factory:
    - In most cases Simple or Factory Method will suffice. The abstract factory encapsulate a group of factories tha have a common theme
    Without specifying their concrete classes.

## The client code no longer needs to know about the internal instantiation logic.

