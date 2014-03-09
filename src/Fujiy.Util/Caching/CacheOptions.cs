using System;
using System.Web.Caching;

namespace Fujiy.Util.Caching
{
    /// <summary>
    /// Especifica opcões para um item do Cache.
    /// </summary>
    /// <remarks>Os valores Iniciais são:
    /// AbsoluteExpiration = Cache.NoAbsoluteExpiration
    /// SlidingExpiration = Cache.NoSlidingExpiration
    /// Priority = CacheItemPriority.Normal
    /// GroupName = CacheHelper.AnonymousGroup
    /// </remarks>
    public class CacheOptions
    {
        public DateTime AbsoluteExpiration { get; set; }
        public TimeSpan SlidingExpiration { get; set; }
        public CacheItemPriority Priority { get; set; }
        public string GroupName { get; set; }

        public Action ExecutionInitializer { get; set; }
        public CacheDependency Dependencies { get; set; }

        public CacheOptions()
        {
            AbsoluteExpiration = Cache.NoAbsoluteExpiration;
            SlidingExpiration = Cache.NoSlidingExpiration;
            Priority = CacheItemPriority.Normal;
            GroupName = CacheHelper.AnonymousGroup;
        }
    }
}
