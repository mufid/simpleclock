using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClock.Gui.Services
{
    public class PersistentStorage : IDisposable
    {
        // TODO implement internal mutex (in-app) and external mutex (outer app). Consider using pid-alike
        public PersistentStorage()
        {
             Db = new SQLiteConnection("app.sqdb");
        }

        public void Initialize()
        {
            Db.CreateTable<Models.Activity>();
            Console.WriteLine("Initialized and migrated...");
        }

        public void Dispose()
        {
            Console.WriteLine("Db is being closed...");
            Db.Close();
        }

        public SQLiteConnection Db { get; set; }
    }
}
