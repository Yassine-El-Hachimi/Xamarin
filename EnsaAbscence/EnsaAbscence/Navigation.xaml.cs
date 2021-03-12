using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnsaAbscence
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Navigation : ContentPage
	{
		public Navigation ()
		{
			InitializeComponent ();
		}
        private async void backButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }
        private async void goButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Absences(),true);
        }

    }
}