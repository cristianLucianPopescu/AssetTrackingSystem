
using System;
using System.Collections.Generic;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackMe;
using static TrackMe.DatabaseAccess;
using Moq;

namespace UnitTestDatabase
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //Arrange
            record newrecord = new record("samsung", "laptop", "one of the best laptops", "2021", "samsung", "38478952", "11:3R:76:E5:77:12", "192.11.2.1", "room454", "11/11/2021", "life warranty", "n/a");
            List<record> r = new List<record>();

            //Act
            r.Add(newrecord);

            //Assert
            Assert.IsNotNull(r);
            
        }

        //public void TestMethod2()
        //{
        //    Mock<DatabaseAccess> check = new Mock<DatabaseAccess>();
        //    check.Setup(x => x.DatabaseAccess.InitializeDatabase1()).Returns(true);

        //    DatabaseAccess obje = new DatabaseAccess();
        //    Assert.AreEqual(obje.Equals(check.Object), true);
        //}

        //[ExpectedException(typeof(NotFoundException))]
        //public void DeleteRecord()
        //{

        //    using (TransactionScope scope = new TransactionScope())
        //    {
        //        DatabaseAccess record = new DatabaseAccess();
        //        record.DeleteData1("hp");



        //        record deletedRecord1 = record.GetData1();
        //    }
        //}
    }
}
