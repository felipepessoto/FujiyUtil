using System;
using System.Collections.Generic;
using System.Linq;

namespace Fujiy.Util.Linq
{
    public static class Enumerable
    {
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, bool> comparer, Func<TSource, int> hashFunction)
        {
            return first.Except(second, new LambdaComparer<TSource>(comparer, hashFunction));
        }

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, bool> comparer)
        {
            return first.Except(second, new LambdaComparer<TSource>(comparer));
        }
    }
}


