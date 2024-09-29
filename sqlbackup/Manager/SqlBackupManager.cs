using sqlbackup.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace sqlbackup.Manager
{ 

    public static class SqlBackupManager
    {
        
        public static string SqlBackup(SqlEnum SQL, string Backupfile, string Database, string Server, string Username, string Passworld)
        {

        
            if (SQL == SqlEnum.POSGRESQL)
            {
                string backupFile = $"{Backupfile}/{Database}_{DateTime.Now:yyyy-MM-dd-HH-mm}.bak";
                string pgDumpPath = @"C:\Program Files\PostgreSQL\13\bin\pg_dump.exe"; // pg_dump'ın tam yolunu belirtin

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = pgDumpPath,
                    Arguments = $"-h {Server} -U {Username} -F c -b -v -f \"{backupFile}\" {Database}",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                // Parola girişini sağlamak için
                Environment.SetEnvironmentVariable("PGPASSWORD", Passworld);

                try
                {
                    using (Process process = Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        // Hata kontrolü
                        if (process.ExitCode != 0)
                        {
                            string error = process.StandardError.ReadToEnd();
                            return $"Yedekleme sırasında hata oluştu: {error}";
                        }

                        return $"Veritabanı {Database} başarıyla {Backupfile} yoluna yedeklendi.";
                    }
                }
                catch (Exception ex)
                {
                    return $"Yedekleme sırasında hata oluştu: {ex.Message}";
                }


            }
            else if (SQL == SqlEnum.MSSQL)
            {

                using (SqlConnection connection = new SqlConnection($"Server={Server};User Id={Username};Password={Passworld};"))
                {
                    string query = $@"
                BACKUP DATABASE [{Database}] 
                TO DISK = '{Backupfile+@"\"+Database+"_"+ DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".bak"}' 
                WITH FORMAT, INIT, SKIP, REWIND, NOUNLOAD, STATS = 10";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            return $"Veritabanı {Database} başarıyla {Backupfile} yoluna yedeklendi.";
                        }
                        catch (Exception ex)
                        {
                            return$"Yedekleme sırasında hata oluştu: {ex.Message}";
                        }
                    }
                }

                }
            else if (SQL == SqlEnum.MYSQL)
            {
                string connectionString = $"Server={Server};database={Database};uid={Username};pwd={Passworld};";

                try
                {
                    string backupFilePath = Path.Combine(Backupfile, $"{Database}_{DateTime.Now.ToString("yyyy-MM-dd-HH-mm")}.sql");

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mySqlBackup = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                mySqlBackup.ExportToFile(backupFilePath);
                                conn.Close();
                            }
                        }
                    }
                    return $"Veritabanı {Database} başarıyla {Backupfile} yoluna yedeklendi.";
                }
                catch (Exception ex)
                {
                    return $"Yedekleme sırasında hata oluştu: {ex.Message}";
                }
            }
            return "";
        }

    }

}
