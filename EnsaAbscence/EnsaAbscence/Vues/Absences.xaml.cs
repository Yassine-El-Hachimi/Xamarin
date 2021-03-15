using EnsaAbscence.ModelControllers;
using EnsaAbscence.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        String AnneeSelect;
        int filiereID;
        List<Etudiants> etudiants;
        List<AddCourse> Module;
        ControllerAbsence Absenc;
        String dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GestionAbsences.db3");
        public Absences () 
		{
            Module = new List<AddCourse>();
            Absenc = new ControllerAbsence();
            etudiants = new List<Etudiants>();
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

        private void AnnePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
           // filiereID = picker.SelectedIndex;
            AnneeSelect = AnnePicker.SelectedItem.ToString();
            filiereSelected = filiereAnne.SelectedItem.ToString();
            LessonPicker.IsEnabled = true;
            LessonPicker.Items.Clear();
            var db = new SQLiteConnection(dbPath);
            TableQuery<AddCourse> tableQuery = db.Table<AddCourse>();
            Module = tableQuery.Where(i =>i.CoursFiliere == filiereSelected && i.CoursAnnee==AnneeSelect).ToList();
            foreach(var v in Module)
            {
                LessonPicker.Items.Add(v.CoursName);
            }
        }

        private void LessonPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            // filiereID = picker.SelectedIndex;
            AnneeSelect = AnnePicker.SelectedItem.ToString();
            filiereSelected = filiereAnne.SelectedItem.ToString();
            var db = new SQLiteConnection(dbPath);
            TableQuery<Etudiants> tableQuery = db.Table<Etudiants>();
            FicheAbsence.ItemsSource= tableQuery.Where(i => i.filier == filiereSelected && i.Annee == AnneeSelect);
            
        }
    }
}