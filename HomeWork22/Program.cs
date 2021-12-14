using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork22
{
    //Сформировать массив случайных целых чисел(размер задается пользователем). 
    //Вычислить сумму чисел массива и максимальное число в массиве.
    //Реализовать решение  задачи с  использованием механизма  задач продолжения.
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите размер массива и диапазон случайных значений для его заполнения:");
                int array_n = ReadPosValue("Размер массива:");
                int randomMin = ReadValue("Минимальное значение диапазона:");
                int randomMax = ReadValue("Максимальное значение диапазона:");
                RandomArray array = new RandomArray(array_n, randomMin, randomMax);
                array.Print();
                object _array = array;
                Console.WriteLine();
                Action<object> Action_task1 = new Action<object>(array.FindSumm);
                Task task1 = new Task(Action_task1, _array);
                Action<Task, object> Action_task2 = new Action<Task, object>(array.FindMax);
                Task task2 = task1.ContinueWith(Action_task2, _array);
                task1.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Метод main завершен");
            Console.ReadKey();
        }
        static int ReadPosValue(string text)   //метод проверяющий корректность ввода данных
        {
            int value;
            while (true)
            {
                Console.WriteLine(text);
                if (Int32.TryParse(Console.ReadLine(), out value) && value > 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Ввод некорректен");
                }
            }
        }
        static int ReadValue(string text)   //метод проверяющий корректность ввода данных
        {
            int value;
            while (true)
            {
                Console.WriteLine(text);
                if (Int32.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Ввод некорректен");
                }
            }
        }
    }
   
}
