using EnsaAbscence.ModelControllers;
using EnsaAbscence.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnsaAbscence.Vues
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Search : ContentPage
	{
        String filiereSelected;
        String AnneeSelect;
        int filiereID;
        List<Etudiants> etudiants;
        List<AddCourse> Module;
        ControllerAbsence Absenc;
        String dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GestionAbsences.db3");
        public Search ()
		{
			InitializeComponent ();
            
        }
        private void filiereAnne_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            filiereID = picker.SelectedIndex;
            filiereSelected = filiereAnne.SelectedItem.ToString();
            AnnePicker.Items.Clear();
            AnnePicker.IsEnabled = true;

            switch (filiereID)
            {
                case 0: AnnePicker.Items.Add("1 ere annee"); AnnePicker.Items.Add("2 eme annee"); break;
                case 1: AnnePicker.Items.Add("3 ere annee"); AnnePicker.Items.Add("4 eme annee"); AnnePicker.Items.Add("5 eme annee"); break;
                case 2: AnnePicker.Items.Add("3 ere annee"); AnnePicker.Items.Add("4 eme annee"); AnnePicker.Items.Add("5 eme annee"); break;
                case 3: AnnePicker.Items.Add("3 ere annee"); AnnePicker.Items.Add("4 eme annee"); AnnePicker.Items.Add("5 eme annee"); break;
                case 4: AnnePicker.Items.Add("3 ere annee"); AnnePicker.Items.Add("4 eme annee"); AnnePicker.Items.Add("5 eme annee"); break;

            }
        }
        private void AnnePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            // filiereID = picker.SelectedIndex;
            AnneeSelect = AnnePicker.SelectedItem.ToString();
            filiereSelected = filiereAnne.SelectedItem.ToString();
            var db = new SQLiteConnection(dbPath);
            TableQuery<Etudiants> tableQuery = db.Table<Etudiants>();
            etudiants = new List<Etudiants>();
            etudiants = tableQuery.Where(i => i.filier == filiereSelected && i.Annee == AnneeSelect).ToList<Etudiants>();
            ListEtudiants.ItemsSource = etudiants;
        }

        private void NomEtudiant_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Etudiants> nvetudiants = new List<Etudiants>();
            foreach(var etu in etudiants)
            {
                var len = nomEtudiant.Text.ToString().Length;
                if (nomEtudiant.Text.ToString().Equals(etu.details.Substring(0, len)))
                {
                    nvetudiants.Add(etu);
                }
            }
            ListEtudiants.ItemsSource = nvetudiants;
        }

        private void ListEtudiants_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var etud = ListEtudiants.SelectedItem as Etudiants;

            nbrAbsLabl.Text = etud.NbrAbsence.ToString();
            
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