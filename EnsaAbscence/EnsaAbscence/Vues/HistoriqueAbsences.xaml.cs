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
	public partial class HistoriqueAbsences : ContentPage
	{
		String dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GestionAbsences.db3");
		List<Absence> Abs;
		public HistoriqueAbsences ()
		{
			Abs = new List<Absence>();
			InitializeComponent ();
		}

		public void chargerData()
		{
			var db = new SQLiteConnection(dbPath);
			HistoriqueAbs.ItemsSource = db.Table<Absence>().ToList();
		}		
	}
}