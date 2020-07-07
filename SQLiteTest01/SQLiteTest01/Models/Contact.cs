using System;
using SQLite;

namespace SQLiteTest01.Models
{

    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string  Lastname { get; set; }
        public string Email { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public string  Address { get; set; }


        public Contact()
        {
        }
    }
}
