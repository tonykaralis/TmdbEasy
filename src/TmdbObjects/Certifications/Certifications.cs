using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Certifications
{
    public class US
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class CA
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class AU
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class DE
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class FR
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class NZ
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class IN
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class GB
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class NL
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class BR
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class FI
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class BG
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class E
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class PH
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class PT
    {
        public string Certification { get; set; }
        public string Meaning { get; set; }
        public int Order { get; set; }
    }

    public class CertificationsList
    {
        public List<US> US { get; set; }
        public List<CA> CA { get; set; }
        public List<AU> AU { get; set; }
        public List<DE> DE { get; set; }
        public List<FR> FR { get; set; }
        public List<NZ> NZ { get; set; }
        public List<IN> IN { get; set; }
        public List<GB> GB { get; set; }
        public List<NL> NL { get; set; }
        public List<BR> BR { get; set; }
        public List<FI> FI { get; set; }
        public List<BG> BG { get; set; }
        public List<E> ES { get; set; }
        public List<PH> PH { get; set; }
        public List<PT> PT { get; set; }
    }

    public class Certifications
    {
        public CertificationsList CertificationsList { get; set; }
    }
}
