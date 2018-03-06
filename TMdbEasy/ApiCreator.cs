using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.ApiObjects;

namespace TMdbEasy
{
    internal class ApiCreator
    {
        //private static readonly IReadOnlyDictionary<Type, Func<object>> Mapper;
        private static readonly ConcurrentDictionary<Type, ConstructorInfo> CtorMapper;

        /// <summary>
        /// Creates a concurrent dictionary
        /// </summary>
        static ApiCreator()
        {
            //Mapper = new Dictionary<Type, Func<object>>
            //    {
            //        {typeof(IMovieApi), () => new MovieApi()},
            //        {typeof(ICollectionApi), () => new CollectionApi()},
            //        {typeof(ICompaniesApi), () => new CompaniesApi()},
            //        {typeof(IChangesApi), () => new ChangesApi()},
            //        {typeof(IConfigApi), () => new ConfigApi()}
            //    };

            CtorMapper = new ConcurrentDictionary<Type, ConstructorInfo>();
        }

        /// <summary>
        /// Finds and Invokes the Constructor pf the concrete Type thta has been mapped.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T CreateApi<T>() where T : IBase
        {
            ConstructorInfo ctor = CtorMapper.GetOrAdd(typeof(T), GetCtor);

            ParameterInfo[] param = ctor.GetParameters();

            return (T)ctor.Invoke(null);

        }

        /// <summary>
        /// Returns a single constructor that has been mapped to the given Type. 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private ConstructorInfo GetCtor(Type t)
        {
            ConstructorInfo[] ctors = FindAllConstructors(t.GetTypeInfo());

            if (ctors.Length == 0)
            {
                throw new InvalidOperationException($"No public constructors were found for {t.FullName}.");
            }

            if (ctors.Length == 1)
            {
                return ctors[0];
            }
            else
            {
                throw new InvalidOperationException("Multiple Constructor Support not available. Contact the author of the API for assistance.");
            }
        }

        /// <summary>
        /// Finds and returns all available constructors for a given TypeInfo object.
        /// Currently there is only support for a single constructor per ApiInterface
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns>Single Constructor</returns>
        private ConstructorInfo[] FindAllConstructors(TypeInfo typeInfo)
        {
            TypeInfo[] concreteTypes = typeInfo.Assembly.DefinedTypes
                .Where(x => !x.IsAbstract && !x.IsInterface)
                .Where(typeInfo.IsAssignableFrom).ToArray();

            if (concreteTypes.Length != 1)
            {
                throw new NotSupportedException("No Support for multiple request interfaces.");
            }

            return concreteTypes[0].DeclaredConstructors.ToArray();
        }
    }
}
