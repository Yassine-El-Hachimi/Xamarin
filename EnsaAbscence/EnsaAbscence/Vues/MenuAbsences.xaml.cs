using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnsaAbscence.Vues
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuAbsences : ContentPage
	{
		public MenuAbsences ()
		{
			InitializeComponent ();
		}
        private async void marquerAbsc(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Absences(), true);
        }
        private async void HistoriqueAbs(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoriqueAbsences(), true);
        }
        //Navigation
        private async void backButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }
        private async void boutonAbsence_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuAbsences(), true);
        }
        private async void boutonSearch_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Search(), true);
        }
        private async void boutonLesson_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddLesson(), true);
        }
        private async void boutonStudent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Etudiant(), true);
        }
    }
}