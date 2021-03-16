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
        UserRepository usr;
        public MainPage()
        {
            usr= new UserRepository();
            InitializeComponent();
            submitButton.Clicked += SubmitButton_Clicked;
        }

        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            Proffesseur pr = new Proffesseur();
            Proffesseur ouarrachi = new Proffesseur()
            {
                Nom = nomEtry.Text,
                Pass = passwordEntry.Text
            };

            pr=usr.VerfierLog(ouarrachi);
            if (pr != null)
            {
                await DisplayAlert(null, "bien authentifié", "ok");
                await Navigation.PushAsync(new Navigation(), true);
            }
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
