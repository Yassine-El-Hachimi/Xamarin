﻿using System;
using System.Collections.Generic;
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
        List<Etudiant> etudiants;
		public Search ()
		{
			InitializeComponent ();
            etudiants = new List<Etudiant>();
            ListEtudiants.ItemsSource = etudiants;
        }
    }
}