using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CoinChangeProblem
{
    /// <summary>
    /// Main class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        static void Main()
        {


            var change = new List<int>();
            int[] coins = { 25, 10, 5, 1 };
            int amount, count, i;
            Console.Write("Enter the amount you want to change : ");
            amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("==========================");
            for (i = 0; i < coins.Length; i++)
            {
                count = amount / coins[i];
                if (count != 0)
                    for (int x = 0; x < count; x++)
                    {
                        change.Add(coins[i]);
                    }
              
                amount %= coins[i];
            }

            for (int val = 0; val < change.Count; val++)
            {
                Console.WriteLine($"Change[{val}] = {change[val]}");
            }

            Console.ReadLine();
        }
    
    }
}
