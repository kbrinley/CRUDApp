using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDApp.Model
{
    public class MockDatabase : IDatabaseManager<StudentsModel>
    {
        private static MockDatabase TheInstance;
        private Dictionary<int, StudentsModel> TestDB;
        private int NextID = 6;


        private MockDatabase()
        {
            TestDB = new Dictionary<int, StudentsModel>();
        }

        public static MockDatabase TheMockDatabase()
        {
            if (TheInstance == null)
                TheInstance = new MockDatabase();
            return TheInstance;
        }

        private void InitializeDatabase()
        {
            if (TestDB.Count() == 0)
            {
                // Initial population of the Test data.
                TestDB.Add(1, new StudentsModel { FirstName = "John", MiddleName = "Andrew", LastName = "Doe", AddressLine1 = "123 Main Street", AddressCity = "Fantasy Island", AddressState = "IL", AddressZip = "60735", ID = 1 });
                TestDB.Add(2, new StudentsModel { FirstName = "John", MiddleName = "Barry", LastName = "Doe", AddressLine1 = "265 South 1st Street", AddressCity = "Fantasy Island", AddressState = "IL", AddressZip = "60735", ID = 2 });
                TestDB.Add(3, new StudentsModel { FirstName = "John", MiddleName = "Chris", LastName = "Doe", AddressLine1 = "389 North 5th Street", AddressCity = "Fantasy Island", AddressState = "IL", AddressZip = "60735", ID = 3 });
                TestDB.Add(4, new StudentsModel { FirstName = "John", MiddleName = "Dan", LastName = "Doe", AddressLine1 = "456 Mary Lane", AddressCity = "Fantasy Island", AddressState = "IL", AddressZip = "60735", ID = 4 });
                TestDB.Add(5, new StudentsModel { FirstName = "John", MiddleName = "Evan", LastName = "Doe", AddressLine1 = "512 Walnut St.", AddressCity = "Fantasy Island", AddressState = "IL", AddressZip = "60735", ID = 5 });
            }
        }

        public List<StudentsModel> GetAll()
        {
            InitializeDatabase();

            var results = from students in TestDB
                          select students.Value;

            return results.ToList();
        }

        public StudentsModel GetRecord(int id)
        {
            InitializeDatabase();
            StudentsModel model;
            bool result = TestDB.TryGetValue(id, out model);

            return model;
        }


        public bool InsertRecord(StudentsModel theRecord)
        {
            InitializeDatabase();
            if (theRecord.ID == -1)
                theRecord.ID = NextID++;

            TestDB.Add(theRecord.ID, theRecord);

            return true;
        }

        public bool UpdateRecord(StudentsModel theRecord)
        {
            InitializeDatabase();
            if (!TestDB.ContainsKey(theRecord.ID))
                // Couldn't find existing record. Cannot update.
                return false;

            // We have the existing record, now we "update".
            TestDB[theRecord.ID] = theRecord;
            return true;
        }

        public bool DeleteRecord(StudentsModel theRecord)
        {
            InitializeDatabase();
            if (!TestDB.ContainsKey(theRecord.ID))
                // Couldn't find existing record. Cannot update.
                return false;

            TestDB.Remove(theRecord.ID);
            return true;
        }
    }
}