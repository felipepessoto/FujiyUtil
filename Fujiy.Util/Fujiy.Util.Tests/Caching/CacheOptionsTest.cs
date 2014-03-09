using System;
using System.Web.Caching;
using Fujiy.Util.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fujiy.Util.Tests.Caching
{
    [TestClass]
    public class CacheOptionsTest
    {
        [TestMethod]
        public void TestarPropriedades()
        {
            //Arrange
            CacheOptions cacheOptions = new CacheOptions();

            //Act
            cacheOptions.Dependencies = null;
            cacheOptions.AbsoluteExpiration = DateTime.MinValue;
            cacheOptions.SlidingExpiration = TimeSpan.Zero;
            cacheOptions.Priority = CacheItemPriority.Normal;
            cacheOptions.GroupName = null;
            cacheOptions.ExecutionInitializer = null;
        }
    }
}
