using System;
using System.Collections.Generic;
using SQLite;
using SQLiteTest01.Models;
using Xamarin.Forms;

namespace SQLiteTest01
{
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }


        void NewContactToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                var contacts = conn.Table<Contact>().ToList();

                contactsListView.ItemsSource = contacts;


            }
        
        }

        void OnItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;

            // this assumes your List is bound to a List<Club>
            //Club club = (Club)lv.SelectedItem;

            Contact contact = (Contact)lv.SelectedItem;


            // assuiming Club has an Id property
            Navigation.PushAsync(new MainPage(contact.ID));


        }
    }
}
