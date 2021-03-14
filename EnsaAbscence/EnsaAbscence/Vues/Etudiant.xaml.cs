using EnsaAbscence.Models;
using EnsaAbscence.ModelControllers;
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
    public partial class Etudiant : ContentPage
    {
        String filiereSelected;
        int filiereID;
        controllerEtudiant ctrlEtud;     
        public Etudiant()
        {
            ctrlEtud = new controllerEtudiant();
            InitializeComponent();
        }

        private void filiereText_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            filiereID = picker.SelectedIndex;
            filiereSelected = filiereAnne.SelectedItem.ToString();
            AnnePicker.IsEnabled = true;
            AnnePicker.Items.Clear();    
            switch (filiereID)
            {
                case 0: AnnePicker.Items.Add("1 ere annee"); AnnePicker.Items.Add("2 eme annee"); break;
                case 1: AnnePicker.Items.Add("3 ere annee"); AnnePicker.Items.Add("4 eme annee"); AnnePicker.Items.Add("5 eme annee"); break;
                case 2: AnnePicker.Items.Add("3 ere annee"); AnnePicker.Items.Add("4 eme annee"); AnnePicker.Items.Add("5 eme annee"); break;
                case 3: AnnePicker.Items.Add("3 ere annee"); AnnePicker.Items.Add("4 eme annee"); AnnePicker.Items.Add("5 eme annee"); break;
                case 4: AnnePicker.Items.Add("3 ere annee"); AnnePicker.Items.Add("4 eme annee"); AnnePicker.Items.Add("5 eme annee"); break;

            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            

            if (filiereAnne.SelectedIndex <= 0 || AnnePicker.SelectedIndex <= 0)
            {
                await DisplayAlert("Erreur de saisie", "L'étudiant doit appartenir à une filière et année!", "OK");
            }
            else {
                Etudiants Etud = new Etudiants()
                {
                    cne = cne.Text,
                    nom = nom.Text,
                    prenom = prenom.Text,
                    email = email.Text,
                    filier = filiereAnne.SelectedItem.ToString(),
                    Annee = AnnePicker.SelectedItem.ToString()
                };
                    ctrlEtud.SaveEtudiant(Etud);
                    await DisplayAlert(null, " L'etudiant "+Etud.nom+ " est bien enregistré", "ok");
                       //direction sur la bonne page

                  }
                   
        }
    }
}