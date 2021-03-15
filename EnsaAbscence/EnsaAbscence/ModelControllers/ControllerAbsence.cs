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
        public SQLiteAsyncConnection con;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GestionAbsences.db3");
        // creation de la table user
        public ControllerAbsence()
        {
            con = new SQLiteAsyncConnection(dbPath);
            con.CreateTableAsync<Absence>();
        }

        public  Task SaveAbsence(Absence Abs)
        {
            return con.InsertAsync(Abs);
        }

        
    }
}
