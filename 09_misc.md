---
theme: gaia
class: invert
paginate: true

---
# SOLID

* Single-responsibility principle
    * Every class should have only one responsibility
* Open–closed principle
    * Software entities ... should be open for extension, but closed for modification.
* Liskov substitution principle
    * A derived class should not break behaviour of the base class
* Interface segregation principle
    * Many client-specific interfaces are better than one general-purpose interface
* Dependency inversion principle
    * Depend upon abstractions, not concretions

---
# Extension Methods

* No state
* No business logic
* Just "facade" methods

---
# Aggregation Pattern

* IGetInformation
* IAggregateGetInformation
* IAggregateGetInformation implements IGetInformation
* IAggregateGetInformation registers only with aggregate interface

---
# Tagging Interface

* Empty interface to register a class for a specific purpose

---
# 3rd party libraries

* Create separate project
* Interfaces to "contracts" project
* Empty implementation to "contracts" project
* Concrete implementation in 3rd party library
