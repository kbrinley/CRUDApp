using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CRUDApp.Web.Models
{
    public class StudentsModel : IDataModel<StudentsModel>
    {
        #region Properties

        public int ID { get; internal set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String AddressCity { get; set; }
        public String AddressState { get; set; }
        public String AddressZip { get; set; }

        #endregion Properties

        #region Constructor

        public StudentsModel()
        {
            // Indicate a new Record.
            this.ID = -1;
        }

        #endregion Constructor

        #region Static Methods

        /// <summary>
        /// Retrieves all of the records in the database.
        /// </summary>
        /// <returns>A Collection of all of the records</returns>
        public static ICollection<StudentsModel> GetRecords()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the record by ID.
        /// </summary>
        /// <param name="idOfRecord"></param>
        /// <returns></returns>
        public static StudentsModel GetRecord(int idOfRecord)
        {
            throw new NotImplementedException();
        }

        #endregion Static Methods

        #region Class Methods

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        #endregion Class Methods
    }
}