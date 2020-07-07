using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteTest01.Models;
using Xamarin.Forms;

namespace SQLiteTest01
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int _Id = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(int ID)
        {
            InitializeComponent();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                var contacts = conn.Table<Contact>().Where(x => x.ID == ID);

                nameEntry.Text = contacts.ToList()[0].Name;
                lasnameEntry.Text = contacts.ToList()[0].Lastname;
                emailEntry.Text = contacts.ToList()[0].Email;
                phoneEntry.Text = contacts.ToList()[0].PhoneNumber;
                addressEntry.Text = contacts.ToList()[0].Address;

                this._Id = ID;
            }

        }
        private  SQLiteAsyncConnection databases;

        //Guardar y Actualizar
        public Task<int> SaveItemAsync(Contact item)
        {
            databases = new SQLiteAsyncConnection(App.FilePath);
            databases.CreateTableAsync<Contact>().Wait();

            if (this._Id > 0)
            {
                return databases.UpdateAsync(item);
            }
            else
            {
                return databases.InsertAsync(item);
            }
        }

        void SaveButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (this._Id > 0)
            {
                Contact contact = new Contact()
                {
                    Name = nameEntry.Text,
                    Lastname = lasnameEntry.Text,
                    Email = emailEntry.Text,
                    PhoneNumber = phoneEntry.Text,
                    Address = addressEntry.Text,
                    ID = this._Id
                };

                Task<int> abc123 = this.SaveItemAsync(contact);

            }
            else
            {
                Contact contact = new Contact()
                {
                    Name = nameEntry.Text,
                    Lastname = lasnameEntry.Text,
                    Email = emailEntry.Text,
                    PhoneNumber = phoneEntry.Text,
                    Address = addressEntry.Text
                };
                Task<int> abc123 = this.SaveItemAsync(contact);
            }

            



            /* using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
             {

                 if (this._Id == 0)
                 {
                     //Creamos la tabla
                     conn.CreateTable<Contact>();
                     int rowsAdded = conn.Insert(contact);

                 }
                 else
                 {
                     //Update
                     int rowsUpdated = conn.Update(contact);

                 }

             }*/

            Navigation.PopAsync();


        }

        //Eliminar registro
        public Task<int> DeleteItemAsync(Contact item)
        {
            databases = new SQLiteAsyncConnection(App.FilePath);
            databases.CreateTableAsync<Contact>().Wait();
            return databases.DeleteAsync(item);
        }

        void DeleteButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameEntry.Text,
                Lastname = lasnameEntry.Text,
                Email = emailEntry.Text,
                PhoneNumber = phoneEntry.Text,
                Address = addressEntry.Text,
                ID = this._Id
            };

            Task<int> abc123 = this.DeleteItemAsync(contact);

            Navigation.PopAsync();

        }
    }
}
