using System;
using System.Collections.Generic;
using System.Text;

namespace bugrahanDurukan
{
    abstract class BillkentAccount
    {
        public int accountID { get; }
        public String accountName { get; }

        public BillkentAccount(int accountID, string accountName)
        {
            this.accountID = accountID;
            this.accountName = accountName;
        }

    }
}
