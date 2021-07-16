using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoinChangeProblem
{
    public class VendingMachine
    {

        #region Declarations 
        private int[] coinDenominations;
        public double Change { get; set; }

        int i;

        #endregion

        #region VendingMachine
        public VendingMachine(int[] coins)
        {
            coinDenominations = coins;
        }

        #endregion

        #region CalculateChange
        public List<int> CalculateChange(double purchaseAmount, double tenderAmount)
        {
            var change = new List<int>();
            var changeAmount = tenderAmount - purchaseAmount;
            changeAmount = Math.Round(changeAmount * 100, 2);
            Change = changeAmount;
            var count = 0;
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
            return change;
        }

        #endregion

        #region CountChangePossibilities
        public static int CountChangePossibilities(double purch, double tender, int[] coinDenominations)
        {
            var machine = new VendingMachine(coinDenominations);
            var purchaseAmount = purch; // amount the item cost
            var tenderAmount = tender; // amount the user input for the purchase
            var change = machine.CalculateChange(purchaseAmount, tenderAmount); // expect 65 cents
            //var results = 0;
            List<int> results = new List<int>();
            for (int val = 0; val < change.Count; val++)
            {

                results.Add(change[val]); 
                Console.WriteLine($"Change[{val}] = {change[val]}");                
            }

            return results[0];
        }
        #endregion
    }
}

