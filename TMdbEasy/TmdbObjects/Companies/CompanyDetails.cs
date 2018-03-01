using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Companies
{
    public class CompanyDetails
    {
        public object Description { get; set; }
        public string Headquarters { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public object Logo_path { get; set; }
        public string Name { get; set; }
        public object Parent_company { get; set; }
    }
}
