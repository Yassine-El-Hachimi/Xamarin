using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsaAbscence.ModelControllers;
using EnsaAbscence.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace EnsaAbscence
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        UserRepository usr;
        public Page1 ()
		{
            
            usr = new UserRepository();
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
            if (!String.IsNullOrEmpty(prof.Nom) && prof.Nom.Length >= 3) //
            {
                if (!String.IsNullOrEmpty(prof.Prenom) && prof.Prenom.Length >= 3)
                {
                    if (!String.IsNullOrWhiteSpace(prof.Pass) && prof.Pass.Length >4)
                    {
                            usr.SaveProffesseur(prof);
                        //direction sur la bonne page
                            await Navigation.PushAsync(new MainPage(), true);
                            
                    }
                    else
                    {
                        await DisplayAlert("Erreur de saisie", "le password doit avoir plus de 4 caracteres", "OK");
                    }

                }
                else
                {
                    await DisplayAlert("Erreur de saisie", "le prenom doit avoir plus de 2 caracteres", "OK");
                }

            }
            else
            {
                await DisplayAlert("Erreur de saisie", "le nom doit avoir plus de 2 caracteres", "OK");
                
            }
           
            
        
        }

        private async void backButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }

       
    }
}