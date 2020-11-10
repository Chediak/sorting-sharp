using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Ordem
{
    public class Sort
    {
        static int Partition(int[] arr, int left, int right)
        {
            int pivot;
            pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        static void quickSort(int[] arr, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    quickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    quickSort(arr, pivot + 1, right);
                }
            }
        }

        static int[] InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }

        public static void Method1()
        {
            #region Externo
            Stopwatch externalSw = new Stopwatch();
            externalSw.Start();

            string[] externalNumbers = File.ReadAllText("random.txt").Split(',');
            List<int> externalParsed = new List<int>();

            foreach (var n in externalNumbers)
                externalParsed.Add(Convert.ToInt32(n));

            externalParsed.Sort();

            externalSw.Stop();
            Console.WriteLine($"Método 1 GenericSort (Externo). Tempo: {externalSw.ElapsedMilliseconds}ms");
            #endregion

            #region Interno
            Stopwatch internalSw = new Stopwatch();

            List<int> internalNumbers = new List<int>();

            for (int i = 0; i < 100000; i++)
            {
                internalNumbers.Add(new Random().Next(0, 100000));
            }

            internalSw.Start();
            internalNumbers.Sort();
            internalSw.Stop();

            Console.WriteLine($"Método 1 GenericSort (Interno). Tempo: {internalSw.ElapsedMilliseconds}ms\n");
            #endregion
        }

        public static void Method2()
        {
            #region Externo
            Stopwatch externalSw = new Stopwatch();
            externalSw.Start();

            string[] externalNumbers = File.ReadAllText("random.txt").Split(',');
            List<int> externalParsed = new List<int>();

            foreach (var n in externalNumbers)
                externalParsed.Add(Convert.ToInt32(n));

            quickSort(externalParsed.ToArray(), 0, 9);

            externalSw.Stop();
            Console.WriteLine($"Método 2 Quicksort (Externo). Tempo: {externalSw.ElapsedMilliseconds}ms");
            #endregion

            #region Interno
            Stopwatch internalSw = new Stopwatch();
            List<int> internalNumbers = new List<int>();

            for (int i = 0; i < 100000; i++)
            {
                internalNumbers.Add(new Random().Next(0, 100000));
            }

            internalSw.Start();
            quickSort(internalNumbers.ToArray(), 0, 9);
            internalSw.Stop();

            Console.WriteLine($"Método 2 Quicksort (Interno). Tempo: {internalSw.ElapsedMilliseconds}ms\n");
            #endregion
        }

        public static void Method3()
        {
            #region Externo
            Stopwatch externalSw = new Stopwatch();
            externalSw.Start();

            string[] externalNumbers = File.ReadAllText("random.txt").Split(',');
            List<int> externalParsed = new List<int>();

            foreach (var n in externalNumbers)
                externalParsed.Add(Convert.ToInt32(n));

            InsertionSort(externalParsed.ToArray());

            externalSw.Stop();
            Console.WriteLine($"Método 3 InsertionSort (Externo). Tempo: {externalSw.ElapsedMilliseconds}ms");
            #endregion

            #region Interno
            Stopwatch internalSw = new Stopwatch();

            List<int> internalNumbers = new List<int>();

            for (int i = 0; i < 100000; i++)
            {
                internalNumbers.Add(new Random().Next(0, 100000));
            }

            internalSw.Start();
            InsertionSort(internalNumbers.ToArray());
            internalSw.Stop();
            
            Console.WriteLine($"Método 3 InsertionSort (Interno). Tempo: {internalSw.ElapsedMilliseconds}ms\n");
            #endregion
        }
    }
}
