namespace MergeSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MyMergeSort
    {
        public static List<T> MergeSort<T>(List<T> arr)
            where T : IComparable<T>
        {
            if(arr.Count == 1)
            {
                return arr;
            }

            var middleIndex = arr.Count / 2;
            var left = arr.Take(middleIndex).ToList();
            var right = arr.Skip(middleIndex).ToList();

            left = MergeSort(left);
            right = MergeSort(right);

            var result = Merge(left, right);

            return result;
        }

        public static List<T> Merge<T>(List<T> left, List<T> right)
            where T : IComparable<T>
        {
            int first = 0;
            int second = 0;
            var result = new List<T>();
            while (first < left.Count && second < right.Count)
            {
                if (left[first].CompareTo(right[second]) <= 0)
                {
                    result.Add(left[first]);
                    ++first;
                }
                else
                {
                    result.Add(right[second]);
                    ++second;
                }
            }

            while (first < left.Count)
            {
                result.Add(left[first]);
                ++first;
            }

            while (second < right.Count)
            {
                result.Add(right[second]);
                ++second;
            }

            return result;
        }
    }
}
