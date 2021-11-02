---
theme: gaia
class: invert
paginate: true

---
# Refactoring `PdfTools`

* Written without any design
* Some pdf and qrcode features
* Download of files
* Concatenate files

---
# Issues in `PdfTools`

* Duplicate code
* Un-testable
* No [SRP]
* Hard to extend
* Hard to reuse components

---
# Demo "PdfTools"

---
# Challenge

* How do I clean up brownfield projects?
* Without rewriting them?
* Without breaking them?
* Where do I start?

---
# Extract code [SRP]

1. Extract code to method
2. Extract code to class

__Demo: Barcode Code__

:bulb: Tip: Create a documentation of the class without "and"

---
# [Zero Impact Injection]

1. Add interface to class
2. Inject as interface into class
3. Use `??` for default implementation

__Demo: Barcode class__

---
# [Null-Object Pattern]

* "Identity Element" for an interface
* Empty implementation
* Returns `default`
* IFooBar --> EmptyFooBar
* Implemented along with Interface

__Demo: Empty barcode class__

---
# Organise code

* Per feature
* Per interface
* Per tier

:bulb: Tip: Separating projects help on cleaning the dependencies

