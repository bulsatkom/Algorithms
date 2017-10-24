namespace BinarySearch
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var list = new List<int> { 1, 1, 1, 1, 1, 1, 1 };
            Console.WriteLine(BinarySearchFirst(list,1));
            Console.WriteLine(BinarySearchLast(list,1));
        }

        public static int BinarySearchFirst<T>(List<T> arr, T value)
            where T : IComparable<T>
        {
            int left = 0;
            int right = arr.Count;
            int middle = (left + right) / 2;


            while (left < right)
            {
                 middle = (left + right) / 2;

                if (arr[middle].CompareTo(value) < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            if (!arr[middle].Equals(value))
            {
                return -1;
            }

            return middle;
        }

        public static int BinarySearchLast<T>(List<T> arr, T value)
            where T : IComparable<T>
        {
            int left = 0;
            int right = arr.Count;
            int middle = (left + right) / 2;


            while (left < right)
            {
                middle = (left + right) / 2;

                if (arr[middle].CompareTo(value) <= 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            if (!arr[middle].Equals(value))
            {
                return -1;
            }

            return middle;
        }
    }
}
