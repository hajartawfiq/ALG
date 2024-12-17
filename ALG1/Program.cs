using System;

namespace Counting_Sort
{
    internal class Program
    {
        // Counting Sort function
        static void CountingSort(int[] arr)
        {
            // Step 1: Find the maximum value in the array
            int maxValue = 0;
            foreach (int num in arr)
            {
                if (num > maxValue)
                    maxValue = num;
            }

            // Step 2: Initialize the count array
            int[] count = new int[maxValue + 1];

            // Step 3: Count occurrences of each number
            foreach (int num in arr)
            {
                count[num]++;
            }

            // Step 4: Reconstruct the sorted array
            int index = 0;
            for (int num = 0; num < count.Length; num++)
            {
                while (count[num] > 0)
                {
                    arr[index] = num;
                    index++;
                    count[num]--;
                }
            }
        }

        static void Main(string[] args)
        {
            // Example usage
            int[] arr = { 4, 2, 2, 8, 3, 3, 1 };

            Console.WriteLine("Unsorted: " + string.Join(", ", arr));
            CountingSort(arr);
            Console.WriteLine("Sorted: " + string.Join(", ", arr));
            Console.ReadLine();
        }
    }
}

