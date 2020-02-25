using System;

namespace Perceptron
{
    public static class RandomPerceptron
    {
        public static void run ()
        {
            /*
                E1, E2 inputs
                P1, P2 inputs weights
                U umbral weight
                S output
                f( ) 

                S = f ( E1 * P1 + E2 * P2 + 1 * U )
             */
            Console.WriteLine("Init Random Perceptron");
            int iteration = 0;
            int[,] data = { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
            double[] weights = { GetRandomNumber(-1, 1), GetRandomNumber(-1, 1)}; //Inicia los pesos al azar
            double umbralWeight = GetRandomNumber(-1, 1);
            bool learning = true;
            int output;
            while(learning){
                learning = false;
                iteration++;
                for (int cont = 0; cont <= 3 ; cont++){
                    double outputAux = data[cont, 0] * weights[0] + data[cont,1] * weights[1] + umbralWeight; //Compute the real output
                    if (outputAux > 0) output = 1; else output = 0; // Transform to 0 or 1
                    if(output != data[cont,2]){ // If not match  > random values
                        weights[0] =  GetRandomNumber(-1, 1);
                        weights[1] =  GetRandomNumber(-1, 1);
                        umbralWeight =  GetRandomNumber(-1, 1);
                        learning = true;
                    }
                }
            }

            Console.WriteLine("Iterations: " + iteration.ToString());
            Console.WriteLine("Weight 1: " + weights[0].ToString());
            Console.WriteLine("Weight 2: " + weights[1].ToString());
            Console.WriteLine("Weight 3: " + umbralWeight.ToString());

            checkResults(data, weights, umbralWeight);

            Console.WriteLine("End Random Perceptron");
        }

        public static void checkResults(int[,] data, double[] weights, double umbralWeight ){
            int output = 0;
            for (int cont = 0; cont <= 3; cont++){ // Show the perceptron summary
            double result = data[cont, 0] * weights[0] + data[cont, 1] * weights[1] + umbralWeight;
            if (result > 0) output = 1; else output = 0;
            Console.WriteLine("Inputs: " + data[cont,0].ToString() + " and " + data[cont,1].ToString() + " = " +
            data[cont,2].ToString() + " perceptron: " + output.ToString());
            }
        }

        public static double GetRandomNumber(double minimum, double maximum)
        { 
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}