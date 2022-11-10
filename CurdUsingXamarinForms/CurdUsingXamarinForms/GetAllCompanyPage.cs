using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;

namespace CurdUsingXamarinForms
{
    public class GetAllCompanyPage : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB = db3");// syntax


        public GetAllCompanyPage()
        {
            this.Title = "Company";
            var db= new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            stackLayout.Children.Add(_listView);
            Content = stackLayout;
        }
    }
}