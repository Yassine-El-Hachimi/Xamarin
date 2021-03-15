using SQLite;
using System;
using EnsaAbscence.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnsaAbscence.ModelControllers
{
    class ControllerCourse
    {
        public SQLiteConnection con;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GestionAbsences.db3");
        // creation de la table user
        public ControllerCourse()
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<AddCourse>();
        }


        public int SaveCourse(AddCourse cr)
        {
            if (cr.id != 0)
            {
                return con.Update(cr);
            }
            else
            {
                return con.Insert(cr);
            }
        }
    }
}
