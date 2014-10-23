using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using CRUDApp.Model;

namespace CRUDApp.Model.Test
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

        [Test]
        public void Verify_If_FirstName_Missing_Student_is_Invalid()
        {
            sm.LastName = "Doe";
            sm.AddressState = "Fantasy Island";

            var context = new ValidationContext(sm, serviceProvider: null, items: null);
            ICollection<ValidationResult> results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sm, context, results);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, results.Count);
            var result = results.First();
            Assert.AreEqual("The FirstName field is required.", result.ErrorMessage);
        }

        [Test]
        public void Verify_If_LastName_Missing_Student_is_Invalid()
        {
            sm.FirstName = "John";
            sm.AddressState = "Fantasy Island";

            var context = new ValidationContext(sm, serviceProvider: null, items: null);
            ICollection<ValidationResult> results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sm, context, results);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, results.Count);
            var result = results.First();
            Assert.AreEqual("The LastName field is required.", result.ErrorMessage);
        }

        [Test]
        public void Verify_If_City_Missing_Student_is_Invalid()
        {
            sm.FirstName = "John";
            sm.LastName = "Doe";

            var context = new ValidationContext(sm, serviceProvider: null, items: null);
            ICollection<ValidationResult> results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sm, context, results);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, results.Count);
            var result = results.First();
            Assert.AreEqual("The AddressState field is required.", result.ErrorMessage);
        }

        [Test]
        public void Verify_If_Required_Fields_Entered_Student_is_Valid()
        {
            sm.FirstName = "John";
            sm.LastName = "Doe";
            sm.AddressState = "Fantasy Island";

            var context = new ValidationContext(sm, serviceProvider: null, items: null);
            ICollection<ValidationResult> results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sm, context, results);

            Assert.IsTrue(isValid);
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void Verify_If_All_Blank_Return_3_Validation_Errors()
        {
            string[] missingFields = { "FirstName", "LastName", "AddressState" };
            int counter = 0;

            var context = new ValidationContext(sm, serviceProvider: null, items: null);
            ICollection<ValidationResult> results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sm, context, results);

            Assert.IsFalse(isValid);
            Assert.AreEqual(3, results.Count);

            foreach (var result in results)
            {
                Assert.AreEqual(String.Format("The {0} field is required.", missingFields[counter++]), result.ErrorMessage);
            }
        }

        [Test]
        public void Verify_Some_Invalid_ZipCodes_Return_Validation_Errors()
        {
            var expectedError = "AddressZip is not a valid US Zip Code";
            string[] failureTests = { "ABCDE", "ABCDE-FGHI", "1", "12", "123", "1234", "123456", "123456789", "12345 6789" };

            sm.FirstName = "John";
            sm.LastName = "Doe";
            sm.AddressState = "Fantasy Island";

            foreach (var test in failureTests)
            {
                sm.AddressZip = test;

                var context = new ValidationContext(sm, serviceProvider: null, items: null);
                ICollection<ValidationResult> results = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(sm, context, results, true);

                Assert.IsFalse(isValid, String.Format("Failed on test {0}", test));
                Assert.AreEqual(1, results.Count, String.Format("Failed on test {0}", test));
                Assert.AreEqual(expectedError, results.First().ErrorMessage, String.Format("Failed on test {0}", test));
            }
        }

        [Test]
        public void Verify_Some_Valid_ZipCodes_Return__No_Validation_Errors()
        {
            sm.FirstName = "John";
            sm.LastName = "Doe";
            sm.AddressState = "Fantasy Island";

            string[] failureTests = { "12345", "12345-6789" };

            foreach (var test in failureTests)
            {
                sm.AddressZip = test;

                var context = new ValidationContext(sm, serviceProvider: null, items: null);
                ICollection<ValidationResult> results = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(sm, context, results);

                Assert.IsTrue(isValid);
                Assert.AreEqual(0, results.Count);
            }
        }
    }
}
