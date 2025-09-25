using System;
namespace ArayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 7;

            int f = 1;
            for (int i = 1; i <= n; i++)
            {
                f *= i;
            }
            Console.WriteLine("La Factorielle de "+n+" est :" + f);
        }
    }
}