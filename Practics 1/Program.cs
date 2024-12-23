using Ninject;
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
            var view = new Form1();
            

            Application.Run((Form)view);
        }
    }
    public static class StarterForm
    {
        /// <summary>
        /// Стартер для формы
        /// </summary>
        /// <param name="form"> ВинФорма </param>
        public static void StartForm(Form1 form)
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(form);
        }
    }
}
