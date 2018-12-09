using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TMdbEasy.TmdbObjects.Movies;
using TMdbEasy.TmdbObjects.Other;
using TMdbEasy.TmdbObjects.TV;

namespace TMdbEasy.Parsers
{
    internal class SearchPersonParser : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                JArray knownForArray = JArray.Load(reader);
                if (knownForArray != null)
                {
                    var movies = new List<Movie>();
                    var tv = new List<BasicTvDetails>();

                    foreach (var knownForResult in knownForArray)
                    {
                        JToken mediaType = knownForResult["media_type"];
                        string mediaTypeValue = mediaType.ToString();
                        string item = JsonConvert.SerializeObject(mediaType.Parent.Parent);

                        if (mediaTypeValue != null && mediaTypeValue.Equals("movie"))
                        {
                            movies.Add(JsonConvert.DeserializeObject<Movie>(item));
                        }
                        else if (mediaTypeValue != null && mediaTypeValue.Equals("tv"))
                        {
                            tv.Add(JsonConvert.DeserializeObject<BasicTvDetails>(item));
                        }
                    }

                    return new KnownForContainer(tv, movies);
                }
            }

            return "";
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
