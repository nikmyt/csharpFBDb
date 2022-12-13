using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DB;

namespace WPF
{
    internal class DatabaseLogic
    {
        public static void cleanDb()
        {
            //CLEANING!!!
            using (var db = new myDbContext())
            {
                db.OwnedPets.ExecuteDelete();
            }
        }
    }
}
