using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;  // Optional if you want to control DB path

namespace ECR3_simulator
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Initialize the database before launching the main form
            InitializeDatabase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void InitializeDatabase()
        {
            string dbPath = System.IO.Path.Combine(Application.StartupPath, "responses.db");
            using (var conn = new SQLiteConnection("Data Source=" + dbPath))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS TerminalResponses (
                                  Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                  Timestamp TEXT,
                                  EcrId TEXT,
                                  Amount REAL,
                                  Currency TEXT,
                                  ApprovalCode TEXT,
                                  ApprovalMessage TEXT,
                                  RawJson TEXT
                               )";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
