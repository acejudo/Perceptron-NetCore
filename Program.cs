using System;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomPerceptron.run();
            Console.WriteLine();
            RosenblattPerceptron.run();
        }
    }
}