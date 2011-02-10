using Fujiy.Util.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Fujiy.Util.Tests.ExtensionMethods
{
    [TestClass]
    public class EnumExtensionsTest
    {
        private const string DescricaoItem1 = "DescricaoItem1";

        private enum EnumFake
        {
            [System.ComponentModel.Description(DescricaoItem1)]
            ItemComDescription,
            ItemSemDescription
        }

        [TestMethod]
        public void TestarComDescription()
        {
            //Assert
            Assert.AreEqual(DescricaoItem1, EnumFake.ItemComDescription.ToDescription());
        }

        [TestMethod]
        public void TestarSemDescription()
        {
            //Assert
            Assert.AreEqual(EnumFake.ItemSemDescription.ToString(), EnumFake.ItemSemDescription.ToDescription());
        }


        [TestMethod]
        public void TestarValorNulo()
        {
            try
            {
                //Act
                ((Enum)null).ToDescription();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                //Assert
                Assert.AreEqual("value", ex.ParamName);
            }            
        }
    }
}
