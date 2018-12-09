using System;

namespace TMdbEasy.TmdbObjects.Images
{
    public class ImageContainer
    {
        /// <summary>
        /// Image URLs with http:// scheme.
        /// </summary>
        public Image Http { get; }

        /// <summary>
        /// Image URLs with https:// scheme.
        /// </summary>
        public Image Secure { get; }



        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="imagePath">Non null relative image path.
        /// Format: "/{a-Z,0-9}.jpg"</param>
        public ImageContainer(string imagePath)
        {
            Http   = new Image("http://image.tmdb.org/t/p/",  imagePath);
            Secure = new Image("https://image.tmdb.org/t/p/", imagePath);
        }
    }
}
