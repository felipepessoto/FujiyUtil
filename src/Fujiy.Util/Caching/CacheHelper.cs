using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Caching;

namespace Fujiy.Util.Caching
{
    public static class CacheHelper
    {
        private static readonly ObjectCache DefaultCache = MemoryCache.Default;
        private static readonly Dictionary<string, string> KeysGroups = new Dictionary<string, string>();
        private static readonly object NullValue = new object();

        public static readonly string AnonymousGroup = string.Empty;

        /// <summary>
        /// Não foi usado Auto-Properties pois a valor inicial é true. Para isso seria necessário alterar o valor no construtor static. Construtores static degradam a performance.
        /// </summary>
        private static bool cacheEnabled = true;
        public static bool CacheEnabled { get { return cacheEnabled; } set { cacheEnabled = value; } }

        public static TResult FromCacheOrExecute<TResult>(Expression<Func<TResult>> func)
        {
            return FromCacheOrExecute(func, null, null);
        }

        public static TResult FromCacheOrExecute<TResult>(Expression<Func<TResult>> func, string key)
        {
            return FromCacheOrExecute(func, key, null);
        }

        public static TResult FromCacheOrExecute<TResult>(Expression<Func<TResult>> func, CacheItemPolicy cacheItemPolicy)
        {
            return FromCacheOrExecute(func, null, cacheItemPolicy);
        }

        public static TResult FromCacheOrExecute<TResult>(Expression<Func<TResult>> func, string key, CacheItemPolicy cacheItemPolicy)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            if (string.IsNullOrEmpty(key))
            {
                key = ExtractKeyFromExpression(func);
            }

            object returnObject = null;

            if (CacheEnabled)
            {
                returnObject = DefaultCache[key];
            }

            ExtendedCacheItemPolicy extCacheItemPolicy = cacheItemPolicy as ExtendedCacheItemPolicy;

            if (returnObject == NullValue && IsNullable<TResult>())
            {
                returnObject = default(TResult);
            }
            else
            {
                if (!(returnObject is TResult))
                {
                    if (extCacheItemPolicy != null)
                    {
                        Action initializer = extCacheItemPolicy.ExecutionInitializer;
                        if (initializer != null)
                        {
                            initializer();
                        }
                    }
                    returnObject = func.Compile()();

                    cacheItemPolicy = cacheItemPolicy ?? new CacheItemPolicy();

                    cacheItemPolicy.RemovedCallback += CacheItemRemovedCallback;

                    DefaultCache.Set(key, returnObject ?? NullValue, cacheItemPolicy);
                }
            }

            AddKeyOnGroup(extCacheItemPolicy != null ? extCacheItemPolicy.GroupName : AnonymousGroup, key);

            return (TResult)returnObject;
        }

        public static bool FromCache<TResult>(Expression<Func<TResult>> func, out TResult result)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            var key = ExtractKeyFromExpression(func);
            return FromCache(key, out result);
        }

        public static bool FromCache<TResult>(string key, out TResult result)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("A key é obrigatória", "key");
            }

            if (CacheEnabled)
            {
                object returnObject = DefaultCache[key];

                if (returnObject == NullValue && IsNullable<TResult>())
                {
                    result = default(TResult);
                    return true;
                }

                if (returnObject is TResult)
                {
                    result = (TResult)returnObject;
                    return true;
                }
            }

            result = default(TResult);
            return false;
        }

        public static void RemoveCache<TResult>(Expression<Func<TResult>> func)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            string key = ExtractKeyFromExpression(func);

            DefaultCache.Remove(key);
        }

        public static void ClearCache()
        {
            foreach (KeyValuePair<string, object> a in DefaultCache)
            {
                DefaultCache.Remove(a.Key);
            }
        }

        private static string ExtractKeyFromExpression<TResult>(Expression<Func<TResult>> func)
        {
            MethodCallExpression method = func.Body as MethodCallExpression;

            if (method == null)
            {
                throw new InvalidCachedFuncException("Body must be MethodCallExpression to auto generate a cache key");
            }

            string key = CacheKeyGenerator.GenerateKey(method);
            return key;
        }

        #region Groups

        public static ILookup<string, string> GetAllKeys()
        {
            lock (KeysGroups)
            {
                return KeysGroups.ToLookup(x => x.Value, x => x.Key);
            }
        }

        public static IEnumerable<string> GetKeysByGroup(string groupName)
        {
            lock (KeysGroups)
            {
                return KeysGroups.Where(x => x.Value == groupName).Select(x => x.Key).ToList();
            }
        }

        public static IEnumerable<string> Groups
        {
            get
            {
                lock (KeysGroups)
                {
                    return KeysGroups.Values.Distinct().ToList();
                }
            }
        }

        public static void RemoveCacheByGroup(string groupName)
        {
            IEnumerable<string> chaves = GetKeysByGroup(groupName);
            foreach (string chave in chaves)
            {
                DefaultCache.Remove(chave);
            }
        }

        private static void AddKeyOnGroup(string nomeGrupo, string chave)
        {
            lock (KeysGroups)
            {
                KeysGroups[chave] = nomeGrupo;
            }
        }

        private static void CacheItemRemovedCallback(CacheEntryRemovedArguments arguments)
        {
            lock (KeysGroups)
            {
                KeysGroups.Remove(arguments.CacheItem.Key);
            }
        }

        #endregion

        private static bool IsNullable<T>()
        {
            return default(T) == null;
        }
    }
}
