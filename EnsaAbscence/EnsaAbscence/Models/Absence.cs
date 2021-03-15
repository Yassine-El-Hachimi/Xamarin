using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnsaAbscence.Models
{
    class Absence
    {
        [PrimaryKey, AutoIncrement]
        public int id_absence{ get; set; }
        public String nom_course { get; set; }
        public String nom_filiere { get; set; }
        public String annee_filiere { get; set; } 
        public DateTime Date_courant { get; set; }    
        [TextBlob("studentsBlobbed")]
        public List<Etudiants> students { get; set; }
        public  string Historique()
        {
            return nom_filiere + " " + nom_course +" "+ annee_filiere+" " + Date_courant;
        }
    }
}
