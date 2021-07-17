
namespace CoinChangeProblem
{
    /// <summary>
    /// Main class.
    /// </summary>
    class Program
    {
        #region Startup Vending Machine 
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        static void Main()
        {
            const int currencies = 2; // set here to adjust or add a new currency dimension
            const int arrayDimensionSize = 3; // set here to adjust arrays column dimension 
            // get main launcher method write Console Lines By Currencies
            var vender = new VendingMachine(null);
            // currency, purchaseAmount, tenderAmount 2D arrays
            string[,] UserTenderCurrencieAmounts = new string[currencies, arrayDimensionSize] {{ "(USD)", "1.35" , "2.00" },{"(POUND)", "1.35" ,"4.00" } };
            // pass array data - currency, purchase Amount,  tender Amount
            vender.writeConsoleLinesByCurrencies(UserTenderCurrencieAmounts); 
        }
        #endregion
    }
}
