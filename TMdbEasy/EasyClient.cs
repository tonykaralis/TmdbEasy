using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.ApiObjects;
using TMdbEasy.TmdbObjects.Movies;

namespace TMdbEasy
{
    public sealed class EasyClient : ICreator
    {
        /// <summary>
        /// In order to use the client you must provide the api key
        /// </summary>
        /// <param name="_apiKey">Tmdb Api key</param>
        /// <param name="_secure">Prefer ssl or not. Default set to true</param>
        public EasyClient(string _apiKey, bool _secure = true)
        {
            REngine.Initialize(_apiKey, _secure);
        }

        public Lazy<T> GetApi<T>() where T : IBase
        {
            var apiMapper = new ApiCreator();
            return new Lazy<T>(apiMapper.CreateApi<T>);
        }
    }

    internal class ApiCreator
    {
        private static readonly IReadOnlyDictionary<Type, Func<object>> SupportedDependencyTypeMap;
        private static readonly ConcurrentDictionary<Type, ConstructorInfo> TypeCtorMap;

        static ApiCreator()
        {
            SupportedDependencyTypeMap = new Dictionary<Type, Func<object>>
                {
                    {typeof(IMovieApi), () => new MovieApi()},
                    {typeof(ICollectionApi), () => new CollectionApi()},
                    {typeof(ICompaniesApi), () => new CompaniesApi()},
                    {typeof(IChangesApi), () => new ChangesApi()}
                };

            TypeCtorMap = new ConcurrentDictionary<Type, ConstructorInfo>();
        }

        public T CreateApi<T>() where T : IBase
        {
            ConstructorInfo ctor = TypeCtorMap.GetOrAdd(typeof(T), GetConstructor);

            ParameterInfo[] param = ctor.GetParameters();

            //if (param.Length == 0)
            //{
                return (T)ctor.Invoke(null);
            //}

            //var paramObjects = new List<object>(param.Length);
            //foreach (ParameterInfo p in param)
            //{
            //    if (SupportedDependencyTypeMap.ContainsKey(p.ParameterType) == false)
            //    {
            //        throw new InvalidOperationException($"{p.ParameterType.FullName} is not a supported dependency type for {typeof(T).FullName}.");
            //    }

            //    Func<object> typeResolver = SupportedDependencyTypeMap[p.ParameterType];

            //    paramObjects.Add(typeResolver());
            //}

            //return (T)ctor.Invoke(paramObjects.ToArray());
        }

        private ConstructorInfo GetConstructor(Type t)
        {
            ConstructorInfo[] ctors = GetAvailableConstructors(t.GetTypeInfo());

            if (ctors.Length == 0)
            {
                throw new InvalidOperationException($"No public constructors found for {t.FullName}.");
            }

            //if (ctors.Length == 1)
            //{
                return ctors[0];
            //}

            //var markedCtors = ctors
            //    .Where(x => x.IsDefined(typeof(ImportingConstructorAttribute)))
            //    .ToArray();

            //if (markedCtors.Length != 1)
            //{
            //    throw new InvalidOperationException("Multiple public constructors found.  Please mark the one to use with the FactoryConstructorAttribute.");
            //}

            //return markedCtors[0];
        }

        private ConstructorInfo[] GetAvailableConstructors(TypeInfo typeInfo)
        {
            TypeInfo[] implementingTypes = typeInfo.Assembly.DefinedTypes
                .Where(x => x.IsAbstract == false)
                .Where(x => x.IsInterface == false)
                .Where(typeInfo.IsAssignableFrom)
                .ToArray();

            if (implementingTypes.Length != 1)
            {
                throw new NotSupportedException("Multiple implementing requests per request interface is not currently supported.");
            }

            return implementingTypes[0].DeclaredConstructors.ToArray();
        }
    }
}
