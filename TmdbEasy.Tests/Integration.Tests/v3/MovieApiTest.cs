//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TMdbEasy.ApiInterfaces;
//using SUT = TMdbEasy;

//namespace TMdbEasy_Tests.APItests
//{
//    internal static class MovieApiTest
//    {
//        [TestFixture]
//        [Category("MovieApi")]
//        public class GetDetailsAsync
//        {
//            [TestCase(5018857)]
//            public void IncorrectId_ThrowsException(int id, string language = "en")
//            {
//                var d = Constants.SecureTestClient.GetApi<IMovieApi>().Value;

//                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Movies.MovieFullDetails mov = d.GetDetailsAsync(id).Result; });
//            }
//        }

//        [TestFixture]
//        [Category("MovieApi")]
//        public class GetImagesAsync
//        {
//            [TestCase(296096321)]
//            public void IncorrectId_ThrowsException(int id, string language = "en")
//            {
//                var d = Constants.SecureTestClient.GetApi<IMovieApi>().Value;

//                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Images.Images ima = d.GetImagesAsync(id).Result; });
//            }
//        }

//        [TestFixture]
//        [Category("MovieApi")]
//        public class GetAlternativetitlesAsync
//        {
//            [TestCase(296096321)]
//            public void IncorrectId_ThrowsException(int id, string language = "en")
//            {
//                var d = Constants.SecureTestClient.GetApi<IMovieApi>().Value;

//                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Movies.AlternativeTitle tit = d.GetAlternativeTitlesAsync(id).Result; });
//            }
//        }

//        [TestFixture]
//        [Category("MovieApi")]
//        public class SearchByActorAsync
//        {
//            [TestCase("Brad Pitt")]
//            public void FamousActor_ReturnResults(string actorName)
//            {
//                var d = Constants.SecureTestClient.GetApi<IMovieApi>().Value;

//                CollectionAssert.IsNotEmpty(d.SearchByActorAsync(actorName).Result.Results);
//            }
//        }
//    }
//}
