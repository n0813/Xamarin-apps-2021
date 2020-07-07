using System;
using SQLite;

namespace SQLProyecto01.Models
{
    public class Friend
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
