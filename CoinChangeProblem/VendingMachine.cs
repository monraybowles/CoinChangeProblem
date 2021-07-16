using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoinChangeProblem
{
    public class VendingMachine
    {

        #region Declarations 
        private int[] coinDenominations; // Empty array to hold coin denominations values
        public double Change { get; set; } // Set Change amount Total for accessibility

        int i;

        #endregion

        #region Vending Machine
        /// <summary>
        /// Vending Machine Method with coin arrays parameter.. 
        /// </summary>
        /// <param name="coins"></param>
        public VendingMachine(int[] coins)
        {
            coinDenominations = coins; // coins array holder
        }

        #endregion

        #region Calculate Change
        /// <summary>
        /// Calculate Change
        /// </summary>
        /// <param name="purchaseAmount"></param>
        /// <param name="tenderAmount"></param>
        /// <returns></returns>
        public List<int> CalculateChange(double purchaseAmount, double tenderAmount)
        {

           
            var change = new List<int>(); // Create new integer List to hold calculated coin denominations 
            var changeAmount = tenderAmount - purchaseAmount; // subtract amounts
            changeAmount = Math.Round(changeAmount * 100, 2); // round off change amount
            Change = changeAmount; // set Change to re-use in the total in the program start up main
            var count = 0;
            // Iterate through all coin Denominations
            for (i = 0; i < coinDenominations.Length; i++)
            {
                count = (int)changeAmount / coinDenominations[i];
                if (count != 0)
                    for (int x = 0; x < count; x++)
                    {
                        change.Add(coinDenominations[i]);
                    }
                changeAmount %= coinDenominations[i];
            }
            return change; // Return Calculation from Loop
        }

        #endregion

        #region Count Change Possibilities

        /// <summary>
        ///  Unit Test - total count
        /// </summary>      
        /// <param name="tender"></param>
        /// <param name="purch"></param>
        /// <param name="coinDenominations"></param>
        /// <returns></returns>
        public static int CountChangePossibilities(double purch, double tender, int[] coinDenominations)
        {
            var total = 0;  // reset total each time method is called        
            var machine = new VendingMachine(coinDenominations);
            var purchaseAmount = purch; // amount the item cost
            var tenderAmount = tender; // amount the user input for the purchase
            var change = machine.CalculateChange(purchaseAmount, tenderAmount); // expect 65 cents
            List<int> results = new List<int>();
            for (int val = 0; val < change.Count; val++)
            {
                total += 1;                     
            }
            return total; // Return counts for various Unit Test 
        }
        #endregion

        #region write Calculated Change Console Lines
        /// <summary>
        /// Write Calculated Change to Console Lines
        /// </summary>
        /// <param name="purch"></param>
        /// <param name="tender"></param>
        /// <param name="coinDenominations"></param>
        /// <param name="currencyTitle"></param>

        public void writeCalculatedChangeConsoleLines(double purch, double tender, int[] coinDenominations, string currencyTitle)
        {
            Array.Reverse(coinDenominations);// reverse array for pound coins           
           // var machineDollar = new VendingMachine(coinDenominationsUSDollar);
            var machine = new VendingMachine(coinDenominations);
            var purchaseAmount = purch; // amount the item cost
            var tenderAmount = tender; // amount the user input for the purchase
            var change = machine.CalculateChange(purchaseAmount, tenderAmount); // expect 65 cents
            Console.WriteLine($"" + currencyTitle + " Total change amount = " + machine.Change + "");
            // Loop through data and write lines
            for (int val = 0; val < change.Count; val++)
            {
                Console.WriteLine($"Change[{val}] = {change[val]}");// Add the calculated values peer change count
            }
        }
        #endregion

    }
}

