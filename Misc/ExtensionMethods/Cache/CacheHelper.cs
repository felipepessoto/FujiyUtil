using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Xml;
using System.Globalization;

namespace Fujiy.Util.Cache
{
    public static class CacheHelper
    {
        private static readonly ValidType[] ValidWrappingGenericTypes = new[] { new ValidType(typeof(Nullable<>)) };
        private static readonly Dictionary<string, string> KeysGroups = new Dictionary<string, string>();
        public static readonly string AnonymousGroup = string.Empty;
        private static readonly ValidType[] ValidTypes = new[]
                             {
                                 new ValidType(typeof (byte)),
                                 new ValidType(typeof (sbyte)),
                                 new ValidType(typeof (int)),
                                 new ValidType(typeof (uint)),
                                 new ValidType(typeof (short)),
                                 new ValidType(typeof (ushort)),
                                 new ValidType(typeof (long)),
                                 new ValidType(typeof (ulong)),
                                 new ValidType(typeof (float)),
                                 new ValidType(typeof (double)),
                                 new ValidType(typeof (char)),
                                 new ValidType(typeof (bool)),
                                 new ValidType(typeof (string)),
                                 new ValidType(typeof (decimal)),
                                 new ValidType(typeof (DateTime)),
                                 new ValidType(typeof (DateTimeOffset)),
                                 new ValidType(typeof (Guid))
                             };

