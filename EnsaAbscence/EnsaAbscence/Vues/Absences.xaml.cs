using EnsaAbscence.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace EnsaAbscence
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Absences : ContentPage
	{
        String filiereSelected;
        int filiereID;
        List<Etudiants> etudiants;
        public Absences () 
		{
            Etudiants et = new Etudiants() { nom = "djaloud" };
            etudiants = new List<Etudiants>();
            etudiants.Add(et);
            InitializeComponent();
            FicheAbsence.ItemsSource = etudiants;
                
            
            
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
        private void anneeText_SelectedIndexChanged(object sender, EventArgs e)
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


    }
}