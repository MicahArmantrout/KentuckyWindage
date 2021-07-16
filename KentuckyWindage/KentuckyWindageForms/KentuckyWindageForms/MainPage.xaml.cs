using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KentuckyWindageForms.Models;
using Xamarin.Forms;

namespace KentuckyWindageForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new InputViewModel();
        }
    }
}
