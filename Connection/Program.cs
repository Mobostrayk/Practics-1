using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;

namespace Connection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Student> repository =  new EntityFrameworkRepository<Student>();
        }
    }
}
