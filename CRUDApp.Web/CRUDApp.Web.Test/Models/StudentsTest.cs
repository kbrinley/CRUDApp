using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using CRUDApp.Web.Models;

namespace CRUDApp.Web.Test.Models
{
    [TestFixture]
    public class StudentsTest
    {
        StudentsModel sm = new StudentsModel();
        MockDatabase mdb = new MockDatabase();

        [SetUp]
        public void Setup()
        {
            sm = new StudentsModel(mdb);
        }

        [Test]
        public void Verify_New_Student_ID_is_Negative_One()
        {
            Assert.AreEqual(-1, sm.ID);
        }

        [Test]
        public void Verify_Get_All_Records_Returns_5_Records()
        {
            var result = StudentsModel.GetRecords(mdb);
            Assert.AreEqual(5, result.Count());
        }

        [Test]
        public void Verify_Get_Record_With_Valid_ID_Returns_With_Correct_ID()
        {
            var result = StudentsModel.GetRecord(1, mdb);
            Assert.AreEqual(1, result.ID);
        }

        [Test]
        public void Verify_Get_Record_With_Invalid_ID_Returns_NULL()
        {
            var result = StudentsModel.GetRecord(100, mdb);
            Assert.IsNull(result);
        }
    }
}
