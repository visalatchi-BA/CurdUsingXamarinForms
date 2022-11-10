using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CurdUsingXamarinForms
{
    public class DeleteCompanyPage : ContentPage
    {
        private ListView _listView;
        private Button _button;
        private Entry _nameEntry;

        Company _company = new Company();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB = db3");// syntax


        public DeleteCompanyPage()
        {

            this.Title = "Delete Company";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listview_ItemSelected;

            stackLayout.Children.Add(_listView);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Company Name";
            stackLayout.Children.Add(_nameEntry);

            _button = new Button();
            _button.Text = "Delete";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);



            Content = stackLayout;


        }
        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Company company = new Company()
            {
                //Id = Convert.ToInt32(_idEntry.Text),
                Name = _nameEntry.Text,
            };


                db.Table<Company>().Delete(x=>x.Id== _company.Id);
           
            await DisplayAlert(null, company.Name + " Deleted Sucessfully", "OK");
            await Navigation.PopAsync();
        }
        private void _listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _company = (Company)e.SelectedItem;
            _nameEntry.Text = _company.Name;

        }
    }
}