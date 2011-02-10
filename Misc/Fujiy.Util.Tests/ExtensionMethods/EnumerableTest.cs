using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fujiy.Util.ExtensionMethods;

namespace Fujiy.Util.Tests.ExtensionMethods
{
    [TestClass]
    public class EnumerableTest
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
        public void TestarExcept()
        {
            //Arrange
            IEnumerable<ContainerClass> zeroADez = System.Linq.Enumerable.Range(0, 10).Select(x=> new ContainerClass(x));
            IEnumerable<ContainerClass> cincoAQuinze = System.Linq.Enumerable.Range(5, 11).Select(x=> new ContainerClass(x));

            //Act
            List<ContainerClass> resultado = zeroADez.Except(cincoAQuinze, (x, y) => x.Valor == y.Valor).ToList();

            //Assert
            Assert.AreEqual(5, resultado.Count);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(i, resultado[i].Valor);
            }
        }

        [TestMethod]
        public void TestarExceptComHash()
        {
            //Arrange
            IEnumerable<ContainerClass> zeroADez = System.Linq.Enumerable.Range(0, 10).Select(x => new ContainerClass(x));
            IEnumerable<ContainerClass> cincoAQuinze = System.Linq.Enumerable.Range(5, 11).Select(x => new ContainerClass(x));

            //Act
            List<ContainerClass> resultado = zeroADez.Except(cincoAQuinze, (x, y) => x.Valor == y.Valor, x => 10).ToList();

            //Assert
            Assert.AreEqual(5, resultado.Count);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(i, resultado[i].Valor);
            }
        }

        [TestMethod]
        public void TestarUnion()
        {
            //Arrange
            IEnumerable<ContainerClass> zeroADez = System.Linq.Enumerable.Range(0, 10).Select(x => new ContainerClass(x));
            IEnumerable<ContainerClass> cincoAQuinze = System.Linq.Enumerable.Range(5, 11).Select(x => new ContainerClass(x));

            //Act
            List<ContainerClass> resultado = zeroADez.Union(cincoAQuinze, (x, y) => x.Valor == y.Valor).ToList();

            //Assert
            Assert.AreEqual(16, resultado.Count);
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(i, resultado[i].Valor);
            }
        }

        [TestMethod]
        public void TestarUnionComHash()
        {
            //Arrange
            IEnumerable<ContainerClass> zeroADez = System.Linq.Enumerable.Range(0, 10).Select(x => new ContainerClass(x));
            IEnumerable<ContainerClass> cincoAQuinze = System.Linq.Enumerable.Range(5, 11).Select(x => new ContainerClass(x));

            //Act
            List<ContainerClass> resultado = zeroADez.Union(cincoAQuinze, (x, y) => x.Valor == y.Valor, x => 10).ToList();

            //Assert
            Assert.AreEqual(16, resultado.Count);
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(i, resultado[i].Valor);
            }
        }
    }
}
