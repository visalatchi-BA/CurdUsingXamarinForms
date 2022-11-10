using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CurdUsingXamarinForms
{
    public class EditCompanyPage : ContentPage
    {
        private ListView _listview;
        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _addressEntry;
        private Button _button;
        Company _Company= new Company();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB = db3");// syntax





        public EditCompanyPage()
        {
            this.Title = "Edit Company";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            _listview = new ListView();
            _listview.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            _listview.ItemSelected += _listview_ItemSelected;
            stackLayout.Children.Add(_listview);

           _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

             _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Company Name";
            stackLayout.Children.Add(_nameEntry);

            _addressEntry = new Entry();
            _addressEntry.Keyboard = Keyboard.Text;
            _addressEntry.Placeholder = "Address";
            stackLayout.Children.Add(_addressEntry);

            _button = new Button();
            _button.Text = "Update";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
           


        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Company company = new Company()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Name = _nameEntry.Text,
                Address = _addressEntry.Text,

            };
            db.Update(company);
            await DisplayAlert(null, company.Name + " Updated", "OK");
            await Navigation.PopAsync();
        }

        private void _listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _Company = (Company)e.SelectedItem;
            _idEntry.Text = _Company.Id.ToString();
            _nameEntry.Text = _Company.Name;
            _addressEntry.Text = _Company.Address;

        }
    }
}