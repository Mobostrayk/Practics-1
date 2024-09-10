using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProg
{
    /// <summary>
    /// Уровень представления в консольном приложении
    /// </summary>
    internal class DecanatPro
    {
        static void Main(string[] args)
        {
            
            Logic logic = new Logic();
            Console.WriteLine("1 - Вывести список всех студентов");
            Console.WriteLine("2 - Добавить нового студента");
            Console.WriteLine("3 - Удалить студента");
            Console.WriteLine("4 - Изменить студента");
            Console.WriteLine("5 - Показать статистику по направлениям");
            //Console.WriteLine("6 - Закрыть программу");
            Console.WriteLine("_____________________________________________");
            List<String[]> students = logic.GiveStudents();
            
            // Вечный цикл для вечной работы программы
            while (true)
            {
                string choicestr = Console.ReadLine();
                // Проверяем введенное значение
                int num;
                bool isNum = int.TryParse(choicestr, out num);
                if (isNum)
                {
                    int choice = Convert.ToInt32(choicestr);
                    Console.WriteLine("_____________________________________________");
                    switch (choice)
                    {
                        case 1:
                            //Достаем список из логики и выводим его в консоль
                            students = logic.GiveStudents();
                            int numbers = 0;
                            foreach (String[] student in students)
                            {
                                numbers += 1;
                                Console.Write(numbers + " ");
                                foreach (String student2 in student)
                                {
                                    Console.Write($"{student2} ");
                                }
                                Console.WriteLine("");
                            }
                            Console.WriteLine("_____________________________________________");
                            break;
                        case 2:
                            //Добавляем студента в список
                            Console.WriteLine("Укажите имя студента, затем его специальность и после этого его группу.");
                            Console.Write("Имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Направление: ");
                            string speciality = Console.ReadLine();
                            Console.Write("Группа: ");
                            string group = Console.ReadLine();
                            logic.AddStudent(name, speciality, group);
                            Console.WriteLine("Студент успешно добавлен");
                            break;
                        case 3:
                            //Удаляем студента в список
                            Console.WriteLine("Укажите номер студента, которого вы хотите удалить");
                            int number = Convert.ToInt32(Console.ReadLine());
                            // Проверяем существует ли этот номер
                            if (number <= students.Count && number >= 0)
                                logic.DeleteStudent(students[number - 1][0], students[number - 1][1], students[number - 1][2]);
                            else
                                Console.WriteLine("Введите корректное число -_-");
                            Console.WriteLine("Студент успешно удален");
                            break;
                        case 4:
                            //Изменяем студента
                            Console.WriteLine("Укажите номер студента, которого вы хотите изменить");
                            int number2 = Convert.ToInt32(Console.ReadLine());
                            if (number2 <= students.Count && number2 >= 0)
                                
                            {
                                Console.WriteLine("Укажите новое имя студента, затем его специальность и после этого его группу");
                                Console.Write("Имя: ");
                                string name2 = Console.ReadLine();
                                Console.Write("Направление: ");
                                string speciality2 = Console.ReadLine();
                                Console.Write("Группа: ");
                                string group2 = Console.ReadLine();
                                logic.ChangeStudent(students[number2 - 1][0], students[number2 - 1][1], students[number2 - 1][2], name2, speciality2, group2);
                                Console.WriteLine("Студент успешно изменен");
                            }
                            else
                                Console.WriteLine("Введите корректное число -_-");

                            break;
                        case 5:
                            // Распаковываем и сортируем словарь
                            Dictionary<string, int> SpecialityCount = logic.CreateGystogram();
                            var sortedWords = SpecialityCount.OrderByDescending(keys => keys.Value);
                            foreach (var kases in sortedWords) Console.WriteLine($"{kases.Value} {kases.Key}");
                            Console.WriteLine("_____________________________________________");

                            break;
                        default:
                            Console.WriteLine("Введите корректную команду.");
                            break;
                        //case 6:
                        //    Console.WriteLine("Вы точно в этом уверены???? Нажмите 1, если да.");
                        //    string quit = Console.ReadLine();
                        //    if (quit == "1") Environment.Exit(0);
                        //    else Console.WriteLine("Тогда возвращаемся к нормальной работе программы");
                        //    break;
                    }
                }
                else { Console.WriteLine("Введите пожалуйста число, а не белиберду!!!!!!!!"); }
            }
        }
    }
}