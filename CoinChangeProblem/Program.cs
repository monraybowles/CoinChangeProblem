
using System;
using System.Security.Cryptography.X509Certificates;

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
            // get main launcher method and write Console Lines By Currencies
            var vender = new VendingMachine(null);                    
            // pass array data - currency, purchase Amount,  tender Amount
            vender.writeConsoleLinesByCurrencies(vender.getVendingMachineData()); 
        }
       
        #endregion
    }
}
