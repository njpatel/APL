# Axiom Processing Language

Welcome to APL, this is a fork of `microsoft/Kusto-Query-Language`


## Original README

### Kusto Query Language

Kusto Query Language is a simple yet powerful language to query structured, semi-structured and unstructured data. It assumes relational data model of tables and columns with a minimal set of data types. The language is very expressive, easy to read and understand the query intent, and optimized for authoring experiences.

### Content

This repo contains a C# parser and a semantic analyzer as well as a translator project that generates the same libraries in Java Script. See [usage examples](src/Kusto.Language/readme.md)

### API Package

This source code is also available as a [package on nuget.org](https://www.nuget.org/packages/Microsoft.Azure.Kusto.Language/)

### Query Editor

If you need to provide a query authoring experience for the language, consider using the [Kusto language plugin for the Monaco Editor](https://github.com/Azure/monaco-kusto)


