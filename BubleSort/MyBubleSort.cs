namespace BubleSort
{
    using System;
    using System.Collections.Generic;

    public static class MyBubleSort
    {
        public static void BubleSort<T>(List<T> arr)
            where T: IComparable<T>
        {
            var Slapped = true;
            while (Slapped)
            {
                Slapped = false;
                for (int i = 1; i < arr.Count; i++)
                {
                    if(arr[i].CompareTo(arr[i - 1]) < 0)
                    {
                        Slapp(arr, i, i - 1);
                        Slapped = true;
                    }
                }
            }
        }

        public static void Slapp<T>(List<T> array, int firstindex, int secondindex)
        {
            var element = array[firstindex];
            array[firstindex] = array[secondindex];
            array[secondindex] = element;
        }
    }
}
