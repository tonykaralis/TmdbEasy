# TMdbEasy

[![Build Status](https://dev.azure.com/tkaralis/TmdbEasy/_apis/build/status/Build%20%26%20test?branchName=master)](https://dev.azure.com/tkaralis/TmdbEasy/_build/latest?definitionId=3&branchName=master)
[![Nuget Package](https://badgen.net/nuget/v/TmdbEasy)](https://www.nuget.org/packages/TMdbEasy/)
[![Nuget](https://img.shields.io/nuget/dt/TmdbEasy)](https://www.nuget.org/packages/TMdbEasy/)

A simple and lightweight class library that wraps [The Movie Database](https://www.themoviedb.org/) api and makes it extremely easy to use. 
The library currently supports version 3 of the API.

## Getting Started


## Using the library


### Examples


## JSON Deserialization 
[Newtonsoft](https://www.newtonsoft.com/json) is used for the deserialization of all http responses.

If for whatever reason, you wish to use a different deserializer with TmdbEasy, this can be done easily by implementing the `IJsonDeserializer` interface and registering the implementation with your DI container.

## Author
* [Tony Karalis](https://github.com/tonykaralis)

## Contributors
![https://github.com/tonykaralis/TMdbEasy/graphs/contributors](https://contributors-img.web.app/image?repo=tonykaralis/TMdbEasy)

## License
Copyright © Tony Karalis and contributors.

TmdbEasy is provided as-is under the MIT license. For more information see [LICENSE](LICENSE).

## Attribution
All film-related data and metadata gathered via this library is supplied by [The Movie Database](https://www.themoviedb.org/) (TMDb).
TmdbEasy uses the TMDb API but is not endorsed or certified in any way by TMDb.

![https://www.themoviedb.org/](https://github.com/tonykaralis/TMdbEasy/blob/v1-refactor/TheMovieDb-logo.png)

Contributor images made with [contributors-img](https://contributors-img.web.app).
