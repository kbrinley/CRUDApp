using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDApp.Web.Models
{
    public class MockDatabase : IDatabaseManager<StudentsModel>
    {
        public List<StudentsModel> GetAll()
        {
            var records = new List<StudentsModel>();
            records.Add(new StudentsModel { FirstName = "John", MiddleName = "Andrew", LastName = "Doe", AddressLine1 = "123 Main Street", AddressCity = "Fantasy Island", AddressState = "IL", AddressZip = "60735", ID = 1 });
            records.Add(new StudentsModel { FirstName = "John", MiddleName = "Barry", LastName = "Doe", AddressLine1 = "265 South 1st Street", AddressCity = "Fantasy Island", AddressState = "IL", AddressZip = "60735", ID = 2 });
            records.Add(new StudentsModel { FirstName = "John", MiddleName = "Chris", LastName = "Doe", AddressLine1 = "389 North 5th Street", AddressCity = "Fantasy Island", AddressState = "IL", AddressZip = "60735", ID = 3 });
            records.Add(new StudentsModel { FirstName = "John", MiddleName = "Dan", LastName = "Doe", AddressLine1 = "456 Mary Lane", AddressCity = "Fantasy Island", AddressState = "IL", AddressZip = "60735", ID = 4 });
            records.Add(new StudentsModel { FirstName = "John", MiddleName = "Evan", LastName = "Doe", AddressLine1 = "512 Walnut St.", AddressCity = "Fantasy Island", AddressState = "IL", AddressZip = "60735", ID = 5 });

            return records;
        }

        public StudentsModel GetRecord(int id)
        {            
            var model = from students in GetAll() 
                        where students.ID == id 
                        select students;

            return model.FirstOrDefault();
        }


        public bool InsertRecord(StudentsModel theRecord)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRecord(StudentsModel theRecord)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRecord(StudentsModel theRecord)
        {
            throw new NotImplementedException();
        }
    }
}