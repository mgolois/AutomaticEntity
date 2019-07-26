using AutomaticEntity.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomaticEntity.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private DbOperation dbOperation;
        public UnitTest1()
        {
            dbOperation = new DbOperation("Data Source=.;Initial Catalog=School;Integrated Security=True");
        }
        [TestMethod]
        public void TestMethod1()
        {
            var student = dbOperation.GetEntity<Students>(4);
            Assert.IsNotNull(student);
        }
    }
}
