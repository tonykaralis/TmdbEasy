# TMdbEasy

Open Source class library that wraps The Movie Database Api. 
Currently all interfaces that are made available support version 3 of the Api. This wrapper provides all the basic requests 
and supports TheMovieDB's append_to_response functionality as well as filtering and sorting.

## Getting Started

Currently just clone or fork the repo and include the reference in your project. 
The package will be made available via nuget shortly.

All methods that make requests to the TMDb Api are async.

I have also tried to add as much intellisense support as I can for the moment.

## Using the library

In order to make use of any of the features contained in this library you must create an instance of 'EasyClient' 
and pass as the parameter the TMDB Api key acquired from the [themoviedb.org](https://www.themoviedb.org/). If you do not do so
any further usage will throw exceptions.

You may see the 'EasyClient' object as your main entry point to the library, which makes things much simpler for you.
There are a few public functions available via this object:

```C#    
  // The find method makes it easy to search for objects in the database by an external id. For example, an IMDB ID.
  // This method will search all objects(movies, TV shows and people) and return the results in a single response.       
  public async Task<ObjectCollection> FindAsync(string id, string external_id, string language = "en");
     
  /// Get the details of a list.
  /// </summary>       
  public async Task<ListDetails> GetListDetailsAsync(string id, string language = "en");    
```
A couple more functions may still be added.

The core of your work though will be done by providing interfaces to the following method and receiving concrete implementations
of the given interface.
```C#    
  // Creates and returns an Api Interface Implementation of type Lazy<T>.       
  public Lazy<T> GetApi<T>() where T : IBase
```

The concept is simple, I have made a bunch of Interfaces available which can be placed 
in the above method in place of T. The mothod will then generate the concrete implementation
for you and return that object.

From there you may make all the relevant requests that Interface has to offer.
Below are some of the Interfaces available, I will be rolling more out as I go.

* IMovieApi
* ICreditApi
* IConfigApi
* ICollectionApi
* ICompaniesApi
* IChangesApi
* IReviewApi
* INetworkApi

### Examples

Below we will instantiate the EasyClient object with a dummy Api Key. Then we will call 
the GetApi method using the IMovieApi interface and make a few calls to TMDb's database.

You may also choose to specify whether you wish to use SSL or not by providing a second parameter
to the constructor. This parameter defaults to true (use SSL) but you may change this by setting it to false.

Since the GetApi method returns a Lazy<T> get the value and assign to a var.

```C#    
  EasyClient easy = new EasyClient("kjhygfds8632tkfshbsakdj");
  
  var movieApi = easy.GetApi<IMovieApi>().Value;
  
  var movies = movieApi.GetDetailsAsync(500);  
  var images = movieApi.GetImagesAsync(500);
```
Most of the Interface specific methods accept various paramaters. I have tried to keep the parameters matching the actual 
Api parameters as closely as possible. 

All methods are simple and easy to understand and mimic the actual api closely.

Reading [TMDb's docs](https://developers.themoviedb.org/3/getting-started/introduction) will help to understand the Api. 
This library is extremely easy to understand and use should you not wish to expose yourself to that.



## Dependencies
The project currently depends only on the [Json.NET](https://www.newtonsoft.com/json) library
used to deserialize all responses from the api calls.

## Authors

* **Tony Karalis** - *Design and Implementation* - [tonykaralis](https://github.com/tonykaralis)

## License

This project is licensed under the GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007 - see the [LICENSE.md](LICENSE.md) file for details.
