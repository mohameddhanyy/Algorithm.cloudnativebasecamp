namespace Algooo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Insertion Sort 
            int[] arr = { 5, 2, 4, 7, 1, 3, 6, 8 };
            //InsertionSort(arr);
            //foreach (var item in arr)
            //{
            //    Console.Write($"{item} ");
            //}

            //Merge Sort
            Console.WriteLine("Original array:");
            Console.WriteLine(string.Join(" ", arr));

            //Call merge sort
            MergeSort(arr);

            // Output sorted array
            Console.WriteLine("\nSorted array:");
            Console.WriteLine(string.Join(" ", arr));

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
    }
}
