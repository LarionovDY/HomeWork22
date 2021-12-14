using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork22
{
    class RandomArray
    {
        private int[] Array { get; set; }       //массив случайных чисел
        private int Array_N { get; set; }       //длина массива
        private int RandomMin { get; set; }     //начало диапазона случайных чисел
        private int RandomMax { get; set; }     //конец диапазона случайных чисел
        private int Summ { get; set; }          //сумма всех чисел
        private int Max { get; set; }           //максимальное число в массиве

        public RandomArray(int array_n, int randomMin, int randomMax)
        {
            RandomMin = randomMin;
            RandomMax = randomMax;
            Array_N = array_n;
            Array = RandomFill();
        }
        private int[] RandomFill()          //метод заполняющий массив случайными числами
        {
            int[] array = new int[Array_N];
            Random random = new Random();
            for (int i = 0; i < Array_N; i++)
            {
                array[i] = random.Next(RandomMin, RandomMax);
                Thread.Sleep(10);
            }
            return array;
        }
        public void Print()          //метод выводящий на консоль массив случайных чисел
        {
            foreach (int i in Array)
            {
                Console.Write($"\t{i}");
            }
        }
        public void FindSumm(object a)      //метод подсчитывающий сумму чисел в массиве
        {
            RandomArray random_array = (RandomArray)a;
            int[] array = random_array.Array;
            int S = 0;
            for (int i = 0; i < array.Length; i++)
            {
                S += array[i];
            }
            Summ = S;
            Thread.Sleep(2000);
            Console.WriteLine($"Сумма элементов массива: {Summ}");
        }
        public void FindSumm(Task task, object a)      //метод подсчитывающий сумму чисел в массиве с перегрузкой для задачи продолжения
        {
            RandomArray random_array = (RandomArray)a;
            int[] array = random_array.Array;
            int S = 0;
            for (int i = 0; i < array.Length; i++)
            {
                S += array[i];
            }
            Summ = S;
            Thread.Sleep(2000);
            Console.WriteLine($"Сумма элементов массива: {Summ}");
        }
        public void FindMax(Task task, object a)      //метод для нахождения наибольшего числа в массиве
        {
            RandomArray random_array = (RandomArray)a;
            int[] array = random_array.Array;
            Max = array.Max();
            Thread.Sleep(2000);
            Console.WriteLine($"Наибольший элемент массива: {Max}");
        }
        public void FindMax(object a)            //метод для нахождения наибольшего числа в массиве с перегрузкой для задачи продолжения
        {
            RandomArray random_array = (RandomArray)a;
            int[] array = random_array.Array;
            Max = array.Max();
            Thread.Sleep(2000);
            Console.WriteLine($"Наибольший элемент массива: {Max}");
        }
    }
}
