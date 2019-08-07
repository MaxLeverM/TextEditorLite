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
            await db.TextFiles.LoadAsync();
        }
        public static async void SaveToDB(ApplicationContext db)
        {
            await db.SaveChangesAsync();
        }
    }
}
