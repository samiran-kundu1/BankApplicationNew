using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Helpers
{
    public class Constants
    {
        #region Public Fields

         public static decimal maxAmountAllowed = 10000.00M;

         public static decimal minAmountAllowed = 100.00M;

        #endregion

        #region Enums
        public enum DepositCodes
        {
            ok = 1,
            invalidAmount = -1,
        }

        public enum WithdrawCodes
        {
            ok = 1,
            amountGreaterThanAccountBalance = -1,
            moreThan90Percent = -2,
            depositLeftWithLessThan100 = -3
        }
        #endregion
    }
}
