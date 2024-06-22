namespace Solve_a_system_of_linear_algebraic_equations_using_simple_iterations
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть кількість змінних: ");
            int n = int.Parse(Console.ReadLine());

            double[,] A = new double[n, n];
            double[] b = new double[n];
            double[] x = new double[n];

            // Введення коефіцієнтів матриці
            Console.WriteLine("Введіть коефіцієнти при змінних для кожного рівняння:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Рівняння {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"a[{i + 1},{j + 1}] = ");
                    A[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // Введення вільних членів
            Console.WriteLine("Введіть вільні члени:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"b[{i + 1}] = ");
                b[i] = double.Parse(Console.ReadLine());
            }

            // Вивід системи рівнянь
            Console.WriteLine("\nСистема рівнянь:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{A[i, j]}*x{j + 1}");
                    if (j < n - 1)
                        Console.Write(" + ");
                }
                Console.WriteLine($" = {b[i]}");
            }

            // Метод простих ітерацій
            double[] prevX = new double[n];
            double epsilon = 1e-6;
            int maxIterations = 1000;
            int iterations = 0;

            while (iterations < maxIterations)
            {
                Array.Copy(x, prevX, n);

                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                            sum += A[i, j] * prevX[j];
                    }
                    x[i] = (b[i] - sum) / A[i, i];
                }

                bool hasConverged = true;
                for (int i = 0; i < n; i++)
                {
                    if (Math.Abs(x[i] - prevX[i]) > epsilon)
                    {
                        hasConverged = false;
                        break;
                    }
                }

                if (hasConverged)
                    break;

                iterations++;
            }
            Console.WriteLine("\nКорені системи рівнянь:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"x{i + 1} = {x[i]:F6}");
            }
            Console.WriteLine($"\nКількість ітерацій: {iterations}");
        }
    }

}
