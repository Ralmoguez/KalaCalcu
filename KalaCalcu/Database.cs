using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace KalaCalcu
{
    public class Database
    {
        private readonly SQLiteAsyncConnection database;
        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return database.InsertOrReplaceAsync(user);
        }

        public Task<User> GetUser(string username)
        {
            return database.Table<User>().Where(i => i.Username == username).FirstOrDefaultAsync();
        }

        public Task<User> CheckIfCorrectUser(string username, string password)
        {
            return database.Table<User>().Where(i => i.Username == username).Where(i => i.Password == password).FirstOrDefaultAsync();
        }
    }
}
