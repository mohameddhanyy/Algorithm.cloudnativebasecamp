﻿using System.Collections;

namespace Algooo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Insertion Sort 
            int[] arr = { 5, 2, 4, 7, 1, 3, 6, 8, 11, 16, 55 };
            //InsertionSort(arr);
            //foreach (var item in arr)
            //{
            //    Console.Write($"{item} ");
            //}

            //Merge Sort
            //Console.WriteLine("Original array:");
            //Console.WriteLine(string.Join(" ", arr));

            //Call merge sort
            MergeSort(arr);

            // Output sorted array
            //Console.WriteLine("\nSorted array:");
            //Console.WriteLine(string.Join(" ", arr));

            int[] arr2 = { 1, 3, 5, 9, 11, 20, 43, 88, 90 };
            //int result = BinarySearch(arr2, 90, 0, arr.Length - 1);
            int result = BinarySearch(arr2, 99);
            //Console.WriteLine(result);

            // Sergrager Positive and Negative Numbers 
            int[] arr3 = { 5, 2, -11, 1, -1, -6, -4 };
            SegregateRecurtion(arr3);
            //Console.WriteLine(String.Join(",", arr3))
            //
            #region Dynamic Programming
            // just tool to make recursive good more efficient 

            int x = 8;
            int result1 = fibonacci_DP_Memoization(x);
            int result2 = fibonacci_DP_Tabulation(x);
            //Console.WriteLine(result2);
            #endregion


            #region Greedy Algorithms
            ///selecting the best option available at the moment
            ///The algorithm never reverses the earlier decision even if the choice is wrong. It works in a top-down approach
            ///just handle best local 
            ///work if problem has 1=> property is called greedy choice property 
            ///                    2=>If the optimal overall solution to the problem corresponds to the optimal solution to its subproblems
            ///                    

            // Activity Solution Problem

            int[] sessions = new int[6];
            int[] starts = new int[6] { 9, 10, 11, 12, 13, 15 };
            int[] ends = new int[6] { 11, 11, 12, 14, 15, 16 };
            //int[] results = ActivitySelection(starts, ends);
            //Console.WriteLine(String.Join("==", results));


            // Characters Frequency 
            //CharactersFrequency("Hello World");


            // Huffman Coding
            string msg = "The output from Huffman's algorithm can be viewed as a variable length code table for encoding a source symbol. The algorithm derives this table from the estimated probability or frequency of occurrence for each possible value of the source symbol. as in other entropy encoding methods, more common symbols are generally represented using fewer bits than less common symbols. Huffman's method can be efficiently implemented, finding a code in time linear to the number of input weights if these weights are sorted. However, although optimal among methods encoding symbols separately, Huffman coding is not always optimal among all compression methods it is replaced with arithmetic coding or asymmetric numeral systems if better compression ratio is required.";

            Huffman huff = new Huffman(msg);

            //foreach (char k in huff.codes.Keys)
            //{
            //    Console.Write(k + " ");
            //    Console.WriteLine(huff.codes[k]);
            //}



            // Fractional Knapsack Problem
            int[] weight = { 10, 30, 20, 50 };
            int[] value = { 40, 30, 80, 70 };
            int capacity = 60;

            Console.WriteLine("Maximum value that " + "can be obtained is " + getMax(weight, value, capacity));

            #endregion

        }

        static int[] InsertionSort(int[] arr)
        {
            int i, j;
            for (i = 0; i < arr.Length; i++)
            {
                int key = arr[i];
                for (j = i - 1; j >= 0; --j)
                {
                    if (arr[j] > key)
                    {
                        arr[j + 1] = arr[j];
                    }
                    else
                    {
                        break;
                    }
                }
                arr[j + 1] = key;
            }
            return arr;
        }

        //public static void MergeSort(int[] arr)
        //{
        //    if (arr.Length <= 1)
        //        return;

        //    // Find the middle point to divide the array into two halves
        //    int mid = arr.Length / 2;

        //    // Create temporary arrays for left and right subarrays
        //    int[] leftHalf = new int[mid];
        //    int[] rightHalf = new int[arr.Length - mid];

        //    // Copy data to temp arrays
        //    Array.Copy(arr, 0, leftHalf, 0, mid);
        //    Array.Copy(arr, mid, rightHalf, 0, arr.Length - mid);

        //    // Recursively sort the halves
        //    MergeSort(leftHalf);
        //    MergeSort(rightHalf);

        //    // Merge the sorted halves back into the original array
        //    Merge(arr, leftHalf, rightHalf);
        //}

        // Merge function to merge two sorted subarrays
        //private static void Merge(int[] arr, int[] leftHalf, int[] rightHalf)
        //{
        //    int i = 0, j = 0, k = 0;

        //    // Traverse both arrays and insert smaller element from left or right subarray into original array
        //    while (i < leftHalf.Length && j < rightHalf.Length)
        //    {
        //        if (leftHalf[i] <= rightHalf[j])
        //        {
        //            arr[k] = leftHalf[i];
        //            i++;
        //        }
        //        else
        //        {
        //            arr[k] = rightHalf[j];
        //            j++;
        //        }
        //        k++;
        //    }

        //    // Copy remaining elements of leftHalf, if any
        //    while (i < leftHalf.Length)
        //    {
        //        arr[k] = leftHalf[i];
        //        i++;
        //        k++;
        //    }

        //    // Copy remaining elements of rightHalf, if any
        //    while (j < rightHalf.Length)
        //    {
        //        arr[k] = rightHalf[j];
        //        j++;
        //        k++;
        //    }
        //}


        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
                return;
            int mid = arr.Length / 2;
            int[] leftArray = new int[mid];
            int[] rightArray = new int[arr.Length - mid];

            Array.Copy(arr, 0, leftArray, 0, mid);
            Array.Copy(arr, mid, rightArray, 0, arr.Length - mid);

            MergeSort(leftArray);
            MergeSort(rightArray);
            Merge(arr, leftArray, rightArray);
        }

        private static void Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < left.Length)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                arr[k] = right[j];
                j++;
                k++;
            }

        }

        //private static int BinarySearch(int[] arr , int key , int low , int high)
        //{
        //    int mid = (low + high)/2;
        //    if (arr[mid] == key)
        //        return mid;
        //    else if (arr[mid] > key)
        //        return BinarySearch(arr, key, low, mid - 1);
        //    else 
        //        return BinarySearch(arr, key, mid + 1, arr.Length - 1);
        //}

        private static int BinarySearch(int[] arr, int key)
        {
            int low = 0;
            int high = arr.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == key)
                    return mid;
                else if (arr[mid] < key)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return -1;
        }

        private static int[] SegragetePN(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key;
                if (arr[i] > 0)
                    continue;
                if (arr[i] < 0)
                {
                    key = arr[i];
                    int j;
                    for (j = i - 1; j >= 0; j--)
                    {
                        if (arr[j] > 0)
                            arr[j + 1] = arr[j];
                        else
                            break;
                    }
                    arr[j + 1] = key;
                }
            }
            return arr;
        }


        private static void SegregateRecurtion(int[] arr)
        {
            if (arr.Length <= 1)
                return;
            int mid = arr.Length / 2;
            int[] leftArr = new int[mid];
            int[] rightArr = new int[arr.Length - mid];

            Array.Copy(arr, 0, leftArr, 0, mid);
            Array.Copy(arr, mid, rightArr, 0, arr.Length - mid);

            SegregateRecurtion(leftArr);
            SegregateRecurtion(leftArr);
            SegregateRecurtion(leftArr);
            SegregateRecurtion(rightArr);
            Segregate(arr, leftArr, rightArr);
        }

        private static void Segregate(int[] arr, int[] left, int[] right)
        {
            int k = 0;
            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] < 0)
                {
                    arr[k] = left[i];
                    k++;
                }
            }


            for (int j = 0; j < right.Length; j++)
            {
                if (right[j] < 0)
                {
                    arr[k] = right[j];
                    k++;
                }
            }

            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] > 0)
                {
                    arr[k] = left[i];
                    k++;
                }
            }

            for (int j = 0; j < right.Length; j++)
            {
                if (right[j] > 0)
                {
                    arr[k] = right[j];
                    k++;
                }

            }

        }


        #region Dynamic Programming

        // Dynamic Programming using Memoizatoin(From Top to Down) to Efficint Recursion
        public static int[] memo = new int[100];
        public static int fibonacci_DP_Memoization(int x)
        {
            if (x <= 1) return x;
            if (memo[x] != 0)
                return memo[x];
            memo[x] = fibonacci_DP_Memoization(x - 1) + fibonacci_DP_Memoization(x - 2);
            return memo[x];
        }

        // Dynamic Programming using Tabulation or Bottom's up to Efficient Recursion

        public static int fibonacci_DP_Tabulation(int x)
        {
            memo[0] = 0;
            memo[1] = 1;
            for (int i = 2; i <= x; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2];
            }
            return memo[x];
        }


        #endregion


        #region Greedy Algorithm
        //Activity Solution Problem
        public static int[] ActivitySelection(int[] starts, int[] ends)
        {
            int[] results = new int[starts.Length];
            results[0] = starts[0];
            int length = ends.Length;
            int j = 0, i = 1;
            for (; i < length; i++)
            {
                if (starts[i] >= ends[j])
                {
                    results[i] = starts[i];
                    j = i;
                }
            }
            return results;
        }


        public static void CharactersFrequency(string message)
        {
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < message.Length; i++)
            {
                if (hashtable[message[i]] == null)
                {
                    hashtable[message[i]] = 1;
                }
                else
                {
                    hashtable[message[i]] = (int)hashtable[message[i]] + 1;
                }
            }

            foreach (char item in hashtable.Keys)
            {
                Console.WriteLine($"{item} , {hashtable[item]}");
            }
        }

        //Fractional Knapsack Problem
        static double getMax(int[] weight, int[] value, int capacity)
        {

            int n = weight.Length;

            Item[] list = new Item[n];

            for (int i = 0; i < n; i++)
            {
                list[i] = new Item(weight[i], value[i]);
            }

            Array.Sort(list, new myComparator());

            double ans = 0;

            for (int i = 0; i < n; i++)
            {
                int wt = list[i].weight;
                int val = list[i].value;
                double valuePerUnitWeight = list[i].valuePerUnitWeight;
                if (capacity >= wt)
                {
                    ans += val;
                    capacity -= wt;
                }
                else
                {
                    ans += valuePerUnitWeight * capacity;
                    capacity = 0;
                    break;
                }
            }
            return ans;
        }
        #endregion
    }
}

class Item
{
    public int weight, value;
    public double valuePerUnitWeight;

    public Item(int weight, int value)
    {
        this.weight = weight;
        this.value = value;
        valuePerUnitWeight = (double)(value) / (weight);
    }
}
class myComparator : IComparer
{
    public int Compare(Object ob1, Object ob2)
    {
        Item i1 = (Item)(ob1);
        Item i2 = (Item)(ob2);

        if (i1.valuePerUnitWeight < i2.valuePerUnitWeight)
            return 1;
        return -1;
    }
}
