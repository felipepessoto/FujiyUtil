using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fujiy.Util.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fujiy.Util.Tests.Collections.Generic
{
    [TestClass]
    public class PagedCollectionTest
    {
        [TestMethod]
        public void TestarCount()
        {
            //Arrange
            const int totalItens = 200;
            IEnumerable<int> paginaComDez = Enumerable.Range(1, 10);
            PagedCollection<int> target = new PagedCollection<int>(totalItens, 0, paginaComDez);

            //Act
            int count = target.Count;

            //Assert
            Assert.AreEqual(totalItens, count);
        }

        [TestMethod]
        public void TestarGetEnumeratorChamaGetEnumeratorGeneric()
        {
            //Arrange
            const int totalItens = 200;
            IEnumerable<int> paginaComDez = Enumerable.Range(1, 10);
            PagedCollection<int> target = new PagedCollection<int>(totalItens, 0, paginaComDez);

            //Assert
            Assert.IsInstanceOfType(((IEnumerable)target).GetEnumerator(), typeof(IEnumerator<int>));
        }

        [TestMethod]
        public void TestarGetEnumeratorGenericPrimeiraPagina()
        {
            //Arrange
            const int totalItens = 200;
            const int startIndex = 0;
            List<int> paginaComDez = Enumerable.Range(1, 10).ToList();
            PagedCollection<int> target = new PagedCollection<int>(totalItens, startIndex, paginaComDez);

            //Act
            List<int> resultado = target.ToList();

            //Assert
            for (int i = 0; i < resultado.Count; i++)
            {
                if (i < paginaComDez.Count)
                {
                    Assert.AreEqual(paginaComDez[i], resultado[i]);
                }
                else
                {
                    Assert.AreEqual(default(int), resultado[i]);
                }
            }
        }

        [TestMethod]
        public void TestarGetEnumeratorGenericUltimaPagina()
        {
            //Arrange
            const int totalItens = 200;
            const int startIndex = 191;
            List<int> paginaComDez = Enumerable.Range(1, 10).ToList();
            PagedCollection<int> target = new PagedCollection<int>(totalItens, startIndex, paginaComDez);

            //Act
            List<int> resultado = target.ToList();

            //Assert
            int indicePagina = 0;
            for (int i = 0; i < resultado.Count; i++)
            {
                if (i >= startIndex && i < startIndex + paginaComDez.Count)
                {
                    Assert.AreEqual(paginaComDez[indicePagina++], resultado[i]);
                }
                else
                {
                    Assert.AreEqual(default(int), resultado[i]);
                }
            }
        }

        [TestMethod]
        public void TestarGetEnumeratorGenericPaginaMeio()
        {
            //Arrange
            const int totalItens = 200;
            const int startIndex = 101;
            List<int> paginaComDez = Enumerable.Range(1, 10).ToList();
            PagedCollection<int> target = new PagedCollection<int>(totalItens, startIndex, paginaComDez);

            //Act
            List<int> resultado = target.ToList();

            //Assert
            int indicePagina = 0;
            for (int i = 0; i < resultado.Count; i++)
            {
                if (i >= startIndex && i < startIndex + paginaComDez.Count)
                {
                    Assert.AreEqual(paginaComDez[indicePagina++], resultado[i]);
                }
                else
                {
                    Assert.AreEqual(default(int), resultado[i]);
                }
            }
        }

        [TestMethod]
        public void TestarGetEnumeratorGenericPaginaTamanhoTotal()
        {
            //Arrange
            const int totalItens = 200;
            const int startIndex = 0;
            List<int> paginaComDez = Enumerable.Range(1, 200).ToList();
            PagedCollection<int> target = new PagedCollection<int>(totalItens, startIndex, paginaComDez);

            //Act
            List<int> resultado = target.ToList();

            //Assert
            int indicePagina = 0;
            for (int i = 0; i < resultado.Count; i++)
            {
                if (i >= startIndex && i < startIndex + paginaComDez.Count)
                {
                    Assert.AreEqual(paginaComDez[indicePagina++], resultado[i]);
                }
                else
                {
                    Assert.AreEqual(default(int), resultado[i]);
                }
            }
        }

        [TestMethod]
        public void TestarNaoImplementados()
        {
            //Arrange
            const int totalItens = 200;
            const int startIndex = 0;
            List<int> paginaComDez = Enumerable.Range(1, 200).ToList();
            PagedCollection<int> target = new PagedCollection<int>(totalItens, startIndex, paginaComDez);

            //Act
            try
            {
                ((ICollection) target).CopyTo(null, 0);
                Assert.Fail();
            }
            catch
            {
            }
            try
            {
                var aux = ((ICollection) target).SyncRoot;
                Assert.Fail();
            }
            catch
            {
            }
            try
            {
                var aux = ((ICollection) target).IsSynchronized;
                Assert.Fail();
            }
            catch
            {
            }
        }
    }
}
