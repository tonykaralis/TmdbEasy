using System;

namespace TMdbEasy.TmdbObjects.Images
{
    public class Image
    {
        public Uri Width45 { get; }
        public Uri Width92 { get; }
        public Uri Width154 { get; }
        public Uri Width185 { get; }
        public Uri Width300 { get; }
        public Uri Width342 { get; }
        public Uri Width500 { get; }
        public Uri Width1280 { get; }

        public Uri Height632 { get; }

        public Uri Original { get; }



        /// <summary>
        /// Initialize a new <see cref="Image"/> instance.
        /// </summary>
        /// <param name="address">Non null string.
        /// Format: "http://image.tmdb.org/t/p/" or
        /// "https://image.tmdb.org/t/p/".</param>
        /// <param name="imagePath">Non null relative image path.
        /// Format: "/{a-Z,0-9}.jpg"</param>
        public Image(string address, string imagePath)
        {
            Width45 = new Uri($"{address}w45{imagePath}");
            Width92 = new Uri($"{address}w92{imagePath}");
            Width154 = new Uri($"{address}w154{imagePath}");
            Width185 = new Uri($"{address}w185{imagePath}");
            Width300 = new Uri($"{address}w300{imagePath}");
            Width342 = new Uri($"{address}w342{imagePath}");
            Width500 = new Uri($"{address}w500{imagePath}");
            Width1280 = new Uri($"{address}w1280{imagePath}");

            Height632 = new Uri($"{address}h632{imagePath}");

            Original = new Uri($"{address}original{imagePath}");
        }
    }
}
