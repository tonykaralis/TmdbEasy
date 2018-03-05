using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.ApiInterfaces
{
    public interface ICreator
    {
        Lazy<T> GetApi<T>() where T : IBase;
    }
}
