using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CurdUsingXamarinForms
{
    public class Homepage : ContentPage
    {
        public Homepage()
        {
            this.Title = "Select Option";
            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Add Company";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);//push thiz button into stacklayout
            Content = stackLayout;

            button  = new Button();
            button.Text = "Get";
            button.Clicked += Button_Get_Clicked;
            stackLayout.Children.Add(button);//push thiz button into stacklayout
            Content = stackLayout;

            button = new Button();
            button.Text = "Edit";
            button.Clicked += Button_Edit_Clicked;
            stackLayout.Children.Add(button);//push thiz button into stacklayout
            Content = stackLayout;

            button = new Button();
            button.Text = "Delete";
            button.Clicked += Button_Delete_Clicked;
            stackLayout.Children.Add(button);//push thiz button into stacklayout
            Content = stackLayout;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCompanyPage());

        }
        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllCompanyPage());

        }
        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCompanyPage());

        }
        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCompanyPage());

        }
    }
}