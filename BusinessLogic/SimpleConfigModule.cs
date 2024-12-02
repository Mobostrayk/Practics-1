using DataAccessLayer;
using Model;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogic>().To<Logic>().InSingletonScope();
            //ENTITY
            Bind<IRepository<Student>>().To<EntityFrameworkRepository<Student>>().InSingletonScope();
            //DAPPER
            //Bind<IRepository<Student>>().To<RepositoryDapper<Student>>().InSingletonScope();
        }
    }
}
