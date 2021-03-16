﻿using EnsaAbscence.Models;
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
	public partial class HistoriqueAbsences : ContentPage
	{
		String dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GestionAbsences.db3");
	    List<Absence> Abs;
		public HistoriqueAbsences ()
		{
            InitializeComponent();
            Abs = new List<Absence>();
            chargerData();
            
		}

		public void chargerData()
		{
			var db = new SQLiteConnection(dbPath);
			HistoAb.ItemsSource = db.Table<Absence>().ToList();
		}
        //Navigation
        private async void boutonAbsence_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }
        private async void goButton_OnClicked(object sender, EventArgs e)
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