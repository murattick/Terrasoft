using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //символы по заданию
            string str = "aaa bbbb cccc";
            Result result  = new Result();
            result.Start(str);
            result.Display();

            //добавляем цикл для ввода пользователем своих символов
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Result resultRead = new Result();
                string readString = Console.ReadLine();

                resultRead.Start(readString);
                resultRead.Display();
                Console.WriteLine();
                Console.WriteLine("Для выхода из цикла нажмите ESC");                   
            }
        }
    }

    public class Result
    {
        //создаем словарь (ключ/значение)
        Dictionary<char, int> rec = new Dictionary<char, int>();

        public void Start(string _str )
        {
            try
            {
                if (_str != null && _str != "")
                {
                    //создам массив символов
                    char[] arr = _str.ToCharArray();

                    //увеличивам значение при каждом совпадении символа на 1
                    foreach (var item in arr)
                    {

                        if (rec.ContainsKey(item))
                        {
                            rec[item] += 1;
                        }
                        //если нет совпадений, то ставим 1
                        else
                        {
                            rec.Add(item, 1);
                        }
                    }
                }
                else
                    Console.WriteLine("Строка должна содеражать минимум 1 букву");
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
         
        }

        public void Display()
        {
            try
            {
                if (rec != null)
                {
                    //определяем максимальное значение
                    var max = rec.Max(v => v.Value);

                    //выводим символ\ы, которые мксимально часто встречаются 
                    foreach (var item in rec.OrderBy(i => i.Value))
                    {
                        if (item.Value.Equals(max))
                        {
                            Console.WriteLine(item.Key);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошибка вывода. Нет символов!");
            }
      
        }
    }
}