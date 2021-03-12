using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsaAbscence.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnsaAbscence
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
     
		public Page1 ()
		{
			InitializeComponent ();
            SignUpButton.Clicked += SignUpButton_Clicked;
		}

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            
            Proffesseur prof = new Proffesseur()
            {
                Nom = nomEntry.Text,
                Prenom = prenomEntry.Text,
                Pass = passwordEntry.Text
            };
            await App.Usr.SaveProffesseurAsync(prof);
            await DisplayAlert(null, prof.Nom+ " bien enregistre", "ok");
        
        }

        private async void backButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Navigation(),true);
        }
    }
}