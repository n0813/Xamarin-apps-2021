using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SQLProyecto01.Models;

namespace SQLProyecto01.Data
{
    public class FriendDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public FriendDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Friend>().Wait();
        }


        //Traer todos loa dados Select
        public async Task<List<Friend>> GetItemAsync()
        {
            return await database.Table<Friend>().ToListAsync();
        }

        //Traer un solo registro por id
        public Task<Friend> GetItemAsync(int id)
        {
            return database.Table<Friend>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        //Guardar y Actualizar
        public Task<int> SaveItemAsync(Friend item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        //Eliminar registro
        public Task<int> DeleteItemAsync(Friend item)
        {
            return database.DeleteAsync(item);
        }



    }
}
