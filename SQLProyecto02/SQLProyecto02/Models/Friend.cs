using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace SQLProyecto02.Models
{
    public class Friend : INotifyPropertyChanged
    {
        private string firstName;
        private string phone;
        private string email;

        #region Implementación
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string FirstName
        {
            get => firstName; set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }
        public string Phone
        {
            get => phone; set
            {
                phone = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => email; set
            {
                email = value;
                OnPropertyChanged();
            }
        }


    }
}
