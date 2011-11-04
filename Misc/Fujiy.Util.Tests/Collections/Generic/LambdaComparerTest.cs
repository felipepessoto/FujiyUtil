using System;
using Fujiy.Util.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fujiy.Util.Tests.Collections.Generic
{
    [TestClass]
    public class LambdaComparerTest
    {
        private class ContainerClass
        {
            public readonly int Valor;
            public ContainerClass(int valor)
            {
                Valor = valor;
            }
        }

        [TestMethod]
        public void TestarEquals()
        {
            //Arrange
            LambdaComparer<ContainerClass>  lambdaComparer = new LambdaComparer<ContainerClass>((x,y)=> x.Valor == y.Valor);
            
            //Act
            bool deveSerTrue = lambdaComparer.Equals(new ContainerClass(1), new ContainerClass(1));
            bool deveSerFalse = lambdaComparer.Equals(new ContainerClass(1), new ContainerClass(2));

            //Assert
            Assert.IsTrue(deveSerTrue);
            Assert.IsFalse(deveSerFalse);
        }

        [TestMethod]
        public void TestarGetHashCode()
        {
            //Arrange
            LambdaComparer<ContainerClass> lambdaComparer = new LambdaComparer<ContainerClass>((x, y) => x.Valor == y.Valor, x => x.Valor * 10);

            //Act
            int hashCode1 = lambdaComparer.GetHashCode(new ContainerClass(1));
            int hashCode2 = lambdaComparer.GetHashCode(new ContainerClass(15));
            int hashCode3 = lambdaComparer.GetHashCode(new ContainerClass(20));

            //Assert
            Assert.AreEqual(10, hashCode1);
            Assert.AreEqual(150, hashCode2);
            Assert.AreEqual(200, hashCode3);
        }

        [TestMethod]
        public void TestarConstrutorHashNullException()
        {
            //Act
            try
            {
                new LambdaComparer<ContainerClass>((x, y) => x.Valor == y.Valor, null);
                Assert.Fail("Deveria ter disparado exception no construtor");
            }
            catch(ArgumentNullException ex)
            {
                //Assert
                Assert.AreEqual(ex.ParamName, "lambdaHash");
            }
        }

        [TestMethod]
        public void TestarConstrutorComparerNullException()
        {
            //Act
            try
            {
                new LambdaComparer<ContainerClass>(null);
                Assert.Fail("Deveria ter disparado exception no construtor");
            }
            catch (ArgumentNullException ex)
            {
                //Assert
                Assert.AreEqual(ex.ParamName, "lambdaComparer");
            }
        }
    }
}
