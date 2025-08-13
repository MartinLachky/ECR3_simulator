using System;
using System.Data.SQLite;
using System.IO;  // Optional if you want to control DB path
using System.Windows.Forms;
using System.Reflection;

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
            // Add this block BEFORE Application.Run()
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string dllName = new AssemblyName(args.Name).Name + ".dll";
                string dllPath = Path.Combine(Application.StartupPath, "libs", dllName); // adjust folder as needed
                if (File.Exists(dllPath))
                    return Assembly.LoadFrom(dllPath);
                string runtimesPath = Path.Combine(Application.StartupPath, "runtimes");
                if (Directory.Exists(runtimesPath))
                {
                    foreach (var file in Directory.GetFiles(runtimesPath, dllName, SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                            return Assembly.LoadFrom(file);
                    }
                }
                return null;
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
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
