using EnsaAbscence.ModelControllers;
using EnsaAbscence.Models;
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
	public partial class AddLesson : ContentPage
	{
        String filiereSelected;
        int filiereID;
        ControllerCourse add;
        public AddLesson ()
		{
            add = new ControllerCourse();
            InitializeComponent ();
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
                await DisplayAlert("Erreur de saisie", "Le cours doit appartenir à une filière et année!", "OK");
            }
            else
            {
                AddCourse cours = new AddCourse()
                {
                    CoursName= NomModule.Text,
                    CoursFiliere = filiereAnne.SelectedItem.ToString(),
                    CoursAnnee = AnnePicker.SelectedItem.ToString()
                };
                add.SaveCourse(cours);
                await DisplayAlert(null, " Le cours " + cours.CoursName + " est bien enregistré", "ok");
                //direction sur la bonne page

            }

        }
    }

}
