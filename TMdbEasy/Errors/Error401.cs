using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.Errors
{
    public class Error401
    {
        public string Status_message { get; set; }
        public bool Success { get; set; }
        public int Status_code { get; set; }
    }
}
