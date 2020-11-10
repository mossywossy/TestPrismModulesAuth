using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuthModule.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
