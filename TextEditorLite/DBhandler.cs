using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorLite
{
    static class DBhandler
    {
        public static async void LoadFromDB(ApplicationContext db)
        {
            try
            {
                await db.TextFiles.LoadAsync();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static async void SaveToDB(ApplicationContext db)
        {
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
