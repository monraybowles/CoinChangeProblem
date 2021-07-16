using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            int[] coinDenominationsPound = new int[] { 1, 2, 5, 10, 20, 50 }; // coin denominations – US Dollar
            int[] coinDenominationsUSDollar = new int[] { 1, 5, 10, 25 }; // coin denominations – Pound

            Array.Reverse(coinDenominationsPound);// reverse array for pound coins
            Array.Reverse(coinDenominationsUSDollar);// reverse array for US coins
            var machineDollar = new VendingMachine(coinDenominationsUSDollar);
            var machinePound = new VendingMachine(coinDenominationsPound);
            var purchaseAmount = 1.35; // amount the item cost
            var tenderAmount = 2.00; // amount the user input for the purchase
            var changeUSD = machineDollar.CalculateChange(purchaseAmount, tenderAmount); // expect 65 cents
            var changePound = machinePound.CalculateChange(purchaseAmount, tenderAmount); // expect 65 cents

            Console.WriteLine($"--------------------------------------------- USD "); // HEADER # 1
            Console.WriteLine($"  ");
            Console.WriteLine($"Total change amount (USD) = {machineDollar.Change}");
            // Loop through data and write lines
            for (int val = 0; val < changeUSD.Count; val++)
            {
                Console.WriteLine($"Change[{val}] = {changeUSD[val]}");
            }
            Console.WriteLine($"  "); 
            Console.WriteLine($"-------------------------------------------- POUND "); // HEADER # 2
            Console.WriteLine($"  ");
            // Loop through data and write lines
            Console.WriteLine($"Total change amount (Pound) = {machinePound.Change}");
            for (int val = 0; val < changePound.Count; val++)
            {
                Console.WriteLine($"Change[{val}] = {changePound[val]}");
            }
            Console.ReadLine();
        }
    }
}
