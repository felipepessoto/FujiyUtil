using Fujiy.Util.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Fujiy.Util.Tests.Caching
{
    [TestClass]
    public class CacheHelperTest
    {
        [TestCleanup]
        public void TestCleanup()
        {
            CacheHelper.CacheEnabled = true;
            CacheHelper.ClearCache();
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteComKey()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");

            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");
            mock.Verify(x => x.FakeMethod(2, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");
            mock.Verify(x => x.FakeMethod(3, false, "arg"), Times.Never(), "Nunca deve ser chamado");
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteSemKey()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");
            mock.Setup(x => x.FakeMethodValueType(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns(5);

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"));

            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"));
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"));
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"));
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"));
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"));

            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"));

            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethodValueType(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethodValueType(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethodValueType(1, false, "arg"));

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");
            mock.Verify(x => x.FakeMethod(2, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");
            mock.Verify(x => x.FakeMethod(3, false, "arg"), Times.Never(), "Nunca deve ser chamado");
            mock.Verify(x => x.FakeMethodValueType(1, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteRetornoNullDeveCachear()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns((string)null);

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Exactly(1), "Deve chamar 1 vez. Null é cacheado");
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteDesativado()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.CacheEnabled = false;
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            CacheHelper.CacheEnabled = true;
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.CacheEnabled = false;
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");

            

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Exactly(3), "Deve chamar 3 vezes. Na primeira e depois que desativa o cache");
            mock.Verify(x => x.FakeMethod(2, false, "arg"), Times.Exactly(2), "Deve chamar 2 vezes. Na primeira e depois que desativa o cache");
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteComFuncExpressionQueNaoEhMethodESemCacheKey()
        {
            //Act
            try
            {
                CacheHelper.FromCacheOrExecute(() => "");
                Assert.Fail();
            }
            catch(InvalidCachedFuncException)
            {
                //Sucesso
            }
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteComFuncExpressionQueNaoEhMethodEComCacheKey()
        {
            //Act
            CacheHelper.FromCacheOrExecute(() => "Conteudo", "ChaveDoCacheQueNaoEhMethodExpression");
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteComFuncExpressionQueEhPropertyEComCacheKey()
        {
            //Act
            CacheHelper.FromCacheOrExecute(() => ConcreteFakeClass.FakePropriedade, "ChaveDoCacheQueNaoEhMethodExpression");
        }

        [TestMethod]
        public void TestarInitializer()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { ExecutionInitializer = mock.Object.FakeInitializer });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { ExecutionInitializer = mock.Object.FakeInitializer });

            CacheHelper.ClearCache();
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { ExecutionInitializer = mock.Object.FakeInitializer });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { ExecutionInitializer = mock.Object.FakeInitializer });

            CacheHelper.ClearCache();
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { ExecutionInitializer = mock.Object.FakeInitializer });

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Exactly(3), "Deve chamar 3 vezes. Na primeira, e sempre depois que limpa o cache");
            mock.Verify(x => x.FakeInitializer(), Times.Exactly(3), "Deve chamar o FakeInitializer sempre antes de chamar o método FakeMethod");
        }

        [TestMethod]
        public void TestarExpiracaoDoCachePorData()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");
            DateTime dataExpiracao = DateTime.Now.AddSeconds(2);

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { AbsoluteExpiration = dataExpiracao });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");

            //Act
            Thread.Sleep(3000);
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Exactly(2), "Deve chamar 2 vezes. Na primeira, e sempre depois que expira o cache");
        }

        [TestMethod]
        public void TestarExpiracaoDoCachePorTempoSemUso()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");
            TimeSpan tempoExpiracao = new TimeSpan(0, 0, 0, 2);

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { SlidingExpiration = tempoExpiracao });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");

            //Act
            Thread.Sleep(3000);
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Exactly(2), "Deve chamar 2 vezes. Na primeira, e sempre depois que expira o cache");
        }

        //[TestMethod] Este método corrompe o estado interno da classe, influenciando nos outros métodos
        public void TestarCriacaoDeGruposDeCaches()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoAddKeyOnGroup = tipoCacheHelper.GetMethod("AddKeyOnGroup", BindingFlags.NonPublic | BindingFlags.Static);

            //Act
            string nomeGrupo = "grupo1";
            string chave = "chaveA";
            metodoAddKeyOnGroup.Invoke(null, new[] { nomeGrupo, chave });

            string chave2 = "chaveB";
            metodoAddKeyOnGroup.Invoke(null, new[] { nomeGrupo, chave2 });
            metodoAddKeyOnGroup.Invoke(null, new[] { nomeGrupo, chave2 });
            metodoAddKeyOnGroup.Invoke(null, new[] { nomeGrupo, chave2 });

            string nomeGrupo2 = "grupo2";
            string chave3 = "chaveC";
            metodoAddKeyOnGroup.Invoke(null, new[] { nomeGrupo2, chave3 });

            //Assert
            Assert.AreEqual(2, CacheHelper.Groups.Count());
            Assert.IsTrue(CacheHelper.Groups.Contains("grupo1"));
            Assert.IsTrue(CacheHelper.Groups.Contains("grupo2"));
        }

        [TestMethod]
        public void TestarGetAllKeys()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4");

            //Assert
            ILookup<string, string> keys = CacheHelper.GetAllKeys();
            
            Assert.AreEqual(1, keys.Count);
            Assert.AreEqual(4, keys[CacheHelper.AnonymousGroup].Count());
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey2"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey3"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey4"));
        }

        [TestMethod]
        public void TestarGetAllKeysDepoisDeAlterarGrupoDaChave()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4");

            //Assert
            ILookup<string, string> keys = CacheHelper.GetAllKeys();
            Assert.AreEqual(1, keys.Count);
            Assert.AreEqual(4, keys[CacheHelper.AnonymousGroup].Count());
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey2"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey3"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey4"));

            const string novoGrupo = "NovoGrupo";
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { GroupName = novoGrupo });

            keys = CacheHelper.GetAllKeys();
            Assert.AreEqual(2, keys.Count);
            Assert.AreEqual(3, keys[CacheHelper.AnonymousGroup].Count());
            Assert.AreEqual(1, keys[novoGrupo].Count());
            Assert.IsTrue(keys[novoGrupo].Contains("cacheKey"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey2"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey3"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey4"));
        }

        [TestMethod]
        public void TestarMetodoRetornaNullComoResultadoDeveIrProKeysGroups()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns<string>(null);

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            //Assert
            ILookup<string, string> keys = CacheHelper.GetAllKeys();
            Assert.AreEqual(1, keys.Count);
        }

        [TestMethod]
        public void TestarGetKeysByGroup()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3");
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4");

            //Assert
            IEnumerable<string> keys = CacheHelper.GetKeysByGroup(CacheHelper.AnonymousGroup);
            Assert.AreEqual(4, keys.Count());
            Assert.IsTrue(keys.Contains("cacheKey"));
            Assert.IsTrue(keys.Contains("cacheKey2"));
            Assert.IsTrue(keys.Contains("cacheKey3"));
            Assert.IsTrue(keys.Contains("cacheKey4"));

            const string novoGrupo = "NovoGrupo";
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { GroupName = novoGrupo });

            //Act
            keys = CacheHelper.GetKeysByGroup(CacheHelper.AnonymousGroup);
            //Assert
            Assert.AreEqual(3, keys.Count());
            Assert.IsTrue(keys.Contains("cacheKey2"));
            Assert.IsTrue(keys.Contains("cacheKey3"));
            Assert.IsTrue(keys.Contains("cacheKey4"));

            //Act
            keys = CacheHelper.GetKeysByGroup(novoGrupo);
            //Assert
            Assert.AreEqual(1, keys.Count());
            Assert.IsTrue(keys.Contains("cacheKey"));
        }

        [TestMethod]
        public void TestarGroups()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2", new ExtendedCacheItemPolicy { GroupName = "GrupoB" });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3", new ExtendedCacheItemPolicy { GroupName = "GrupoC" });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4", new ExtendedCacheItemPolicy { GroupName = "GrupoD" });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4", new ExtendedCacheItemPolicy { GroupName = "GrupoB" });

            //Assert
            IEnumerable<string> keys = CacheHelper.Groups;
            Assert.AreEqual(3, keys.Count());
            Assert.IsTrue(keys.Contains("GrupoA"));
            Assert.IsTrue(keys.Contains("GrupoB"));
            Assert.IsTrue(keys.Contains("GrupoC"));
        }

        [TestMethod]
        public void TestarRemoveCacheByGroup()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2", new ExtendedCacheItemPolicy { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3", new ExtendedCacheItemPolicy { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4", new ExtendedCacheItemPolicy { GroupName = "GrupoD" });

            //Assert
            ILookup<string, string> groupedKeys = CacheHelper.GetAllKeys();
            Assert.AreEqual(2, groupedKeys.Count);
            Assert.AreEqual(3, groupedKeys["GrupoA"].Count());
            Assert.IsTrue(groupedKeys["GrupoA"].Contains("cacheKey"));
            Assert.IsTrue(groupedKeys["GrupoA"].Contains("cacheKey2"));
            Assert.IsTrue(groupedKeys["GrupoA"].Contains("cacheKey3"));
            Assert.AreEqual(1, groupedKeys["GrupoD"].Count());
            Assert.IsTrue(groupedKeys["GrupoD"].Contains("cacheKey4"));

            CacheHelper.RemoveCacheByGroup("GrupoA");
            groupedKeys = CacheHelper.GetAllKeys();

            Assert.AreEqual(1, groupedKeys.Count);
            Assert.IsFalse(groupedKeys.Contains("GrupoA"));
            Assert.IsTrue(groupedKeys.Contains("GrupoD"));
        }

        [TestMethod]
        public void TestarClearCache()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new ExtendedCacheItemPolicy { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2", new ExtendedCacheItemPolicy { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3", new ExtendedCacheItemPolicy { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4", new ExtendedCacheItemPolicy { GroupName = "GrupoD" });

            //Assert
            ILookup<string, string> groupedKeys = CacheHelper.GetAllKeys();
            Assert.AreEqual(2, groupedKeys.Count);
            CacheHelper.ClearCache();
            groupedKeys = CacheHelper.GetAllKeys();
            Assert.AreEqual(0, groupedKeys.Count);
        }

        [TestMethod]
        public void TestarRemoveCache()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(() => mock.Object.FakeMethod(2, false, "arg"));

            //Assert
            ILookup<string, string> groupedKeys = CacheHelper.GetAllKeys();
            Assert.AreEqual(2, groupedKeys.Sum(x => x.Count()));

            CacheHelper.RemoveCache(() => mock.Object.FakeMethod(1, false, "arg"));
            CacheHelper.RemoveCache(() => mock.Object.FakeMethod(2, false, "arg"));

            groupedKeys = CacheHelper.GetAllKeys();
            Assert.AreEqual(0, groupedKeys.Sum(x => x.Count()));
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteComParametroFuncNull()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            try
            {
                //Act
                CacheHelper.FromCacheOrExecute<object>(null, "cacheKey");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                //Assert
                Assert.AreEqual("func", ex.ParamName);
            }
        }

        [TestMethod]
        public void TestarPerformanceFromCacheOrExecute()
        {
            //Arrange
            ConcreteFakeClass concreteFakeClass = new ConcreteFakeClass();
            const int loopCount = 100;

            //Act
            Stopwatch stopwatch = Stopwatch.StartNew();
            CacheHelper.FromCacheOrExecute(() => concreteFakeClass.FakeMethod(1, true, ""));
            long msInicial = stopwatch.ElapsedMilliseconds;
            
            stopwatch.Restart();
            for (int i = 0; i < loopCount; i++)
            {
                CacheHelper.FromCacheOrExecute(() => concreteFakeClass.FakeMethodLong(1, true, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""));
            }
            long ms = stopwatch.ElapsedMilliseconds / loopCount;

            //Assert
            Assert.IsTrue(msInicial < 500);
            Assert.IsTrue(ms < 10);
        }

        public abstract class FakeClass
        {
            public abstract string FakeMethod(int a, bool b, string c);
            public abstract int FakeMethodValueType(int a, bool b, string c);
            public abstract void FakeInitializer();
            public abstract string FakeMethodArgumentoInvalido(object a);
        }

        public class ConcreteFakeClass
        {
            public static int chamadas;
            public int FakeMethodOut(int a, out bool b, out string c)
            {
                chamadas++;
                b = true;
                c = "123";
                return 3;
            }

            public int FakeMethod(int a, bool b, string c)
            {
                return 0;
            }

            public int FakeMethodLong(int a, bool b, string c, string c2, string c3, string c4, string c5, string c6, string c7, string c8, string c9, string c10, string c11, string c12, string c13, string c14, string c15, string c16)
            {
                return 0;
            }

            public static int FakePropriedade { get { return 1; } }
        }
    }
}
