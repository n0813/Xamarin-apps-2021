using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SQLProyecto02.Models;

namespace SQLProyecto02.Data
{
    public class DatabaseQuery
    {

        readonly SQLiteAsyncConnection _database;

        public DatabaseQuery(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Friend>().Wait();

        }


        #region CRUD

        //Traer todos loa dados Select
        public async Task<List<Friend>> TraerDatos()
        {
            return await _database.Table<Friend>().ToListAsync();
        }

        //Traer un solo registro por id
        public Task<Friend> TraerRegistro(int id)
        {
            return _database.Table<Friend>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        //Guardar y Actualizar
        public Task<int> GuardarRegistro(Friend item)
        {
            if (item.ID != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        //Eliminar registro
        public Task<int> EliminarRegistro(Friend item)
        {
            return _database.DeleteAsync(item);
        }

        #endregion

    }
}
