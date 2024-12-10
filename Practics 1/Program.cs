using BusinessLogic;
using Ninject;
using Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practics_1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var kernel = new StandardKernel(new SimpleConfigModule());
            ILogic logic = kernel.Get<ILogic>();
            var view = new Form1();
            var presenter = new Presenter1(view, logic);

            Application.Run((Form)view);
        }
    }
}
