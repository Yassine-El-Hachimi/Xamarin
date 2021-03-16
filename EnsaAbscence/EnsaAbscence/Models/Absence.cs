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
        public string nom_course { get; set; }
        public string nom_filiere { get; set; }
        public string annee_filiere { get; set; } 
        public DateTime Date { get; set; }
        [TextBlob("studentsBlobbed")]
        public List<Etudiants> students { get; set; }
        public  string ListerAbsences
        {
            get{ return $"{nom_filiere} {nom_course}"; }
        }
    }
}
