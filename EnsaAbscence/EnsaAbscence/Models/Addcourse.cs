using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnsaAbscence.Models
{
   
        public class AddCourse
        {
            [PrimaryKey,AutoIncrement]
            public int id { get; set; }
            public string CoursName { get; set; }
            public string CoursFiliere { get; set; }
            public string CoursAnnee { get; set; }
        }
    
}
