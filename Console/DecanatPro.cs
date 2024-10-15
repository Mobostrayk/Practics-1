﻿using BusinessLogic;
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
        /// <summary>
        /// Консольная программа
        /// </summary>
        static void Main(string[] args)
        {
            
            Logic logic = new Logic();
            Console.WriteLine("Список команд");
            List<String[]> students = logic.GiveStudents();
            
            // Вечный цикл для вечной работы программы
            while (true)
            {
                
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("1 - Вывести список всех студентов");
                Console.WriteLine("2 - Добавить нового студента");
                Console.WriteLine("3 - Удалить студента");
                Console.WriteLine("4 - Изменить студента");
                Console.WriteLine("5 - Показать статистику по направлениям");
                Console.WriteLine("_____________________________________________");

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
                            int num2;
                            string num2str = Console.ReadLine();
                            bool isNum2 = int.TryParse(num2str, out num2);
                            if (isNum2)
                            {
                                int number2 = Convert.ToInt32(num2str);
                                // Проверяем существует ли этот номер
                                if (number2 <= students.Count && number2 >= 1)
                                    logic.DeleteStudent(students[number2 - 1][0], students[number2 - 1][1], students[number2 - 1][2]);

                                else Console.WriteLine("Введите корректное число -_-");                               
                                Console.WriteLine("Студент успешно удален");
                            }
                            else  { Console.WriteLine("Введите пожалуйста число, а не белиберду!!!!!!!!"); }

                            break;
                        case 4:
                            //Изменяем студента
                            Console.WriteLine("Укажите номер студента, которого вы хотите изменить");
                            int num3;
                            string num3str = Console.ReadLine();
                            bool isNum3 = int.TryParse(num3str, out num3);
                            if (isNum3)
                            {
                                int number3 = Convert.ToInt32(num3str);
                                if (number3 <= students.Count && number3 >= 1)

                                {
                                    Console.WriteLine("Укажите новое имя студента, затем его специальность и после этого его группу");
                                    Console.Write("Имя: ");
                                    string name2 = Console.ReadLine();

                                    Console.Write("Направление: ");
                                    string speciality2 = Console.ReadLine();

                                    Console.Write("Группа: ");
                                    string group2 = Console.ReadLine();

                                    logic.ChangeStudent(students[number3 - 1][0], students[number3 - 1][1], students[number3 - 1][2], name2, speciality2, group2);
                                    Console.WriteLine("Студент успешно изменен");
                                }
                                else
                                    Console.WriteLine("Введите корректное число -_-");
                            }
                            else { Console.WriteLine("Введите пожалуйста число, а не белиберду!!!!!!!!"); }

                            break;
                        case 5:
                            // Распаковываем и сортируем словарь
                            Console.WriteLine("Кол-во студентов на специальность - специальность");
                            Dictionary<string, int> SpecialityCount = logic.CreateGystogram();
                            var sortedWords = SpecialityCount.OrderByDescending(keys => keys.Value);
                            foreach (var kases in sortedWords) Console.WriteLine($"{kases.Value} - {kases.Key}");
                            Console.WriteLine("_____________________________________________");

                            break;
                        default:
                            Console.WriteLine("Введите корректную команду.");
                            break;
                    }
                }
                else { Console.WriteLine("Введите пожалуйста число, а не белиберду!!!!!!!!"); }
            }
        }
    }
}