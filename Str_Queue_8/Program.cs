using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Str_Queue_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int userMasN = 0;
            string s;
            StreamReader sr = new StreamReader("C:\\Users\\tjuri\\source\\repos\\Str_Queue_8\\Str_Queue_8\\TextFile1.txt");
            s = sr.ReadLine();
            Console.WriteLine("Выражение:" + s);
            userMasN = s.Length;
            string[] operators = new string[userMasN];
            string[] numbers = new string[userMasN];

            for (int i = 0; i < userMasN; i++)
            {
                int first = 0;
                int second = 0;
                int result = 0;
                if (s[i] == 'M' || s[i] == 'm')
                {
                    AddToStack(operators, s[i].ToString());
                }
                if (Int32.TryParse(s[i].ToString(), out result))
                {
                    AddToStack(numbers, result.ToString());
                }

                if (s[i] == ')')
                {
                    string removeAndInstantAdd = "";
                    string stringToNumber = "";
                    if (!CheckIfStackIsEmpty(operators))
                    {
                        RemoveFromStack(operators, out removeAndInstantAdd);
                        AddToStack(operators, removeAndInstantAdd);

                        if (removeAndInstantAdd[0] == 'M')
                        {
                            RemoveFromStack(operators, out removeAndInstantAdd);
                            RemoveFromStack(numbers, out stringToNumber);
                            first = int.Parse(stringToNumber);
                            RemoveFromStack(numbers, out stringToNumber);
                            second = int.Parse(stringToNumber);

                            if (first > second)
                            {
                                result = first;
                            }
                            else
                            {
                                result = second;
                            }
                            AddToStack(numbers, result.ToString());
                        }

                        if (removeAndInstantAdd[0] == 'm')
                        {
                            RemoveFromStack(operators, out removeAndInstantAdd);
                            RemoveFromStack(numbers, out stringToNumber);
                            first = int.Parse(stringToNumber);
                            RemoveFromStack(numbers, out stringToNumber);
                            second = int.Parse(stringToNumber);

                            if (first < second)
                            {
                                result = first;
                            }
                            else
                            {
                                result = second;
                            }
                            AddToStack(numbers, result.ToString());
                        }
                    }  
                }
            }
            string res ="";
            
            RemoveFromStack(numbers, out res);
            Console.WriteLine("Ответ:" + res);


            void ClearStack(string[] mass)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    mass[i] = null;
                }
            }

            bool CheckIfStackIsEmpty(string[] mass)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                        return false;
                }
                return true;
            }

            void PrintStack(string[] mass)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                    {
                        Console.WriteLine($"Элемент №{i} стека:{mass[i]}");
                    }
                }
            }

            void AddToStack(string[] mass, string str)
            {
                try
                {
                    if (!CheckIfStackIsEmpty(mass))
                    {
                        for (int i = 0; i < mass.Length; i++)
                        {
                            if (mass[i] == null)
                            {
                                mass[i] = str;
                                break;
                            }
                        }
                    }
                    if (CheckIfStackIsEmpty(mass))
                    {
                        /*Console.WriteLine("Стек пуст! На какое место добавить элемент?");
                        int firstIndexOfQueue;
                        while (!(int.TryParse(Console.ReadLine(), out firstIndexOfQueue)) && !(firstIndexOfQueue <= userMasN))
                        {
                            Console.WriteLine("Неверный Ввод индекса элемента! Попробуйте снова:");
                        }
                        mass[firstIndexOfQueue] = str;*/
                        mass[0] = str;
                    }
                }
                catch
                {
                    try
                    {
                        for (int i = 0; i < mass.Length; i++)
                        {
                            if (mass[i] != null)
                            {
                                mass[i - 1] = mass[i];
                                mass[i] = null;
                            }
                        }
                        Console.WriteLine("Стек достиг правого края!\nВсе элементы сдвинуты влево!\nПопробуйте добавить элемент снова!");
                    }
                    catch
                    {
                        Console.WriteLine("ОШИБКА ПЕРЕПОЛНЕНИЯ!");
                    }
                }
            }

            void RemoveFromStack(string[] mass, out string str)
            {
                str = "0";
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                    {
                        str = mass[i];
                        mass[i] = null;
                        break;
                    }
                }
            }
        }
    }
}
