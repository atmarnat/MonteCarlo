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

// 1. Why do we multiply the value from step 5 above by 4?
//    Answer: There is only 1 quadrant calculated with the method, multiplying by 4 helps approximate all 4 quadrants.
// 2. What do you observe in the output when running your program with parameters of increasing size?
//    Answer: The larger the input, the more accurate the results.
// 3. If you run the program multiple times with the same parameter, does the output remain the same? Why or why not?
//    Answer: The output changes, as random values are used.
// 4. Find a parameter that requires multiple seconds of run time.What is that parameter? How accurate is the estimated value of ?
//    Answer: 1,000,000. It is extremely accurate, usually less than 0.000x difference, often much smaller.
// 5. Research one other use of Monte-Carlo methods. Record it in your exercise submission and be prepared to discuss it in class.
//    Another use is in calculating probability. You can randomly generate numbers, apply a constraint to them, and estimate the probability of an event occuring based on these results.

