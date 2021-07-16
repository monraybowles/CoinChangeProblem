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
            int[] EmptyCoin = null; // 
            int[] coinDenominationsPound = new int[] { 1, 2, 5, 10, 20, 50 }; // coin denominations – US Dollar
            int[] coinDenominationsUSDollar = new int[] { 1, 5, 10, 25 }; // coin denominations – Pound
          
            var purchaseAmount = 1.35; // amount the item cost
            var tenderAmount = 2.00; // amount the user input for the purchase               

            var machine = new VendingMachine(EmptyCoin);
            Console.WriteLine($"--------------------------------------- USD "); // PRINT HEADER # 1
            Console.WriteLine($"  ");           
            machine.writeCalculatedChangeConsoleLines(purchaseAmount, tenderAmount, coinDenominationsUSDollar, "(US Dollar)");
            Console.WriteLine($"  "); 
            Console.WriteLine($"--------------------------------------- POUND "); // PRINT HEADER # 2
            Console.WriteLine($"  ");
            // Loop through data and write lines           
            machine.writeCalculatedChangeConsoleLines(purchaseAmount, tenderAmount, coinDenominationsPound, "(British Pound)");
            Console.ReadLine();
        }
    }
}
