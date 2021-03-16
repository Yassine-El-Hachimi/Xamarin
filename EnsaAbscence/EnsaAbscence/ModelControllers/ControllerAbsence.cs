using EnsaAbscence.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EnsaAbscence.ModelControllers
{
    class ControllerAbsence
    {
        public SQLiteConnection con;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GestionAbsences.db3");
        // creation de la table user
        public ControllerAbsence()
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Absence>();
        }

      

        public int SaveAbsence(Absence Abs)
        {
            if (Abs.id_absence != 0)
            {
                return con.Update(Abs);
            }
            else
            {
                return con.Insert(Abs);
            }
        }


    }
}
