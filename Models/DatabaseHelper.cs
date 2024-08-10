using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace BookTable.Models
{
    public static class DatabaseHelper
    {

        private static SQLiteAsyncConnection _database;

        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "booktable.db3"));
                    _database.CreateTableAsync<Paste>().Wait();
                }
                return _database;
            }
        }
    }
}
