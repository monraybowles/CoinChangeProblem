using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CoinChangeProblem
{
    public class VendingMachine
    {
        #region Static Data Settings
        public static class DataSettings
        {
            const int currencies = 2; // extend your currency array here 
            const int arrayDimensionColumnSize = 3; // extent your array coloumn size here to add an additional dimension
          
            public static string[] currencieTitles = new string[] { "[USD]", "[POUND]" };// add country currencies here 
            public static string[] purchaseAmounts = new string[] { "1.35", "1.35" };// add countries purchase amounts here 
            public static string[] tenderAmounts = new string[] { "2.00", "4.00" };  // add tender amounts here 
            public static string[,] currencyData = new string[currencies, arrayDimensionColumnSize] { { currencieTitles[0], purchaseAmounts[0], tenderAmounts[0] }, { currencieTitles[1], purchaseAmounts[1], tenderAmounts[1] } };

            public static int[] coinDenominations; // coin holder 
            public static int[] coinDenominationsPound = new int[] { 1, 2, 5, 10, 20, 50 }; // coin currencies for Pound 
            public static int[] coinDenominationsUSDollar = new int[] { 1, 5, 10, 25 }; // coin currencies USD
        }

        #endregion

        #region Properties

        public static double Change { get; set; }


        #endregion

        #region Vending Machine
        /// <summary>
        /// Vending Machine Method with coin arrays parameter.. 
        /// </summary>
        /// <param name="coins"></param>
        public VendingMachine(int[] coins)
        {
            DataSettings.coinDenominations = coins; // coins array holder
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
            for (int i = 0; i < DataSettings.coinDenominations.Length; i++)
            {
                count = (int)changeAmount / DataSettings.coinDenominations[i];
                if (count != 0)
                    for (int x = 0; x < count; x++)
                    {
                        change.Add(DataSettings.coinDenominations[i]);
                    }
                changeAmount %= DataSettings.coinDenominations[i];
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
            Console.WriteLine($"" + currencyTitle + " Total change amount = " + Change + "");
            Console.WriteLine($"  "); // add blank line
            // Loop through data and write lines
            for (int val = 0; val < change.Count; val++)
            {
                Console.WriteLine($"Change[{val}] = {change[val]}");// Add the calculated values per change count
            }
        }
        #endregion

        #region write Calculated Change Console Lines By Currencies
        public void writeConsoleLinesByCurrencies(string[,] array2Db)
        {
            int currencyTitle = 0;
            int tenAmount = 1;
            int purAmount = 2;
            int[] CurrencyHolder;


            for (int i = 0; i < array2Db.Rank; i++)
            {
                CurrencyHolder = currencyLookup(i);
                if (CurrencyHolder != null)
                {
                    Console.WriteLine($"--------------------------------------- " + array2Db[i, currencyTitle] + ""); // PRINT HEADER # 1
                    Console.WriteLine($"  ");
                    writeCalculatedChangeConsoleLines(Convert.ToDouble(array2Db[i, tenAmount]), Convert.ToDouble(array2Db[i, purAmount]), CurrencyHolder, array2Db[i, currencyTitle]);
                    Console.WriteLine($"  ");
                }               

            }

        }
        #endregion

        #region Currency Helpers 
        /// <summary>
        /// Currency Helper settings 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int[] currencyLookup(int value)
        {
          
            int[] CoinHolder = null; // empty int array 

            switch (value)
            {
                case 0:
                    // code block
                    CoinHolder = DataSettings.coinDenominationsUSDollar;
                    break;
                case 1:
                    // code block
                    CoinHolder = DataSettings.coinDenominationsPound;
                    break;              
            }
          
            return CoinHolder;
        }

        public string[,] getVendingMachineData()
        {
            // currency, purchaseAmount, tenderAmount 2D arrays
            string[,] UserTenderCurrencieAmounts = DataSettings.currencyData;

            return UserTenderCurrencieAmounts;
        }
        #endregion

    }
}

