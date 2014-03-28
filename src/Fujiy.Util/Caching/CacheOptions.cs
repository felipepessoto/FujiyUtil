using System;
using System.Runtime.Caching;

namespace Fujiy.Util.Caching
{
    public class ExtendedCacheItemPolicy : CacheItemPolicy
    {
        public ExtendedCacheItemPolicy()
        {
            GroupName = CacheHelper.AnonymousGroup;
        }

        public string GroupName { get; set; }

        public Action ExecutionInitializer { get; set; }
    }
}
