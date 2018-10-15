using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //настройка
            //вызов
            Tests.Program program = new Tests.Program();
            string w = "1";

            string result = program.Testtt(w);

            //результат
            Assert.AreEqual(w,result);
            
        }
    }
}
