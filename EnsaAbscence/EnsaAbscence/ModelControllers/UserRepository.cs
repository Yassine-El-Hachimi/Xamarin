using EnsaAbscence.Models;
using SQLite;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnsaAbscence.ModelControllers
{

    public class UserRepository
    {
       public SQLiteConnection con;
       string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GestionAbsences.db3");
        // creation de la table user
        public UserRepository()
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Proffesseur>();
        }

        // methode pour afficher les professeur 
        public List<Proffesseur> GetProffesseurAsync()
        {
            return con.Table<Proffesseur>().ToList();
        }

        // verifier le login d'un utilsateur(prof)
        public  Proffesseur VerfierLog(Proffesseur pr)
        { 
            TableQuery<Proffesseur> tableQuery = con.Table<Proffesseur>();
            Proffesseur prof = tableQuery.Where(i => i.Nom == pr.Nom && i.Pass == pr.Pass).FirstOrDefault();
            if (prof != null)
            {
                return prof;
            }

            return null;
        }

        // pour ajouter ou modifier un proffesseur 
        public int SaveProffesseur(Proffesseur pr)
        {
            if (pr.id != 0){
                return con.Update(pr);
            }
            else{
                return con.Insert(pr);
            }
        }

     
        // pour supprimer un proffesseur

        public int DeleteProffesseur(Proffesseur pr)
        {
            return con.Delete(pr);
        }
    }
}
