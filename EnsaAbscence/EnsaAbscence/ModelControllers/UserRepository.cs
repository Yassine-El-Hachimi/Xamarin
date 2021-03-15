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

       

        // verifier le login d'un utilsateur(prof)
        public  Proffesseur VerfierLog(Proffesseur pr)
        { 
            TableQuery<Proffesseur> tableQuery = con.Table<Proffesseur>();
            Proffesseur prof = tableQuery.Where(i => i.Nom == pr.Nom && i.Pass == pr.Pass).FirstOrDefault();

            return prof;
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

     
    }
}
