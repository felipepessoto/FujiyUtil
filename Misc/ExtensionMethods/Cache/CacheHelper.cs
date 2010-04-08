using System;
using System.Linq.Expressions;

namespace Fujiy.Util.Cache
{
    public static class CacheHelper
    {
        private static readonly Type[] TiposValidos = new[] {typeof (string), typeof (ValueType)};
        private static readonly Type[] TiposGenericosValidos = new[] {typeof (Nullable<>)};

        public static TResult FromCacheOrExecute<TResult>(this System.Web.Caching.Cache cache, Expression<Func<TResult>> funcao)
        {
            return FromCacheOrExecute(cache, null, funcao);
        }

        public static TResult FromCacheOrExecute<TResult>(this System.Web.Caching.Cache cache, string chave, Expression<Func<TResult>> funcao)
        {
            if (string.IsNullOrEmpty(chave))
            {
                MethodCallExpression metodo = ((MethodCallExpression) funcao.Body);
                ValidarArgumentos(metodo);
                chave = GerarChave(metodo);
            }

            if (!(cache[chave] is TResult))
            {
                cache[chave] = funcao.Compile()();
            }
            return (TResult)cache[chave];
        }

        private static void ValidarArgumentos(MethodCallExpression metodo)
        {
            for (int i = 0; i < metodo.Arguments.Count; i++)
            {
                if (!IsValidType(metodo.Arguments[i].Type))
                {
                    throw new ArgumentoCacheInvalidoException("Não foi possível inferir uma chave a partir dos parâmetros. Indice do parametro: " + i);
                }
            }
        }

        private static string GerarChave(MethodCallExpression metodo)
        {
            string chave = metodo.Method.ReflectedType.FullName + ": " + metodo.Method + metodo.Arguments.Count;

            object[] valoresArgumentos = new object[metodo.Arguments.Count];

            for (int i = 0; i < valoresArgumentos.Length; i++)
            {
                valoresArgumentos[i] = ProcessaArgumento(metodo.Arguments[i]);
            }

            for (int i = 0; i < valoresArgumentos.Length; i++)
            {
                chave += "," + valoresArgumentos[i];
            }
            return chave;
        }

        private static object ProcessaArgumento(Expression element)
        {
            LambdaExpression l = Expression.Lambda(Expression.Convert(element, element.Type));
            return l.Compile().DynamicInvoke();
        }

        private static bool IsValidType(Type tipo)
        {
            if (tipo.IsGenericType)
            {
                for (int i = 0; i < TiposGenericosValidos.Length; i++)
                {
                    if (tipo.GetGenericTypeDefinition().Equals(TiposGenericosValidos[i]))
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < TiposValidos.Length; i++)
            {
                if (tipo == TiposValidos[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}