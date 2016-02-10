using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    static class Sort
    {
        public static int Fragmentation(int[] array, int start, int end)
        {
            int pointer = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    int temp = array[pointer];
                    array[pointer] = array[i];
                    array[i] = temp;
                    pointer += 1;
                }
            }
            return pointer - 1;

        }
        public static void QuickSort(int[] array, int start, int end)
        {            
            if (start >= end)
            {
                return;
            }
            int RefElement = Fragmentation(array, start, end);
            QuickSort(array, start, RefElement - 1);
            QuickSort(array, RefElement + 1, end);            
        }
    }
}

