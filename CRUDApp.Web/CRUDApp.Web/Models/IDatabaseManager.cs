using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Web.Models
{
    public interface IDatabaseManager<T>
    {
        List<T> GetAll();

        T GetRecord(int id);

        bool InsertRecord(T theRecord);

        bool UpdateRecord(T theRecord);

        bool DeleteRecord(T theRecord);
    }
}
