using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace bugrahanDurukan
{
    abstract class CateringAccount : BillkentAccount, AccountViewer, IComparable<CateringAccount>//abstract class
    {
        protected AccountBalance accountBalance = new AccountBalance(0);//has-a relation
        SystemLog<String> syslog = new SystemLog<String>();
        public int logger = 0;
        protected CateringAccount(int accountID, string accountName, CateringSystem.Membership membership): base(accountID, accountName)
        {
            this.membership = membership;
        }

        public CateringSystem.Membership membership { get; set; }

        public int CompareTo([AllowNull] CateringAccount other)
        {
            //return other.accountID;
            CateringAccount ca = other as CateringAccount;
            return this.accountID.CompareTo(ca.accountID);
        }

        public void viewLog()
        {
            Console.WriteLine(accountName + "'s log:\n");
            syslog.viewLog();
        }

        public override string ToString()
        {
            String ret = "AccountName: " + accountName + "\nAccount ID: " + accountID + "\nAccount Balance: " + accountBalance.mealCount + "\nMembership: " + membership + "\n"; ;
            syslog[logger] = ret;
            logger++;
            return ret;
        }

        public abstract Boolean useMeal();
        public abstract void viewAccount();
    }
}
