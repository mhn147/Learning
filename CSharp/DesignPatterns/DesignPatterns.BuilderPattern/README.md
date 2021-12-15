## Motivation?
 - When construction gets a little bit too complicated.
 - Some objects are simple and can be created in a single constructor call, but other objects require a lot of creation ceremony (string builder).
 - Having an object with 10 constructor arguments is not productive and it's error prone, instead opt for **piecewise** construction.
 - Builder provides an API for constructing an object step-by-step.

## Definition:
 - When piecewise object construction is complicated, provides an API for doing it succinctly