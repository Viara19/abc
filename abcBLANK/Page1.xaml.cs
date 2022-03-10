using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace abcBLANK
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {//Start
            await this.Navigation.PushAsync(new pages.pen()); //Changes pages from main to pen using async method
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {//Help
            await this.Navigation.PushAsync(new pages.help());//Changes pages from main to help using async method
        }
    }
}