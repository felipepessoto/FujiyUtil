using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using Fujiy.Util.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Diagnostics;
using Moq;

namespace Fujiy.Util.Tests.Caching
{
    [TestClass]
    public class CacheHelperTest
    {
        [TestCleanup]
        public void TestCleanup()
        {
            CacheHelper.CacheEnabled = true;
            foreach (DictionaryEntry cache in HttpRuntime.Cache)
            {
                HttpRuntime.Cache.Remove(cache.Key.ToString());
            }
        }

        [TestMethod]
        public void TestarIsValidTypeValidos()
        {
            //Arrange
            Type tipoCacheHelper = typeof (CacheHelper);
            MethodInfo metodoIsValidType = tipoCacheHelper.GetMethod("IsValidType", BindingFlags.NonPublic | BindingFlags.Static);

            //Act
            Type tipoValidado = typeof(Byte);
            bool retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(SByte);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Int32);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(UInt32);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Int16);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(UInt16);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Int64);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(UInt64);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Single);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Double);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Char);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Boolean);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(String);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Decimal);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(DateTime);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(DateTimeOffset);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Guid);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void TestarIsValidTypeGenericValidos()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoIsValidType = tipoCacheHelper.GetMethod("IsValidType", BindingFlags.NonPublic | BindingFlags.Static);

            //Act
            Type tipoValidado = typeof(Nullable<Byte>);
            bool retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<SByte>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Int32>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<UInt32>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Int16>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<UInt16>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Int64>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<UInt64>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Single>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Double>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Char>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Boolean>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Decimal>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<DateTime>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<DateTimeOffset>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Guid>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void TestarIsValidTypeInValidos()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoIsValidType = tipoCacheHelper.GetMethod("IsValidType", BindingFlags.NonPublic | BindingFlags.Static);

            //Act
            Type tipoValidado = typeof(object);
            bool retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsFalse(retorno);

            //Act
            tipoValidado = typeof(Type);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsFalse(retorno);

            //Act
            tipoValidado = typeof(Exception);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsFalse(retorno);

            //Act
            tipoValidado = typeof(Dictionary<int, int>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsFalse(retorno);

            //Act
            tipoValidado = typeof(IEnumerable);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsFalse(retorno);

            //Act
            tipoValidado = typeof(List<int>);
            retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void TestarIsValidTypeGenericInvalidos()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoIsValidType = tipoCacheHelper.GetMethod("IsValidType", BindingFlags.NonPublic | BindingFlags.Static);

            //Act
            Type tipoValidado = typeof(Nullable<TipoValor>);
            bool retorno = (bool)metodoIsValidType.Invoke(null, new[] { tipoValidado });
            //Assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void TestarFormatValueTiposValidos()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoFormatValue = tipoCacheHelper.GetMethod("FormatValue", BindingFlags.NonPublic | BindingFlags.Static);

            //Act
            string retorno = (string)metodoFormatValue.Invoke(null, new object[] { Convert.ToByte(1) });
            //Assert
            Assert.AreEqual("1", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { Convert.ToSByte(2) });
            //Assert
            Assert.AreEqual("2", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { 3 });
            //Assert
            Assert.AreEqual("3", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { 4u });
            //Assert
            Assert.AreEqual("4", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { short.Parse("5") });
            //Assert
            Assert.AreEqual("5", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { ushort.Parse("6") });
            //Assert
            Assert.AreEqual("6", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { 7L });
            //Assert
            Assert.AreEqual("7", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { 8ul });
            //Assert
            Assert.AreEqual("8", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { 9.8888f });
            //Assert
            Assert.AreEqual("9.8888", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { 10.88888888d });
            //Assert
            Assert.AreEqual("10.88888888", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { 'P' });
            //Assert
            Assert.AreEqual("P", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { true });
            //Assert
            Assert.AreEqual("true", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { "StringValor" });
            //Assert
            Assert.AreEqual("StringValor", retorno);

            //Act
            string param = null;
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { param });
            //Assert
            Assert.AreEqual(null, retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { 14.88888888m });
            //Assert
            Assert.AreEqual("14.88888888", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new DateTime(2011, 12, 31, 3, 12, 42, 99) });
            //Assert
            Assert.AreEqual("2011-12-31T03:12:42.099", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new DateTimeOffset(2011, 12, 31, 3, 12, 42, 99, new TimeSpan(3, 0, 0)) });
            //Assert
            Assert.AreEqual("2011-12-31T03:12:42.099+03:00", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Guid("E7E305F7-B6D9-4551-843E-AA56E6BB87DA") });
            //Assert
            Assert.AreEqual("e7e305f7-b6d9-4551-843e-aa56e6bb87da", retorno);
        }

        [TestMethod]
        public void TestarFormatValueTiposValidosGeneric()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoFormatValue = tipoCacheHelper.GetMethod("FormatValue", BindingFlags.NonPublic | BindingFlags.Static);

            //Act
            string retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<byte>(Convert.ToByte(1)) });
            //Assert
            Assert.AreEqual("1", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<sbyte>(Convert.ToSByte(2)) });
            //Assert
            Assert.AreEqual("2", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<int>(3) });
            //Assert
            Assert.AreEqual("3", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<uint>(4u) });
            //Assert
            Assert.AreEqual("4", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<short>(short.Parse("5")) });
            //Assert
            Assert.AreEqual("5", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<ushort>(ushort.Parse("6")) });
            //Assert
            Assert.AreEqual("6", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<long>(7L) });
            //Assert
            Assert.AreEqual("7", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<ulong>(8ul) });
            //Assert
            Assert.AreEqual("8", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<float>(9.8888f) });
            //Assert
            Assert.AreEqual("9.8888", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<double>(10.88888888d) });
            //Assert
            Assert.AreEqual("10.88888888", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<char>('P') });
            //Assert
            Assert.AreEqual("P", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<bool>(true) });
            //Assert
            Assert.AreEqual("true", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<decimal>(14.88888888m) });
            //Assert
            Assert.AreEqual("14.88888888", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] {new Nullable<DateTime>(new DateTime(2011, 12, 31, 3, 12, 42, 99)) });
            //Assert
            Assert.AreEqual("2011-12-31T03:12:42.099", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<DateTimeOffset>(new DateTimeOffset(2011, 12, 31, 3, 12, 42, 99, new TimeSpan(3, 0, 0))) });
            //Assert
            Assert.AreEqual("2011-12-31T03:12:42.099+03:00", retorno);

            //Act
            retorno = (string)metodoFormatValue.Invoke(null, new object[] { new Nullable<Guid>(new Guid("E7E305F7-B6D9-4551-843E-AA56E6BB87DA")) });
            //Assert
            Assert.AreEqual("e7e305f7-b6d9-4551-843e-aa56e6bb87da", retorno);
        }

        [TestMethod]
        public void TestarFormatValueTipoInvalido()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoFormatValue = tipoCacheHelper.GetMethod("FormatValue", BindingFlags.NonPublic | BindingFlags.Static);

            try
            {
                //Act
                metodoFormatValue.Invoke(null, new[] { new object() });
                //Assert
                Assert.Fail("Deveria ter disparado Exception");
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is InvalidCacheArgumentException))
                Assert.Fail("Deveria ter disparado uma InvalidCacheArgumentException");
            }
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteComKey()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");

            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

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
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"));

            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"));
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), new CacheOptions());
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"));
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"));
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"));

            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"));

            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethodValueType(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethodValueType(1, false, "arg"));
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethodValueType(1, false, "arg"));

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");
            mock.Verify(x => x.FakeMethod(2, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");
            mock.Verify(x => x.FakeMethod(3, false, "arg"), Times.Never(), "Nunca deve ser chamado");
            mock.Verify(x => x.FakeMethodValueType(1, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteRetornoNull()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns((string)null);

            //Act
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Exactly(5), "Deve chamar 5 vezes. Null não é cacheado");
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteDesativado()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.CacheEnabled = false;
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            CacheHelper.CacheEnabled = true;
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.CacheEnabled = false;
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");

            

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Exactly(3), "Deve chamar 3 vezes. Na primeira e depois que desativa o cache");
            mock.Verify(x => x.FakeMethod(2, false, "arg"), Times.Exactly(2), "Deve chamar 2 vezes. Na primeira e depois que desativa o cache");
        }

        [TestMethod]
        public void TestarFromCacheOrExecuteComFuncExpressionInvalido()
        {
            try
            {
                //Act
                CacheHelper.FromCacheOrExecute<int>(HttpRuntime.Cache, null, "cacheKey");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                //Assert
                Assert.AreEqual("func", ex.ParamName);
            }

            //Act
            try
            {
                CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => "");
                Assert.Fail();
            }
            catch(InvalidCachedFuncException)
            {
                //Sucesso
            }
        }

        [TestMethod]
        public void TestarInitializer()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { ExecutionInitializer = mock.Object.FakeInitializer });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { ExecutionInitializer = mock.Object.FakeInitializer });

            CacheHelper.ClearCache();
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { ExecutionInitializer = mock.Object.FakeInitializer });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { ExecutionInitializer = mock.Object.FakeInitializer });

            CacheHelper.ClearCache();
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { ExecutionInitializer = mock.Object.FakeInitializer });

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
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { AbsoluteExpiration = dataExpiracao });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");

            //Act
            Thread.Sleep(3000);
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

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
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { SlidingExpiration = tempoExpiracao });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            //Assert
            mock.Verify(x => x.FakeMethod(1, false, "arg"), Times.Once(), "Deve chamar uma e somente uma vez. Depois somente usa o cache");

            //Act
            Thread.Sleep(3000);
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

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
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4");

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
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4");

            //Assert
            ILookup<string, string> keys = CacheHelper.GetAllKeys();
            Assert.AreEqual(1, keys.Count);
            Assert.AreEqual(4, keys[CacheHelper.AnonymousGroup].Count());
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey2"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey3"));
            Assert.IsTrue(keys[CacheHelper.AnonymousGroup].Contains("cacheKey4"));

            const string novoGrupo = "NovoGrupo";
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { GroupName = novoGrupo });

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
        public void TestarMetodoRetornaNullComoResultadoNaoDeveIrProKeysGroups()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns<string>(null);

            //Act
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");

            //Assert
            ILookup<string, string> keys = CacheHelper.GetAllKeys();
            Assert.AreEqual(0, keys.Count);
        }

        [TestMethod]
        public void TestarGetKeysByGroup()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            //Act
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3");
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4");

            //Assert
            IEnumerable<string> keys = CacheHelper.GetKeysByGroup(CacheHelper.AnonymousGroup);
            Assert.AreEqual(4, keys.Count());
            Assert.IsTrue(keys.Contains("cacheKey"));
            Assert.IsTrue(keys.Contains("cacheKey2"));
            Assert.IsTrue(keys.Contains("cacheKey3"));
            Assert.IsTrue(keys.Contains("cacheKey4"));

            const string novoGrupo = "NovoGrupo";
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { GroupName = novoGrupo });

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
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2", new CacheOptions { GroupName = "GrupoB" });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3", new CacheOptions { GroupName = "GrupoC" });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4", new CacheOptions { GroupName = "GrupoD" });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4", new CacheOptions { GroupName = "GrupoB" });

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
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2", new CacheOptions { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3", new CacheOptions { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4", new CacheOptions { GroupName = "GrupoD" });

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
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey", new CacheOptions { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(2, false, "arg"), "cacheKey2", new CacheOptions { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey3", new CacheOptions { GroupName = "GrupoA" });
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey4", new CacheOptions { GroupName = "GrupoD" });

            //Assert
            ILookup<string, string> groupedKeys = CacheHelper.GetAllKeys();
            Assert.AreEqual(2, groupedKeys.Count);
            CacheHelper.ClearCache();
            groupedKeys = CacheHelper.GetAllKeys();
            Assert.AreEqual(0, groupedKeys.Count);
        }

        [TestMethod]
        public void TestarValidateArgumentsValidos()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoValidateArguments = tipoCacheHelper.GetMethod("ValidateArguments", BindingFlags.NonPublic | BindingFlags.Static);
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            Expression<Func<string>> func = () => mock.Object.FakeMethod(10, true, "abc");
            MethodCallExpression metodo = ((MethodCallExpression)func.Body);

            //Act
            metodoValidateArguments.Invoke(null, new[] { metodo });
        }

        [TestMethod]
        public void TestarValidateArgumentsInvalidos()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoValidateArguments = tipoCacheHelper.GetMethod("ValidateArguments", BindingFlags.NonPublic | BindingFlags.Static);
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            Expression<Func<string>> func = () => mock.Object.FakeMethodArgumentoInvalido(new object());
            MethodCallExpression metodo = ((MethodCallExpression)func.Body);

            //Act
            try
            {
                metodoValidateArguments.Invoke(null, new[] {metodo});
                Assert.Fail("Deveria ter disparado Exception");
            }
            catch(Exception ex)
            {
                if(!(ex.InnerException is InvalidCacheArgumentException))
                {
                    Assert.Fail("Deveria ter disparado uma InvalidCacheArgumentException");
                }
            }
        }

        [TestMethod]
        public void TestarGenerateKey()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoGenerateKey = tipoCacheHelper.GetMethod("GenerateKey", BindingFlags.NonPublic | BindingFlags.Static);
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(10, true, "string123")).Returns("retorno");
            mock.Setup(x => x.FakeMethod(-50, false, null)).Returns("retorno");

            Expression<Func<string>> func1 = () => mock.Object.FakeMethod(10, true, "string123");
            MethodCallExpression metodo1 = ((MethodCallExpression)func1.Body);

            Expression<Func<string>> func2 = () => mock.Object.FakeMethod(-50, false, null);
            MethodCallExpression metodo2 = ((MethodCallExpression)func2.Body);

            //Act
            string key1 = (string)metodoGenerateKey.Invoke(null, new[] { metodo1 });
            string key2 = (string)metodoGenerateKey.Invoke(null, new[] { metodo2 });

            //Assert
            Assert.AreEqual("Fujiy.Util.Tests.Caching.CacheHelperTest+FakeClass: System.String FakeMethod(Int32, Boolean, System.String). Param Count:3. Params:10,true,string123", key1);
            Assert.AreEqual("Fujiy.Util.Tests.Caching.CacheHelperTest+FakeClass: System.String FakeMethod(Int32, Boolean, System.String). Param Count:3. Params:-50,false", key2);
        }

        [TestMethod]
        public void TestarGenerateKeyComClassGeneric()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoGenerateKey = tipoCacheHelper.GetMethod("GenerateKey", BindingFlags.NonPublic | BindingFlags.Static);
            Mock<FakeClassGeneric<int, string>> mock = new Mock<FakeClassGeneric<int, string>>();
            mock.Setup(x => x.FakeMethod(10, true, "string123")).Returns("retorno");
            mock.Setup(x => x.FakeMethod(-50, false, null)).Returns("retorno");

            Expression<Func<string>> func1 = () => mock.Object.FakeMethod(10, true, "string123");
            MethodCallExpression metodo1 = ((MethodCallExpression)func1.Body);

            //Act
            string key1 = (string)metodoGenerateKey.Invoke(null, new[] { metodo1 });

            //Assert
            Assert.AreEqual("Fujiy.Util.Tests.Caching.CacheHelperTest+FakeClassGeneric`2[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]: System.String FakeMethod(Int32, Boolean, System.String). Param Count:3. Params:10,true,string123", key1);
        }

        [TestMethod]
        public void TestarGenerateKeyClassEMetodoGeneric()
        {
            //Arrange
            Type tipoCacheHelper = typeof(CacheHelper);
            MethodInfo metodoGenerateKey = tipoCacheHelper.GetMethod("GenerateKey", BindingFlags.NonPublic | BindingFlags.Static);
            Mock<FakeClassGeneric<int, string>> mock = new Mock<FakeClassGeneric<int, string>>();
            mock.Setup(x => x.FakeMethod(10, true, "string123")).Returns("retorno");
            mock.Setup(x => x.FakeMethod(-50, false, null)).Returns("retorno");

            Expression<Func<byte>> func1 = () => mock.Object.FakeMethod<uint, byte>(10, 50u, "string123");
            MethodCallExpression metodo1 = ((MethodCallExpression)func1.Body);

            //Act
            string key1 = (string)metodoGenerateKey.Invoke(null, new[] { metodo1 });

            //Assert
            Assert.AreEqual("Fujiy.Util.Tests.Caching.CacheHelperTest+FakeClassGeneric`2[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]: Byte FakeMethod[UInt32,Byte](Int32, UInt32, System.String). Param Count:3. Params:10,50,string123", key1);
        }

        [TestMethod]
        public void TestarFromCacheNullCacheParameters()
        {
            //Arrange
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            try
            {
                //Act
                CacheHelper.FromCacheOrExecute(null, () => mock.Object.FakeMethod(1, false, "arg"), "cacheKey");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                //Assert
                Assert.AreEqual("cache", ex.ParamName);
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
            CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => concreteFakeClass.FakeMethod(1, true, ""));
            long msInicial = stopwatch.ElapsedMilliseconds;
            
            stopwatch.Restart();
            for (int i = 0; i < loopCount; i++)
            {
                CacheHelper.FromCacheOrExecute(HttpRuntime.Cache, () => concreteFakeClass.FakeMethodLong(1, true, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""));
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
        }

        public abstract class FakeClassGeneric<T, T2>
        {
            public abstract string FakeMethod(int a, bool b, string c);
            public abstract TR FakeMethod<TP, TR>(T a, TP b, string c);
        }

        public struct TipoValor
        {}
    }
}
