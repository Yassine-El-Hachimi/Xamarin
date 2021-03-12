using EnsaAbscence.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnsaAbscence.ModelControllers
{

    public class UserRepository
    {
       public  static  SQLiteAsyncConnection con;
        // creation de la table user
        public UserRepository(string dbPath)
        {
            con = new SQLiteAsyncConnection(dbPath);
            con.CreateTableAsync<Proffesseur>();
        }

        // methode pour afficher les professeur 
        public Task<List<Proffesseur>> GetProffesseurAsync()
        {
            return con.Table<Proffesseur>().ToListAsync();
        }
        


        // pour ajouter ou modifier un proffesseur 
        public Task<int> SaveProffesseurAsync(Proffesseur pr)
        {
            if (pr.id != 0){
                return con.UpdateAsync(pr);
            }
            else{
                return con.InsertAsync(pr);
            }
        }

     
        // pour supprimer un proffesseur

        public Task<int> DeleteProffesseurAsync(Proffesseur pr)
        {
            return con.DeleteAsync(pr);
        }
    }
}
