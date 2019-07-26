using AutomaticEntity.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomaticEntity.Tests
{
    [TestClass]
    public class DbOperationTest
    {
        private DbOperation dbOperation;
        public DbOperationTest()
        {
            //TODO Add support for in memory DB
            dbOperation = new DbOperation("Data Source=.;Initial Catalog=School;Integrated Security=True");
        }
        [TestMethod]
        public void CanGetEntity()
        {
            var student = dbOperation.GetEntity<Students>(4);
            Assert.IsNotNull(student);
        }
    }
}
