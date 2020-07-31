# TMdbEasy

[![Build Status](https://dev.azure.com/tkaralis/TmdbEasy/_apis/build/status/Build%20%26%20test?branchName=master)](https://dev.azure.com/tkaralis/TmdbEasy/_build/latest?definitionId=3&branchName=master)
[![Build Status](https://vsrm.dev.azure.com/tkaralis/_apis/public/Release/badge/53416a01-457a-468c-b80d-e3d18d0bdd1a/1/1)](https://vsrm.dev.azure.com/tkaralis/_apis/public/Release/badge/53416a01-457a-468c-b80d-e3d18d0bdd1a/1/1)

[![Nuget Package](https://badgen.net/nuget/v/TmdbEasy)](https://www.nuget.org/packages/TMdbEasy/)
[![Nuget](https://img.shields.io/nuget/dt/TmdbEasy)](https://www.nuget.org/packages/TMdbEasy/)

[![License](https://badgen.net/badge/license/MIT/blue)](LICENSE)

A simple and lightweight class library that wraps [The Movie Database](https://www.themoviedb.org/) api and makes it super easy to get movie/tv/actor data and more.

## Installation

Via Package Manager:
```
Install-Package TMdbEasy
```

Via .NET CLI
```
dotnet add package TMdbEasy
```

## .NET Core Configuration

If your application uses an IOC container then the simplest and advised way to set up TmdbEasy is to register all the key services with the IOC container. *TmdbEasy also works just fine with apps that dont use an IOC container.*

TmdbEasy comes with baked in support for ASP.NET Core's default IOC container via an extension method called `AddTmdbEasy()`.

Using the method as shown below will register all the required TmdbEasy services for you.
``` csharp
public void ConfigureServices(IServiceCollection services)
{
    services.Configure<CookiePolicyOptions>(options =>
    {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });
    
    // Adds TmdbEasy to your app
    services.AddTmdbEasy();
    
    // Other service registrations    
    services.AddAuthentication();

    services.AddMvc();

    services.AddAntiforgery();
}
```

The `AddTmdbEasy()` method accepts an immutable options parameter that allows configuration of TmdbEasy at a global level.
``` csharp
public TmdbEasyOptions(string apiKey = null, bool useSsl = true, string defaultLanguage = "en")
{
    ApiKey = apiKey;
    UseSsl = useSsl;
    DefaultLanguage = defaultLanguage;
}
```
All requests will default to using the `apiKey` and `language` properties set at this level. This can however be overriden on a *per request* basis, should your app opt to use different api keys/languages for different users.

## Supported Services
As of ***v1*** the following services are supported. We aim to add more over the coming months.
- IMovieApi
- IConfigApi
- IReviewApi
- IChangesApi
- ICompaniesApi
- ICollectionApi
- ICreditApi
- INetworksApi
- ITelevisionApi - *Untested*
## Usage
We have attempted to mirror the TMDb api as closely as possible and believe the methods are super simple to use. There really isnt that much to say. Inject the service api of your choice and off you go. Lets look at a few examples:

Inject the `IMovieApi` into a controller and find a specific movie
``` csharp
public class MovieController : Controller
{
    private readonly IMovieApi _movieApi;

    public HomeController(IMovieApi movieApi)
    {
        _movieApi = movieApi;
    }

    public async Task<IActionResult> Index()
    {
        int movieId = 550; //taken from the UI or wherever
        
        var movie = await _movieApi.GetDetailsAsync(movieId);

        return View(movie);
    }
}
```

This time we will override the default `apiKey`and `language`.
``` csharp
public class MovieController : Controller
{
    private readonly IMovieApi _movieApi;
    private readonly IUserService _userService;
    
    public HomeController(IMovieApi movieApi, IUserService userService)
    {
        _movieApi = movieApi;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        int movieId = 550; //taken from the UI or wherever
        
        string apiKey = "xyz123"; // tyically you'd get this from the HttpContext or Database etc
        
        string language = "en"; // get the users chosen language from somewhere
        
        var movie = await _movieApi.GetDetailsAsync(movieId, language, apiKey);

        return View(movie);
    }
}
```

## JSON Deserialization 
[Newtonsoft](https://www.newtonsoft.com/json) is used for the deserialization of all http responses.

If for whatever reason, you wish to use a different JSON deserializer with TmdbEasy, this can be done easily by implementing the `IJsonDeserializer` interface and registering the implementation with your IOC container.

## How to contribute
1. Fork the repo
2. Create an account on the (The Movie DB - https://www.themoviedb.org/)
3. Get a free Api Key under Profile & Settings -> Settings -> API -> API KEY (v3 auth)
4. Add the key as an environment variable on your machine with the name `tmdbapikey` (you'll need this to run integration tests)
5. Make changes and test (update tests appropriately)
6. Submit a PR

## Contributors
![https://github.com/tonykaralis/TMdbEasy/graphs/contributors](https://contributors-img.web.app/image?repo=tonykaralis/TMdbEasy)

## License
Copyright © Tony Karalis and contributors.

TmdbEasy is provided as-is under the MIT license. For more information see [LICENSE](LICENSE).

## Acknowledgements
All film-related data and metadata gathered via this library is supplied by [The Movie Database](https://www.themoviedb.org/) (TMDb).
TmdbEasy uses the TMDb API but is not endorsed or certified in any way by TMDb.

![https://www.themoviedb.org/](https://github.com/tonykaralis/TMdbEasy/blob/v1-refactor/TheMovieDb-logo.png)
