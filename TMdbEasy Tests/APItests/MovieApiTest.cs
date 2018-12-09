using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.TmdbObjects.Other;
using SUT = TMdbEasy;

namespace TMdbEasy_Tests.APItests
{
    internal static class MovieApiTest
    {
        [TestFixture]
        [Category("MovieApi")]
        public class GetDetailsAsync
        {
            [TestCase(5018857)]
            public void IncorrectId_ThrowsException(int id, string language = "en")
            {
                var d = Constants.SecureTestClient.GetApi<IMovieApi>().Value;

                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Movies.MovieFullDetails mov = d.GetDetailsAsync(id).Result; });
            }
        }

        [TestFixture]
        [Category("MovieApi")]
        public class GetImagesAsync
        {
            [TestCase(296096321)]
            public void IncorrectId_ThrowsException(int id, string language = "en")
            {
                var d = Constants.SecureTestClient.GetApi<IMovieApi>().Value;

                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Images.Images ima = d.GetImagesAsync(id).Result; });
            }
        }

        [TestFixture]
        [Category("MovieApi")]
        public class GetAlternativetitlesAsync
        {
            [TestCase(296096321)]
            public void IncorrectId_ThrowsException(int id, string language = "en")
            {
                var d = Constants.SecureTestClient.GetApi<IMovieApi>().Value;

                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Movies.AlternativeTitle tit = d.GetAlternativeTitlesAsync(id).Result; });
            }
        }

        [TestFixture]
        [Category("MovieApi")]
        public class SearchByActorAsync
        {
            [TestCase("Stephen Amell")]
            public void Can_Deserialize_TV_Media_Type(string name)
            {
                var d = Constants.SecureTestClient.GetApi<IMovieApi>().Value;


                List<PersonFromSearch> people = d.SearchByActorAsync(name).Result.Results;


                CollectionAssert.IsNotEmpty(people, "people.IsNotEmpty");
                Assert.That(people.Count, Is.EqualTo(1), "people.Count");
                Assert.That(people[0].KnownFor.Television.Count, Is.GreaterThanOrEqualTo(2), "KnownFor.Television.Count");
            }

            [TestCase("Brad Pitt")]
            public void Can_Deserialize_Movie_Media_Type(string name)
            {
                var d = Constants.SecureTestClient.GetApi<IMovieApi>().Value;

                List<PersonFromSearch> people = d.SearchByActorAsync(name).Result.Results;

                CollectionAssert.IsNotEmpty(people, "people.IsNotEmpty");
                Assert.That(people.Count, Is.EqualTo(1), "people.Count");
                Assert.That(people[0].KnownFor.Movies.Count, Is.GreaterThanOrEqualTo(3), "KnownFor.Movies.Count");
            }
        }
    }
}
