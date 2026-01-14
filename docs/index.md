---
_layout: landing
---

- [ForceClient](~/api/NetCoreForce.Client.ForceClient.yml)
    - [NetcoreForce.Client](~/api/NetCoreForce.Client.yml)


# maccettura/NetCoreForce 

A fork of https://github.com/anthonyreilly/NetCoreForce

## A .NET Standard and .NET Core Salesforce REST API integration library
*This project is not offered, sponsored, or endorsed by Salesforce.*

![NuGet Downloads](https://img.shields.io/nuget/dt/NetCoreForce.Client)  

[Documentation](https://anthonyreilly.github.io/NetCoreForce/)  

## Library Targets

Full target list
- .NET 8.0
- .NET 9.0
- .NET 10.0


### [CHANGELOG](CHANGELOG.md)  

CI main:  
[![CI](https://github.com/anthonyreilly/NetCoreForce/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/anthonyreilly/NetCoreForce/actions/workflows/ci.yml)  
CI dev:  
[![CI](https://github.com/anthonyreilly/NetCoreForce/actions/workflows/ci.yml/badge.svg?branch=dev)](https://github.com/anthonyreilly/NetCoreForce/actions/workflows/ci.yml)



### Projects in this solution:
* [NetCoreForce.Client](src/NetCoreForce.Client)
    - Main library  

### NuGet Packages
* [NetCoreForce.Client](https://www.nuget.org/packages/NetCoreForce.Client/)

### Designed to minimize dependencies:
* [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) (JSON Serialization)
* [System.Text.Encodings.Web](https://www.nuget.org/packages/System.Text.Encodings.Web) (URL formatting)

(Migration from Newtonsoft.Json to System.Text.Json is planned)

Feedback and suggestions welcome.

Licensed under the MIT license.