namespace QuickSort
{
    using System;
    using System.Collections.Generic;

    public class MyQuickSort

    {
        public static List<T> QuickSort<T>(List<T> arr)
            where T : IComparable<T>
        {

            if (arr.Count <= 1)
            {
                return arr;
            }

            if(arr.Count < 25)
            {
                return InsertionSort(arr);
            }

            var pivot = GetPivot(arr, 0, arr.Count / 2, arr.Count - 1);
            int pivotindex = 0;
            if(arr[arr.Count / 2].CompareTo(pivot) == 0)
            {
                pivotindex = arr.Count / 2;
            }
            else if(arr[arr.Count -1].CompareTo(pivot) == 0)
            {
                pivotindex = arr.Count - 1;
            }

            var left = new List<T>();
            var right = new List<T>();

            for (int i = 0; i < pivotindex; i++)
            {
                if(arr[i].CompareTo(pivot) <= 0)
                {
                    left.Add(arr[i]);
                }
                else
                {
                    right.Add(arr[i]);
                }
            }

            for (int i = pivotindex + 1; i < arr.Count; i++)
            {
                if(arr[i].CompareTo(pivot) < 0)
                {
                    left.Add(arr[i]);
                }
                else
                {
                    right.Add(arr[i]);
                }
            }

            left = QuickSort(left);
            right = QuickSort(right);

            var result = new List<T>();

            result.AddRange(left);
            result.Add(pivot);
            result.AddRange(right);

            return result;
        }

        public static List<T> InsertionSort<T>(List<T> arr)
            where T : IComparable<T>
        {
            for (int i = 1; i < arr.Count; i++)
            {
                var item = arr[i];
                var index = i;
                while (index > 0 && item.CompareTo(arr[index - 1]) < 0)
                {
                    --index;
                    Slapp(arr, index + 1, index);
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

        public static T GetPivot<T>(List<T> arr, int firstIndex, int secondIndex, int thirdIndex)
            where T : IComparable<T>
        {
            if (arr[firstIndex].CompareTo(arr[secondIndex]) <= 0 && arr[secondIndex].CompareTo(arr[thirdIndex]) <= 0)
            {
                return arr[secondIndex];
            }
            else if (arr[secondIndex].CompareTo(arr[firstIndex]) <= 0 && arr[firstIndex].CompareTo(arr[thirdIndex]) <= 0)
            {
                return arr[firstIndex];
            }
            else
            {
                return arr[thirdIndex];
            }
        }
    }
}
