using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using Fujiy.Util.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Fujiy.Util.Tests.Caching
{
    [TestClass]
    public class CacheKeyGeneratorTest
    {
        [TestMethod]
        public void TestarIsValidTypeValidos()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();

            //Act
            Type tipoValidado = typeof(Byte);
            bool retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(SByte);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Int32);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(UInt32);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Int16);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(UInt16);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Int64);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(UInt64);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Single);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Double);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Char);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Boolean);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(String);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Decimal);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(DateTime);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(DateTimeOffset);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Guid);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Enum);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(EnumExemplo);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void TestarIsValidTypeGenericValidos()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();

            //Act
            Type tipoValidado = typeof(Nullable<Byte>);
            bool retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<SByte>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Int32>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<UInt32>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Int16>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<UInt16>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Int64>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<UInt64>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Single>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Double>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Char>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Boolean>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Decimal>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<DateTime>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<DateTimeOffset>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<Guid>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);

            //Act
            tipoValidado = typeof(Nullable<EnumExemplo>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void TestarIsValidTypeInValidos()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();

            //Act
            Type tipoValidado = typeof(object);
            bool retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsFalse(retorno);

            //Act
            tipoValidado = typeof(Type);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsFalse(retorno);

            //Act
            tipoValidado = typeof(Exception);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsFalse(retorno);

            //Act
            tipoValidado = typeof(Dictionary<int, int>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsFalse(retorno);

            //Act
            tipoValidado = typeof(IEnumerable);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsFalse(retorno);

            //Act
            tipoValidado = typeof(List<int>);
            retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void TestarIsValidTypeGenericInvalidos()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();

            //Act
            Type tipoValidado = typeof(Nullable<TipoValor>);
            bool retorno = cacheKeyGenerator.IsValidType(tipoValidado, true);
            //Assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void TestarFormatValueTiposValidos()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();

            //Act
            string retorno = cacheKeyGenerator.FormatValue(Convert.ToByte(1));
            //Assert
            Assert.AreEqual("1", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(Convert.ToSByte(2));
            //Assert
            Assert.AreEqual("2", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(3);
            //Assert
            Assert.AreEqual("3", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(4u);
            //Assert
            Assert.AreEqual("4", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(short.Parse("5"));
            //Assert
            Assert.AreEqual("5", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(ushort.Parse("6"));
            //Assert
            Assert.AreEqual("6", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(7L);
            //Assert
            Assert.AreEqual("7", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(8ul);
            //Assert
            Assert.AreEqual("8", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(9.8888f);
            //Assert
            Assert.AreEqual("9.8888", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(10.88888888d);
            //Assert
            Assert.AreEqual("10.88888888", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue('P');
            //Assert
            Assert.AreEqual("P", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(true);
            //Assert
            Assert.AreEqual("true", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue("StringValor");
            //Assert
            Assert.AreEqual("StringValor", retorno);

            //Act
            string param = null;
            retorno = cacheKeyGenerator.FormatValue(param);
            //Assert
            Assert.AreEqual(null, retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(14.88888888m);
            //Assert
            Assert.AreEqual("14.88888888", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new DateTime(2011, 12, 31, 3, 12, 42, 99));
            //Assert
            Assert.AreEqual("2011-12-31T03:12:42.099", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new DateTimeOffset(2011, 12, 31, 3, 12, 42, 99, new TimeSpan(3, 0, 0)));
            //Assert
            Assert.AreEqual("2011-12-31T03:12:42.099+03:00", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Guid("E7E305F7-B6D9-4551-843E-AA56E6BB87DA"));
            //Assert
            Assert.AreEqual("e7e305f7-b6d9-4551-843e-aa56e6bb87da", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(EnumExemplo.Primeiro);
            //Assert
            Assert.AreEqual("Primeiro", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue((EnumExemplo)999);
            //Assert
            Assert.AreEqual("999", retorno);
        }

        [TestMethod]
        public void TestarFormatValueTiposValidosGeneric()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();

            //Act
            string retorno = cacheKeyGenerator.FormatValue(new Nullable<byte>(Convert.ToByte(1)));
            //Assert
            Assert.AreEqual("1", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<sbyte>(Convert.ToSByte(2)));
            //Assert
            Assert.AreEqual("2", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<int>(3));
            //Assert
            Assert.AreEqual("3", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<uint>(4u));
            //Assert
            Assert.AreEqual("4", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<short>(short.Parse("5")));
            //Assert
            Assert.AreEqual("5", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<ushort>(ushort.Parse("6")));
            //Assert
            Assert.AreEqual("6", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<long>(7L));
            //Assert
            Assert.AreEqual("7", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<ulong>(8ul));
            //Assert
            Assert.AreEqual("8", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<float>(9.8888f));
            //Assert
            Assert.AreEqual("9.8888", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<double>(10.88888888d));
            //Assert
            Assert.AreEqual("10.88888888", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<char>('P'));
            //Assert
            Assert.AreEqual("P", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<bool>(true));
            //Assert
            Assert.AreEqual("true", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<decimal>(14.88888888m));
            //Assert
            Assert.AreEqual("14.88888888", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<DateTime>(new DateTime(2011, 12, 31, 3, 12, 42, 99)));
            //Assert
            Assert.AreEqual("2011-12-31T03:12:42.099", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<DateTimeOffset>(new DateTimeOffset(2011, 12, 31, 3, 12, 42, 99, new TimeSpan(3, 0, 0))));
            //Assert
            Assert.AreEqual("2011-12-31T03:12:42.099+03:00", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<Guid>(new Guid("E7E305F7-B6D9-4551-843E-AA56E6BB87DA")));
            //Assert
            Assert.AreEqual("e7e305f7-b6d9-4551-843e-aa56e6bb87da", retorno);

            //Act
            retorno = cacheKeyGenerator.FormatValue(new Nullable<EnumExemplo>(EnumExemplo.Primeiro));
            //Assert
            Assert.AreEqual("Primeiro", retorno);
        }

        [TestMethod]
        public void TestarFormatValueTipoInvalido()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();

            try
            {
                //Act
                cacheKeyGenerator.FormatValue(new object());
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
        public void TestarValidateArgumentsValidos()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();

            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            Expression<Func<string>> func = () => mock.Object.FakeMethod(10, true, "abc");
            MethodCallExpression metodo = ((MethodCallExpression)func.Body);

            //Act
            cacheKeyGenerator.ValidateArguments(metodo);
        }

        [TestMethod]
        public void TestarValidateArgumentsInvalidos()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();
            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>())).Returns("retorno");

            Expression<Func<string>> func = () => mock.Object.FakeMethodArgumentoInvalido(new object());
            MethodCallExpression metodo = ((MethodCallExpression)func.Body);

            //Act
            try
            {
                cacheKeyGenerator.ValidateArguments(metodo);
                Assert.Fail("Deveria ter disparado Exception");
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is InvalidCacheArgumentException))
                {
                    Assert.Fail("Deveria ter disparado uma InvalidCacheArgumentException");
                }
            }
        }

        [TestMethod]
        public void TestarGenerateKey()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();

            Mock<FakeClass> mock = new Mock<FakeClass>();
            mock.Setup(x => x.FakeMethod(10, true, "string123")).Returns("retorno");
            mock.Setup(x => x.FakeMethod(-50, false, null)).Returns("retorno");

            Expression<Func<string>> func1 = () => mock.Object.FakeMethod(10, true, "string123");
            MethodCallExpression metodo1 = ((MethodCallExpression)func1.Body);

            Expression<Func<string>> func2 = () => mock.Object.FakeMethod(-50, false, null);
            MethodCallExpression metodo2 = ((MethodCallExpression)func2.Body);

            //Act
            string key1 = cacheKeyGenerator.GenerateKey(metodo1);
            string key2 = cacheKeyGenerator.GenerateKey(metodo2);

            //Assert
            Assert.AreEqual("Fujiy.Util.Tests.Caching.CacheKeyGeneratorTest+FakeClass: System.String FakeMethod(Int32, Boolean, System.String). Param Count:3. Params:10,true,string123", key1);
            Assert.AreEqual("Fujiy.Util.Tests.Caching.CacheKeyGeneratorTest+FakeClass: System.String FakeMethod(Int32, Boolean, System.String). Param Count:3. Params:-50,false", key2);
        }

        [TestMethod]
        public void TestarGenerateKeyComClassGeneric()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();

            Mock<FakeClassGeneric<int, string>> mock = new Mock<FakeClassGeneric<int, string>>();
            mock.Setup(x => x.FakeMethod(10, true, "string123")).Returns("retorno");
            mock.Setup(x => x.FakeMethod(-50, false, null)).Returns("retorno");

            Expression<Func<string>> func1 = () => mock.Object.FakeMethod(10, true, "string123");
            MethodCallExpression metodo1 = ((MethodCallExpression)func1.Body);

            //Act
            string key1 = cacheKeyGenerator.GenerateKey(metodo1);

            //Assert
            Assert.AreEqual("Fujiy.Util.Tests.Caching.CacheKeyGeneratorTest+FakeClassGeneric`2[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]: System.String FakeMethod(Int32, Boolean, System.String). Param Count:3. Params:10,true,string123", key1);
        }

        [TestMethod]
        public void TestarGenerateKeyClassEMetodoGeneric()
        {
            //Arrange
            dynamic cacheKeyGenerator = typeof(CacheKeyGenerator).AsDynamicReflection();

            Mock<FakeClassGeneric<int, string>> mock = new Mock<FakeClassGeneric<int, string>>();
            mock.Setup(x => x.FakeMethod(10, true, "string123")).Returns("retorno");
            mock.Setup(x => x.FakeMethod(-50, false, null)).Returns("retorno");

            Expression<Func<byte>> func1 = () => mock.Object.FakeMethod<uint, byte>(10, 50u, "string123");
            MethodCallExpression metodo1 = ((MethodCallExpression)func1.Body);

            //Act
            string key1 = cacheKeyGenerator.GenerateKey(metodo1);

            //Assert
            Assert.AreEqual("Fujiy.Util.Tests.Caching.CacheKeyGeneratorTest+FakeClassGeneric`2[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]: Byte FakeMethod[UInt32,Byte](Int32, UInt32, System.String). Param Count:3. Params:10,50,string123", key1);
        }

        public abstract class FakeClass
        {
            public abstract string FakeMethod(int a, bool b, string c);
            public abstract int FakeMethodValueType(int a, bool b, string c);
            public abstract void FakeInitializer();
            public abstract string FakeMethodArgumentoInvalido(object a);
        }

        public abstract class FakeClassGeneric<T, T2>
        {
            public abstract string FakeMethod(int a, bool b, string c);
            public abstract TR FakeMethod<TP, TR>(T a, TP b, string c);
        }

        public struct TipoValor
        { }

        public enum EnumExemplo
        {
            Primeiro,
            Segundo
        }
    }
}
