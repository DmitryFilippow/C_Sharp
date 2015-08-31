using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheatsDBSQL
{
    public class GCDBContext:DbContext
    {
        public static string ConStr = "";//@"Data Source=DEMON\SQLEXPRESS;Initial Catalog=GCDB;Integrated Security=True";
        public virtual DbSet<Cheat> Cheats { get; set; }

        public GCDBContext(string conStr):base(conStr){}
        public GCDBContext():base(ConStr){}
    }
}
