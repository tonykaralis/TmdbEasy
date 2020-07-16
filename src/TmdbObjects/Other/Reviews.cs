using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Other
{
    public class Reviews
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Iso_639_1 { get; set; }
        public int Media_id { get; set; }
        public string Media_title { get; set; }
        public string Media_type { get; set; }
        public string Url { get; set; }
    }

    public class ReviewsBase
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
    }

    public class UserReviews
    {
        public int Id { get; set; }
        public int Page { get; set; }
        public List<ReviewsBase> Results { get; set; }
        public int Total_pages { get; set; }
        public int Total_results { get; set; }
    }
}
