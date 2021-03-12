using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.IO;
using EnsaAbscence.Models;
using EnsaAbscence.ModelControllers;

namespace EnsaAbscence
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            submitButton.Clicked += SubmitButton_Clicked;
        }

        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            var login = false;
            Proffesseur ouarrachi = new Proffesseur()
            {
                Nom = nomEtry.Text,
                Pass = passwordEntry.Text
            };

            var ProfListe = UserRepository.con.Table<Proffesseur>().Where(i => i.Nom.Equals(ouarrachi.Nom) && i.Pass.Equals(ouarrachi.Pass));       
                if(ProfListe!=null)
                {
                    login = true;
                }
            
            if (login) {await DisplayAlert(null, "bien authentifié", "ok"); }
            else
            {
                await DisplayAlert(null, "Black hacker", "ok");
            }
        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1(),true);
        }
    }
}
