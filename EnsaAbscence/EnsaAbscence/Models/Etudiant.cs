using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnsaAbscence.Models
{
    class Etudiants
    {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string cne { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string numero { get; set; }
        public string filier { get; set; }
        public string Annee { get; set; }
        public int NbrAbsence { get; set; }
        public bool IsAbsent { get; set; }

        public string details
        {
            get { return $"{nom} {prenom}"; }
        }
        public override string ToString()
        {
            return nom + " " + prenom;
        }

    }
}
