using BusinessLogic;
using System;
using Ninject;
using Practics_1;
using Shared;

namespace Presenter
{
    public class Start
    {
        static void Main(string[] args)
        {
            var view = new Form1();
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            ILogic logic = ninjectKernel.Get<Logic>();


            Presenter1 p = new Presenter1(view, logic);
            StarterForm.StartForm(view);
            
            Console.ReadKey();
        }
    }
}