        /// <summary>
        /// Não foi usado Auto-Properties pois a valor inicial é true. Para isso seria necessário alterar o valor no construtor static. Construtores static degradam a performance.
        /// </summary>
        private static bool cacheEnabled = true;
        public static bool CacheEnabled { get { return cacheEnabled; } set { cacheEnabled = value; } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Não há outra técnica para isto. E não aumenta a complexidade já que a expression é um syntactic sugar, o cliente apenas escreve um lambda")]
        public static TResult FromCacheOrExecute<TResult>(this System.Web.Caching.Cache cache, Expression<Func<TResult>> func)
        {
            return FromCacheOrExecute(cache, func, null, null);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Não há outra técnica para isto. E não aumenta a complexidade já que a expression é um syntactic sugar, o cliente apenas escreve um lambda")]
        public static TResult FromCacheOrExecute<TResult>(this System.Web.Caching.Cache cache, Expression<Func<TResult>> func, string key)
        {
            return FromCacheOrExecute(cache, func, key, null);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Não há outra técnica para isto. E não aumenta a complexidade já que a expression é um syntactic sugar, o cliente apenas escreve um lambda")]
        public static TResult FromCacheOrExecute<TResult>(this System.Web.Caching.Cache cache, Expression<Func<TResult>> func, CacheOptions cacheOptions)
        {
            return FromCacheOrExecute(cache, func, null, cacheOptions);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "3", Justification = "func é validado no método ValidateFunc"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Não há outra técnica para isto. E não aumenta a complexidade já que a expression é um syntactic sugar, o cliente apenas escreve um lambda")]
        public static TResult FromCacheOrExecute<TResult>(this System.Web.Caching.Cache cache, Expression<Func<TResult>> func, string key, CacheOptions cacheOptions)
        {
            if (cache == null)
                throw new ArgumentNullException("cache");

            ValidateFunc(func);

            cacheOptions = cacheOptions ?? new CacheOptions();

            if (string.IsNullOrEmpty(key))
            {
                MethodCallExpression metodo = ((MethodCallExpression) func.Body);
                ValidateArguments(metodo);
                key = GenerateKey(metodo);
            }

            AddKeyOnGroup(cacheOptions.GroupName, key);

            object returnObject = null;

            if (CacheEnabled)
            {
                returnObject = cache[key];
            }

            if (!(returnObject is TResult))
            {
                Action initializer = cacheOptions.ExecutionInitializer;
                if (initializer != null)
                {
                    initializer();
                }
                returnObject = func.Compile()();
                if (returnObject != null)
                {
                    cache.Add(key, returnObject, cacheOptions.Dependencies, cacheOptions.AbsoluteExpiration,
                              cacheOptions.SlidingExpiration, cacheOptions.Priority, CacheItemRemovedCallback);
                }
            }
            return (TResult) returnObject;
        }

        #region Groups

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "O método pode demorar caso tenha muitas chaves, além de poder gerar resultados diferentes em duas chamadas consecutivas.")]
        public static ILookup<string, string> GetAllKeys()
        {
            lock (KeysGroups)
            {
                return KeysGroups.ToLookup(x => x.Value, x => x.Key);
            }
        }

        public static ReadOnlyCollection<string> GetKeysByGroup(string groupName)
        {
            lock (KeysGroups)
            {
                return KeysGroups.Where(x => x.Value == groupName).Select(x => x.Key).ToList().AsReadOnly();
            }
        }

        public static ReadOnlyCollection<string> Groups
        {
            get
            {
                lock (KeysGroups)
                {
                    return KeysGroups.Values.Distinct().ToList().AsReadOnly();
                }
            }
        }

        public static void RemoveCacheByGroup(string groupName)
        {
            IEnumerable<string> chaves = GetKeysByGroup(groupName);
            foreach (string chave in chaves)
            {
                HttpRuntime.Cache.Remove(chave);
            }
        }

        public static void ClearCache()
        {
            foreach (DictionaryEntry cache in HttpRuntime.Cache)
            {
                HttpRuntime.Cache.Remove(cache.Key.ToString());
            }
        }

        private static void AddKeyOnGroup(string nomeGrupo, string chave)
        {
            lock (KeysGroups)
            {
                KeysGroups[chave] = nomeGrupo;
            }
        }

        private static void CacheItemRemovedCallback(string chave, object value, CacheItemRemovedReason reason)
        {
            lock (KeysGroups)
            {
                KeysGroups.Remove(chave);
            }
        }

        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "MethodCallExpression")]
        private static void ValidateFunc<TResult>(Expression<Func<TResult>> func)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            if(!(func.Body is MethodCallExpression))
            {
                throw new InvalidCachedFuncException("Body must be MethodCallExpression");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
        private static void ValidateArguments(MethodCallExpression method)
        {
            for (int i = 0; i < method.Arguments.Count; i++)
            {
                if (!IsValidType(method.Arguments[i].Type))
                {
                    throw new InvalidCacheArgumentException(string.Format(CultureInfo.CurrentCulture, "Não foi possível inferir uma chave a partir dos parâmetros. Indice do parametro: {0}. Tipo: {1}", i, method.Arguments[i].Type));
                }
            }
        }

        private static bool IsValidType(Type type)
        {
            if (type.IsGenericType)
            {
                Type genericType = type.GetGenericTypeDefinition();

                if (ValidWrappingGenericTypes.Any(t => genericType == t.Type) && type.GetGenericArguments().Except(ValidTypes.Select(x => x.Type)).Count() == 0)
                {
                    return true;
                }
            }

            return ValidTypes.Any(t => type == t.Type);
        }

        private static string GenerateKey(MethodCallExpression method)
        {
            string chave = method.Method.ReflectedType.FullName + ": " + method.Method + ". Param Count:" + method.Arguments.Count + ". Params:";

            object[] valoresArgumentos = new object[method.Arguments.Count];

            for (int i = 0; i < valoresArgumentos.Length; i++)
            {
                valoresArgumentos[i] = GetArgumentValue(method.Arguments[i]);
            }

            for (int i = 0; i < valoresArgumentos.Length; i++)
            {
                chave += FormatValue(valoresArgumentos[i]) + ",";
            }

            return chave.TrimEnd(new[] {','});
        }

        private static string FormatValue(object value)
        {
            if(value == null)
                return null;

            if(value is byte)
                return XmlConvert.ToString((byte)value);
            if (value is sbyte)
                return XmlConvert.ToString((sbyte)value);
            if (value is int)
                return XmlConvert.ToString((int)value);
            if (value is uint)
                return XmlConvert.ToString((uint)value);
            if (value is short)
                return XmlConvert.ToString((short)value);
            if (value is ushort)
                return XmlConvert.ToString((ushort)value);
            if (value is long)
                return XmlConvert.ToString((long)value);
            if (value is ulong)
                return XmlConvert.ToString((ulong)value);
            if (value is float)
                return XmlConvert.ToString((float)value);
            if (value is double)
                return XmlConvert.ToString((double)value);
            if (value is char)
                return XmlConvert.ToString((char)value);
            if (value is bool)
                return XmlConvert.ToString((bool)value);
            string stringValue = value as string;
            if (stringValue != null)
                return stringValue;
            if (value is decimal)
                return XmlConvert.ToString((decimal)value);
            if (value is DateTime)
                return XmlConvert.ToString((DateTime)value, XmlDateTimeSerializationMode.RoundtripKind);
            if (value is DateTimeOffset)
                return XmlConvert.ToString((DateTimeOffset)value);
            if (value is Guid)
                return XmlConvert.ToString((Guid)value);

            throw new InvalidCacheArgumentException();
        }

        private static object GetArgumentValue(Expression element)
        {
            LambdaExpression l = Expression.Lambda(Expression.Convert(element, element.Type));
            return l.Compile().DynamicInvoke();
        }

        private class ValidType
        {
            public readonly Type Type;
            //public readonly bool AcceptSubClass;

            public ValidType(Type type)
            {
                Type = type;
            }

            //public ValidType(Type type, bool acceptSubClass)
            //{
            //    Type = type;
            //    AcceptSubClass = acceptSubClass;
            //}
        }
    }
}
