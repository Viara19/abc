using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace abcBLANK.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pen : ContentPage
    {
        public pen()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new pages.writtingLetters()); //changes page from pen to writtingLetters
        }
        public class Resource
        {
            public class drawable
            {
                public const int himikal_napkin = 0x123;
                public const int himikal_darts = 0x123;

            }
        }
        }
}