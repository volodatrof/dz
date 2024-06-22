namespace Determining_the_value_of_a_function_at_a_point
{
    using System;

    class LagrangeInterpolation
    {
        public static double Lagrange(double[] x, double[] y, double xToPredict)
        {
            int n = x.Length;
            double result = 0.0;

            for (int i = 0; i < n; i++)
            {
                double term = y[i];
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        term *= (xToPredict - x[j]) / (x[i] - x[j]);
                    }
                }
                result += term;
            }

            return result;
        }

        static void Main()
        {
            double[] x = { 2.10, 2.67, 3.01, 3.82 };
            double[] y = { 122.23, 123.45, 120.02, 119.65 };

            Console.WriteLine("Enter the value of x to predict:");
                double xToPredict = Convert.ToDouble(Console.ReadLine());

            double predictedValue = Lagrange(x, y, xToPredict);
            Console.WriteLine($"The predicted value at x = {xToPredict} is y = {predictedValue:F2}");
        }
    }

}
