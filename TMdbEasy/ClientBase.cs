using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy
{
    public class ClientBase
    {
        /// <summary>
        /// Deserialize any tmdb type and then return that type
        /// </summary>
        /// <typeparam name="T">Tmdb object type</typeparam>
        /// <param name="content">api call reponse string</param>
        /// <returns></returns>
        protected T DeserializeJson<T>(string content)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<T>(content);
                return model;
            }
            catch
            {
                throw new JsonException();
            }
        }
        /// <summary>
        /// Accepts a ready built query string, calls the api async and 
        /// then returns the response output as a string.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        protected async static Task<string> CallApiAsync(string query)
        {
            string result;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(query);
            request.Method = "GET";
            //request.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 57.0) Gecko / 20100101 Firefox / 57.0";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            WebResponse response;
            try
            {
                response = await request.GetResponseAsync() as HttpWebResponse;
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        result = sr.ReadToEnd();
                        return result;
                    }
                }
            }
            catch
            {
                return null;
            }            
        }
    }
}
