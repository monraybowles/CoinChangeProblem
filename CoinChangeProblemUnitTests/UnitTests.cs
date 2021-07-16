using System;
using System.Diagnostics.SymbolStore;
using CoinChangeProblem;
using Xunit;

namespace CoinChangeProblemUnitTests
{
    public class UnitTests
    {
        #region Tests

        /// <summary>
        /// Count the change possibilities should return 3.
        /// </summary>
        [Fact]
        public void CountChangePossibilitiesShouldReturn3()
        {
            var purchaseAmount = 1.35; // amount the item cost
            var tenderAmount = 2.00; // tender amount
            int[] coinDenominationsPound = new int[] { 1, 2, 5, 10, 20, 50 };
            Array.Reverse(coinDenominationsPound);// reverse array for pound coins
            Assert.Equal(3, VendingMachine.CountChangePossibilities(purchaseAmount, tenderAmount, coinDenominationsPound));
        }

        /// <summary>
        /// Count the change possibilities should return 4.
        /// </summary>
        [Fact]
        public void CountChangePossibilitiesShouldReturn4()
        {
            var purchaseAmount = 1.35; // amount the item cost
            var tenderAmount = 2.00; // tender amount
            int[] coinDenominationsUSDollar = new int[] { 1, 5,10, 25};           
            Array.Reverse(coinDenominationsUSDollar);// reverse array for US coins
            Assert.Equal(4, VendingMachine.CountChangePossibilities(purchaseAmount, tenderAmount, coinDenominationsUSDollar));
        }

        #endregion
    }
}
