using EnsaAbscence.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnsaAbscence.ModelControllers
{
    class controllerEtudiant
    {
        public SQLiteConnection con;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GestionAbsences.db3");
        // creation de la table user
        public controllerEtudiant()
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Etudiants>();
        }

        // pour ajouter ou modifier un proffesseur 
        public int SaveEtudiant(Etudiants Et)
        {
            if (Et.id != 0)
            {
                return con.Update(Et);
            }
            else
            {
                return con.Insert(Et);
            }
        }
       
    }
}
