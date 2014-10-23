using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace CRUDApp.Model
{
    public class StudentsModel : IDataModel<StudentsModel>
    {
        #region Properties
        
        public int ID { get; internal set; }
        
        [Required()]
        public String FirstName { get; set; }
        
        public String MiddleName { get; set; }

        [Required()]
        public String LastName { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String AddressCity { get; set; }
        
        [Required()]
        public String AddressState { get; set; }

        [RegularExpression(@"^/d{5}(-/d{4})?$", 
            ErrorMessage="AddressZip is not a valid US Zip Code")]
        public String AddressZip { get; set; }

        #endregion Properties

        #region Class Variables

        internal IDatabaseManager<StudentsModel> _DBManager;

        #endregion Class Variables

        #region Constructor

        public StudentsModel()
        {
            // Indicate a new Record.
            this.ID = -1;
            _DBManager = new MockDatabase();
        }

        public StudentsModel(IDatabaseManager<StudentsModel> theManager) : this()
        {
            _DBManager = theManager;
        }

        #endregion Constructor

        #region Static Methods

        /// <summary>
        /// Retrieves all of the records in the database.
        /// </summary>
        /// <returns>A Collection of all of the records</returns>
        public static ICollection<StudentsModel> GetRecords()
        {
            return GetRecords(new MockDatabase());
        }

        public static ICollection<StudentsModel> GetRecords(IDatabaseManager<StudentsModel> theManager)
        {
            return theManager.GetAll();
        }

        /// <summary>
        /// Retrieves the record by ID.
        /// </summary>
        /// <param name="idOfRecord"></param>
        /// <returns></returns>
        public static StudentsModel GetRecord(int idOfRecord)
        {
            return GetRecord(idOfRecord, new MockDatabase());
        }

        public static StudentsModel GetRecord(int idOfRecord, IDatabaseManager<StudentsModel> theManager)
        {
            return theManager.GetRecord(idOfRecord);
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