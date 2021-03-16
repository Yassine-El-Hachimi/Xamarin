using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EnsaAbscence.Models
{
    public class Proffesseur
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Pass { get; set; }
        
    }
}
