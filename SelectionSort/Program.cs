namespace SelectionSort 
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = GenerateSequence(100);
            Shuffle(numbers);
            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", CountingsortSort(numbers, 0, 100, x => x)));
        }


        public static List<T> CountingsortSort<T>(List<T> arr, int min, int max, Func<T, int> cmp)
        {
            var result = new List<List<T>>(max - min + 1);

            for (int i = 0; i < result.Capacity; i++)
            {
                result.Add(new List<T>());
            }

            for (int i = 0; i < arr.Count; i++)
            {
                //int index = cmp(arr[i]);
                result[cmp(arr[i]) - min].Add(arr[i]);
            }

            var resultata = new List<T>();
            for (int i = 0; i < result.Count; i++)
            {
                if(result[i].Count > 0)
                {
                    resultata.AddRange(result[i]);
                }
            }

            return resultata;
        }

        public static List<T> MergeSort<T>(List<T> arr)
            where T : IComparable<T>
        {
            if (arr.Count == 1)
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

        public static List<T> QuickSort<T>(List<T> arr)
            where T : IComparable<T>
        {
            if (arr.Count <= 1)
            {
                return arr;
            }

            if (arr.Count < 20)
            {
                return InsertionSort(arr);
            }

            var pivot = GetPivot(arr, 0, arr.Count / 2, arr.Count - 1);
            int pivotindex = 0;
            if (arr[arr.Count / 2].CompareTo(pivot) == 0)
            {
                pivotindex = arr.Count / 2;
            }
            else if (arr[arr.Count - 1].CompareTo(pivot) == 0)
            {
                pivotindex = arr.Count - 1;
            }

            var left = new List<T>();
            var right = new List<T>();

            for (int i = 0; i < pivotindex; i++)
            {
                if (arr[i].CompareTo(pivot) <= 0)
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
                if (arr[i].CompareTo(pivot) < 0)
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

        public static void BubleSort<T>(List<T> arr)
            where T : IComparable<T>
        {
            var Slapped = true;
            while (Slapped)
            {
                Slapped = false;
                for (int i = 1; i < arr.Count; i++)
                {
                    if (arr[i].CompareTo(arr[i - 1]) < 0)
                    {
                        Slapp(arr, i, i - 1);
                        Slapped = true;
                    }
                }
            }
        }

        public static void MySelectionSort<T>(List<T> arr)
            where T : IComparable<T>
        {
            for (int i = 0; i < arr.Count; i++)
            {
                var element = arr[i];
                int index = 0;
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (element.CompareTo(arr[j]) > 0)
                    {
                        element = arr[j];
                        index = j;
                    }
                }

                if (!element.Equals(arr[i]))
                {
                    Slapp(arr, i, index);
                }
            }
        }

        public static List<int> GenerateSequence(int count)
        {
            var result = new List<int>();
            for (int i = 1; i <= count; i++)
            {
                result.Add(i);
            }

            return result;
        }

        public static void Shuffle<T>(List<T> array)
        {
            var random = new Random();
            for (int i = 0; i < array.Count - 1; i++)
            {
                var randomindex = random.Next(i + 1, array.Count);
                Slapp(array, i, randomindex);
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
