using EnsaAbscence.ModelControllers;
using EnsaAbscence.Models;
using EnsaAbscence.Vues;
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
        List<Etudiants> EtudiansAbsent;
        List<AddCourse> Module;
        ControllerAbsence Absenc;
        String dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GestionAbsences.db3");
        public Absences()
        {
            Module = new List<AddCourse>();
            Absenc = new ControllerAbsence();
            etudiants = new List<Etudiants>();
            EtudiansAbsent = new List<Etudiants>();
            InitializeComponent();


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

            filiereSelected = filiereAnne.SelectedItem.ToString();
            AnneeSelect = AnnePicker.SelectedItem.ToString();

            LessonPicker.Items.Clear();
            LessonPicker.IsEnabled = true;

            var db = new SQLiteConnection(dbPath);
            TableQuery<AddCourse> tableQuery = db.Table<AddCourse>();
            Module = tableQuery.Where(i => i.CoursFiliere == filiereSelected && i.CoursAnnee == AnneeSelect).ToList();
            foreach (var v in Module)
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
            FicheAbsence.ItemsSource = tableQuery.Where(i => i.filier == filiereSelected && i.Annee == AnneeSelect);
            ValidationAbsences.IsEnabled = true;
        }



        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            var isAbsent = (SwitchCell)sender;
            var student = (Etudiants)isAbsent.BindingContext;
            var db = new SQLiteConnection(dbPath);

            if (isAbsent.On)
            {
                if (!EtudiansAbsent.Contains(student))
                {
                    student.NbrAbsence++;
                    EtudiansAbsent.Add(student);
                    db.Update(student);
                }
            }
            else
            {
                if (EtudiansAbsent.Contains(student))
                {
                    student.NbrAbsence--;
                    EtudiansAbsent.Remove(student);
                    db.Update(student);
                }
            }
        }

        private void ValidationAbsences_Clicked(object sender, EventArgs e)
        {
           
           
        }

        private void ValidationAbsences_Clicked_1(object sender, EventArgs e)
        {
           
            var db = new SQLiteConnection(dbPath);
            Absence abs = new Absence()
            {
                nom_filiere = filiereAnne.SelectedItem.ToString(),
                annee_filiere = AnnePicker.SelectedItem.ToString(),
                nom_course = LessonPicker.SelectedItem.ToString(),
                Date = DateTime.Now,
                students = EtudiansAbsent
            };
            Absenc.SaveAbsence(abs);
            DisplayAlert(null, "La liste d'absence est  bien enregistre", "ok");
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