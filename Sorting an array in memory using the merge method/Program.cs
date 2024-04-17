using System;

class Program
{
    static void Main(string[] args)
    {       
        Console.Write("Введіть кількість елементів масиву: ");
        int n = int.Parse(Console.ReadLine());      
        Console.Write("Введіть мінімальне значення: ");
        int minValue = int.Parse(Console.ReadLine());
        Console.Write("Введіть максимальне значення: ");
        int maxValue = int.Parse(Console.ReadLine());        
        int[] array = GenerateRandomArray(n, minValue, maxValue);       
        Console.WriteLine(" Не посортований масив:");
        PrintArray(array);    
        MergeSort(array, 0, array.Length - 1);     
        Console.WriteLine("\nПосортований масив:");
        PrintArray(array);
    }


    static int[] GenerateRandomArray(int n, int minValue, int maxValue)
    {
        Random random = new Random();
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = random.Next(minValue, maxValue + 1);
        }
        return array;
    }

 
    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

   
    static void Merge(int[] array, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(array, left, L, 0, n1);
        Array.Copy(array, mid + 1, R, 0, n2);

        int i = 0, j = 0;
        int k = left;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                array[k] = L[i];
                i++;
            }
            else
            {
                array[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            array[k] = L[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            array[k] = R[j];
            j++;
            k++;
        }
    }

    static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(array, left, mid);
            MergeSort(array, mid + 1, right);
            Merge(array, left, mid, right);
        }
    }
}
