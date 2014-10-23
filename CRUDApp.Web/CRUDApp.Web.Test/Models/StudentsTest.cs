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

        [SetUp]
        public void Setup()
        {
            sm = new StudentsModel();
        }

        [Test]
        public void Verify_New_Student_ID_is_Negative_One()
        {
            Assert.AreEqual(-1, sm.ID);
        }
    }
}
