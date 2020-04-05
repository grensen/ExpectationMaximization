using System;

namespace ExpectationMaximization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nBegin expectation maximization coin flip demo\n");
           // Console.WriteLine("Parameter estimation for complete and incomplete data");
            Console.WriteLine("Given a set of 10 coin tosses from coin A and coin B");

            Console.WriteLine("\na) Maximum likelihood");
            Console.WriteLine("                           Coin A    Coin B");
            Console.WriteLine("B: H T T T H H T H T H               5H, 5T");
            Console.WriteLine("A: H H H H T H H H H H     9H, 1T");
            Console.WriteLine("A: H T H H H H H T H H     8H, 2T");
            Console.WriteLine("B: H T H T T T H H T T               4H, 6T");
            Console.WriteLine("A: T H H H T H H H T H     7H, 3T");
            Console.WriteLine("                           ======    ======");
            Console.WriteLine("                          24H, 6T    9H,11T");
            Console.WriteLine("\nGoal is to find MLE of:");
            Console.WriteLine("thetaA = 24 / (24 + 6) = 0.80");
            Console.WriteLine("thetaB =  9 / (9 + 11) = 0.45");

            Console.WriteLine("\nb) Expectation maximization");
            Console.WriteLine("\nEM starts with an initial guess of the parameters: ");
            Console.WriteLine("thetaA = 0.6 and thetaB = 0.5");
           
            // 1. start with an initial guess of the parameters
            double thetaA = 0.6, thetaB = 0.5;
            int N = 10; // tosses
            int[] heads = { 5, 9, 8, 4, 7 };

            Console.WriteLine("\nE-step    Prop A  Prob B     Coin A         Coin B");
            for (int x = 0; x < 10; x++)// loop 10 times till converge
            {
                double headsA = 0, tailsA = 0, headsB = 0, tailsB = 0;
                // 2. E-Step
                for (int i = 0; i < heads.Length; i++)
                {
                    int head = heads[i], tail = N - head;
                    // compute likelihood using binomial distribution
                    double lbA = Math.Pow(thetaA, head) * Math.Pow((1.0 - thetaA), N - head);
                    double lbB = Math.Pow(thetaB, head) * Math.Pow((1.0 - thetaB), N - head);

                    // normalize by using A/A+B
                    double probA = lbA / (lbA + lbB);
                    double probB = lbB / (lbA + lbB);

                    // accumulate estimated tosses
                    headsA += head * probA;
                    headsB += head * probB;
                    tailsA += tail * probA;
                    tailsB += tail * probB;

                    if (x == 0) Console.WriteLine(i + 
                        "         " + probA.ToString("F2") + "    " + probB.ToString("F2") + // prob
                        "       " + (head * probA).ToString("F2") + "  " + (tail * probA).ToString("F2") + // A
                        "     " + (head * probB).ToString("F2") + "  " + (tail * probB).ToString("F2")); // B
                }
                if (x == 0) Console.WriteLine("                             ==========     ==========");
                if (x == 0) Console.WriteLine("\t\t\t    " + headsA.ToString("F2") +  "  " + tailsA.ToString("F2") +"    " + headsB.ToString("F2") +  "  " + tailsB.ToString("F2"));

                // 3. M-Step, normalize 
                thetaA = headsA / (headsA + tailsA);
                thetaB = headsB / (headsB + tailsB);
                if (x == 0) Console.WriteLine("\nM-step " + x + ": thetaA = " + thetaA.ToString("F2") + " and thetaB = " + thetaB.ToString("F2"));
            }
            // 4. after several repetitions of the E-step and M-step, the algorithm converges
            Console.WriteLine("\nExpactation maximization after ten M-steps");
            Console.WriteLine("Prediction from EM: thetaA = " + thetaA.ToString("F2") + " and thetaB = " + thetaB.ToString("F2"));
            Console.WriteLine("Target from MLE:    thetaA = 0.80 and thetaB = 0.45");

            Console.WriteLine("\nDemo end");
            Console.ReadLine();
        } // main
    } // class
} // ns
