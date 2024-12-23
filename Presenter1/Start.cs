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

            bool isCommandSelected = false;

            while (!isCommandSelected)
            {
                Console.WriteLine("Выберите команду:");
                Console.WriteLine("Введите 'console' для выполнения консольного кода.");
                Console.WriteLine("Введите 'form' для выполнения кода формы.");

                string userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    case "console":
                        var view = new DecanatPro();
                        IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
                        ILogic logic = ninjectKernel.Get<Logic>();
                        new Presenter1(view, logic);
                        StarterСonsole.StartConsole(view);

                        isCommandSelected = true; // После выбора задачи, выходим из цикла
                        break;
                    case "form":
                        Form1 view2 = new Form1();
                        IKernel ninjectKernel2 = new StandardKernel(new SimpleConfigModule());
                        ILogic logic2 = ninjectKernel2.Get<Logic>();
                        new Presenter1(view2, logic2);
                        StarterForm.StartForm(view2);
                        isCommandSelected = true; // После выбора задачи, выходим из цикла
                        break;
                    default:
                        Console.WriteLine("Вы ввели некорректный ввод. Пожалуйста, выберите 'console' или 'form'.");
                        break;
                }
            }
            Console.WriteLine("Программа завершена.");
        }
    }
}
