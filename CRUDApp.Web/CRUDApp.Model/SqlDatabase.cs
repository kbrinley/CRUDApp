using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Model
{
    public class SqlDatabase : IDatabaseManager<StudentsModel>
    {
        private static SqlDatabase TheInstance;
        private String ConnectionString = @"Server=LOCALHOST\SQLEXPRESS;Database=CRUDDB;Integrated Security=true;";

        private SqlDatabase()
        {

        }

        public static SqlDatabase TheSqlDatabase()
        {
            if (TheInstance == null)
                TheInstance = new SqlDatabase();
            return TheInstance;
        }

        public List<StudentsModel> GetAll()
        {
            List<StudentsModel> result = new List<StudentsModel>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("GetAllStudents", connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new StudentsModel()
                            {
                                ID = reader.GetInt32(0),
                                FirstName = GetStringWithNullCheck(reader, 1),
                                MiddleName = GetStringWithNullCheck(reader, 2),
                                LastName = GetStringWithNullCheck(reader, 3),
                                AddressLine1 = GetStringWithNullCheck(reader, 4),
                                AddressLine2 = GetStringWithNullCheck(reader, 5),
                                AddressCity = GetStringWithNullCheck(reader, 6),
                                AddressState = GetStringWithNullCheck(reader, 7),
                                AddressZip = GetStringWithNullCheck(reader, 8)
                            });
                        }
                    }
                }
            }
            return result;
        }

        private string GetStringWithNullCheck(SqlDataReader reader, int column)
        {
            if (!reader.IsDBNull(column))
                return reader.GetString(column);
            else
                return "";
        }

        public StudentsModel GetRecord(int id)
        {
            StudentsModel result = new StudentsModel();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("GetStudent", connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter("@id", id));

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.FirstName = (string)reader["firstname"];
                            result.MiddleName = (string)reader["middlename"];
                            result.LastName = (string)reader["lastname"];
                            result.AddressCity = (string)reader["city"];
                            result.AddressState = (string)reader["state"];
                        }
                    }
                }
            }
            return result;
        }

        public int GetNextId()
        {
            object result;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("GetNextId", connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    connection.Open();

                    result = command.ExecuteScalar();
                }
            }
            return (int)result;
        }

        public bool InsertRecord(StudentsModel theRecord)
        {
            if (theRecord.ID == -1)
                theRecord.ID = GetNextId();

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand("InsertStudent", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        command.Parameters.Add(new SqlParameter("@id", theRecord.ID));
                        command.Parameters.Add(new SqlParameter("@firstname", theRecord.FirstName));
                        command.Parameters.Add(new SqlParameter("@middlename", theRecord.MiddleName));
                        command.Parameters.Add(new SqlParameter("@lastname", theRecord.LastName));
                        command.Parameters.Add(new SqlParameter("@addressline1", theRecord.AddressLine1));
                        command.Parameters.Add(new SqlParameter("@addressline2", theRecord.AddressLine2));
                        command.Parameters.Add(new SqlParameter("@city", theRecord.AddressCity));
                        command.Parameters.Add(new SqlParameter("@state", theRecord.AddressState));
                        command.Parameters.Add(new SqlParameter("@zipcode", theRecord.AddressZip));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool UpdateRecord(StudentsModel theRecord)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand("UpdateStudent", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        command.Parameters.Add(new SqlParameter("@id", theRecord.ID));
                        command.Parameters.Add(new SqlParameter("@firstname", theRecord.FirstName));
                        command.Parameters.Add(new SqlParameter("@middlename", theRecord.MiddleName));
                        command.Parameters.Add(new SqlParameter("@lastname", theRecord.LastName));
                        command.Parameters.Add(new SqlParameter("@addressline1", theRecord.AddressLine1));
                        command.Parameters.Add(new SqlParameter("@addressline2", theRecord.AddressLine2));
                        command.Parameters.Add(new SqlParameter("@city", theRecord.AddressCity));
                        command.Parameters.Add(new SqlParameter("@state", theRecord.AddressState));
                        command.Parameters.Add(new SqlParameter("@zipcode", theRecord.AddressZip));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool DeleteRecord(StudentsModel theRecord)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var command = new SqlCommand("DeleteStudent", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        command.Parameters.Add(new SqlParameter("@id", theRecord.ID));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
