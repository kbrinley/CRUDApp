using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The type of the object itself.</typeparam>
    interface IDataModel<T>
    {
        /// <summary>
        /// Saves the current record object.
        /// </summary>
        /// <returns>True if the save was successful, false otherwise</returns>
        bool Save();

        /// <summary>
        /// Deletes the current record object.
        /// </summary>
        /// <returns>True if deletion was successful, false otherwise.</returns>
        bool Delete();
    }
}
