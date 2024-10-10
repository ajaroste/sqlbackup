using sqlbackup.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using MySql.Data.MySqlClient;
using sqlbackup.Model;

namespace sqlbackup.Manager
{
   public static class SqlConnector
    {
        public static SqlConnectionModel SqlConnection(SqlEnum SQL,string Server , string Username, string Passworld)
        {

            SqlConnectionModel Sqlmodel = new SqlConnectionModel();
            string connectionString;
            if (SQL == SqlEnum.POSTGRESQL)
            {

                connectionString = $"Server={Server};User Id={Username};Password={Passworld};";

                List<string> databaseNames = new List<string>();

                using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("SELECT datname FROM pg_database WHERE datistemplate = false;", connection))
                        {
                            using (Npgsql.NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Sqlmodel.Databases.Add(reader["datname"].ToString());
                                }
                            }
                        }

                        //return databaseNames;
                    }
                    catch (Npgsql.NpgsqlException ex)
                    {
                       Sqlmodel.Errors =  ex.Message;
                    }
                    return Sqlmodel;
                }


                //MessageBox.Show("POSGRESQL");
            }
            else if (SQL == SqlEnum.MSSQL)
            {
               connectionString = $"Server={Server};User Id={Username};Password={Passworld};";

                List<string> databaseNames = new List<string>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open(); 

                        using (SqlCommand command = new SqlCommand("SELECT name FROM sys.databases;", connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Sqlmodel.Databases.Add(reader["name"].ToString()); 
                                }
                            }
                        }

                       
                    }
                    catch (SqlException ex)
                    {
                        Sqlmodel.Errors = ex.Message;

                    }
                    return Sqlmodel;
                }

               
                //MessageBox.Show("MSSQL");
            }
            else if (SQL == SqlEnum.MYSQL)
            {
                connectionString = $"Server={Server};User Id={Username};Password={Passworld};";

                List<string> databaseNames = new List<string>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (MySqlCommand command = new MySqlCommand("SHOW DATABASES;", connection))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                   Sqlmodel.Databases.Add(reader[0].ToString()); // İlk sütun veritabanı adı
                                }
                            }
                        }

                        //return databaseNames;
                    }
                    catch (MySqlException ex)
                    {
                        Sqlmodel.Errors= ex.Message;
                       
                    } 
                    return Sqlmodel;
                }
            }


            return null;
        }




    }
}
