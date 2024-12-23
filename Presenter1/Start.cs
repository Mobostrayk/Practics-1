using System;
using BusinessLogic;
using Ninject;
using Practics_1;
using Shared;
using ConsoleProg;


namespace Presenter1
{
    internal class Start
    {
        static void Main(string[] args)
        {
            //ВинФорма
            //Form1 view = new Form1();
            //IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            //ILogic logic = ninjectKernel.Get<Logic>();

            //Консоль
            var view = new DecanatPro();
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            ILogic logic = ninjectKernel.Get<Logic>();


            new Presenter1(view, logic);

            //ВинФорма
            //StarterForm.StartForm(view);

            //Консоль
            StarterСonsole.StartConsole(view);


            Console.ReadKey();
        }
    }
}
