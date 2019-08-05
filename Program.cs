using System;

namespace MonteCarlo
{
    class Program
    {
        static int getNumber()
        {
            int value = 0;
            bool exit = false;

            do
            {
                string userInput = Console.ReadLine();
                bool check = int.TryParse(userInput, out _);

                if (check == true)
                {
                    value = int.Parse(userInput);
                    if (value > 0)
                    {
                        exit = true;
                    }
                    else
                        Console.WriteLine("Not a valid number, try again: ");
                }
                else
                {
                    Console.Write("Not a number, try again: ");
                }
            } while (exit == false);
            return value;
        }
        static double GetPi(int n)
        {
            Point[] points = new Point[n];
            int counter = 0;

            for (int i = 0; i < points.Length; i++)
            {
                Random r = new Random();
                points[i] = new Point(r);

                if (points[i].Hypotenuse() <= 1.0)
                {
                    counter++;
                }
            }
            double pi = ((double)counter / points.Length) * 4;
            Console.WriteLine(pi);
            return pi;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Monte Carlo Method");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("\nEnter a length: ");
                int n = getNumber();
                Console.Write("Calculated PI is: ");
                double diff = Math.Abs(1 - GetPi(n) / Math.PI);
                Console.WriteLine($"The difference between values is: {diff}");
            }
        }
    }
    public struct Point
    {
        double x;
        double y;

        public Point(double X, double Y)
        {
            x = X;
            y = Y;
        }

        public Point(Random r)
        {
            x = r.NextDouble();
            y = r.NextDouble();
        }
        public double Hypotenuse() => Math.Sqrt(x * x + y * y);
    }
}
