namespace InsertionSort
{
    using System;
    using System.Collections.Generic;

    public class MyInsertionSort
    {
        public static List<T> InsertionSort<T>(List<T> arr)
            where T : IComparable<T>
        {   
            for (int i = 1; i < arr.Count; i++)
            {
                for (int j = i -1; j >= 0; j--)
                {
                    if(arr[i].CompareTo(arr[j]) < 0)
                    {
                        Slapp(arr, i, j);
                    }
                }
            }
            return arr;
        }

        public static void Slapp<T>(List<T> array, int firstindex, int secondindex)
        {
            var element = array[firstindex];
            array[firstindex] = array[secondindex];
            array[secondindex] = element;
        }
    }
}
