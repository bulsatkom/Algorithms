namespace CountingSort
{
    using System;
    using System.Collections.Generic;

    public class MyCountingSort
    {
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
                if (result[i].Count > 0)
                {
                    resultata.AddRange(result[i]);
                }
            }

            return resultata;
        }
    }
}
