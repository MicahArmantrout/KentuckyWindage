using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KentuckyWindageForms.ViewModels;
using Xamarin.Forms;

namespace KentuckyWindageForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
         
        }
    }
}
