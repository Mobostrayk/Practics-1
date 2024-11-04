using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public class Context : DbContext
    {
        public Context() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MobiBobi\Desktop\Bobi\3semestr\Practics-1\DataAccessLayer\Database1.mdf;Integrated Security=True") { }

        public DbSet<Student> Students { get; set; }

    }
}
