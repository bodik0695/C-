using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthArr;
            Console.Write("Введите длину массива: ");
            string readLengthArr = Console.ReadLine();
            if (Int32.TryParse(readLengthArr, out lengthArr))
            {
                int[] array = new int[lengthArr];
                Random rand = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rand.Next(1, 100);
                    Console.WriteLine(array[i]);
                }
                Sort.QuickSort(array, 0, array.Length - 1);
                Console.WriteLine("Отсортированный масив: ");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не цифру");
            }            
        }
    }
}
