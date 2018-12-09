using NUnit.Framework;
using System;
using System.Net.Http;
using TMdbEasy.TmdbObjects.Images;

namespace TMdbEasy_Tests.TmdbObjects.Images
{
    class ImageContainerTests
    {
        private static readonly HttpClient _restClient = new HttpClient();



        [TestCase("/2ZIvieSjzfA4c8YHxs3jgHJPBta.jpg")]
        public void Check_Every_HTTP_Image_Size_Exists(string imagePath)
        {
            var imageContainer = new ImageContainer(imagePath);

            AssertImages(imageContainer.Http);
        }

        [TestCase("/2ZIvieSjzfA4c8YHxs3jgHJPBta.jpg")]
        public void Check_Every_HTTPS_Image_Size_Exists(string imagePath)
        {
            var imageContainer = new ImageContainer(imagePath);

            AssertImages(imageContainer.Secure);
        }


        private void AssertImages(Image image)
        {
            AssertImageExists(image.Width45);
            AssertImageExists(image.Width92);
            AssertImageExists(image.Width154);
            AssertImageExists(image.Width185);
            AssertImageExists(image.Width300);
            AssertImageExists(image.Width342);
            AssertImageExists(image.Width500);
            AssertImageExists(image.Width1280);

            AssertImageExists(image.Height632);

            AssertImageExists(image.Original);
        }

        private void AssertImageExists(Uri url)
        {
            var httpResponseMessage = CallURL(url);

            Assert.True(IsSuccessCall(httpResponseMessage), $"{url} does not exists!");
        }

        private HttpResponseMessage CallURL(Uri url)
        {
            return _restClient.GetAsync(url)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private bool IsSuccessCall(HttpResponseMessage serverResponse)
        {
            return serverResponse.IsSuccessStatusCode;
        }
    }
}
