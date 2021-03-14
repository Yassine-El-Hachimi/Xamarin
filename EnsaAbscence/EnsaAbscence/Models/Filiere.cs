using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnsaAbscence.Models
{
    public class Filiere
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string NomFiliere { get; set; }
    }
}
