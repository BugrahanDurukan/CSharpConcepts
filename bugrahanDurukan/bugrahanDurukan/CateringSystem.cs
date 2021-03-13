using System;
using System.Collections.Generic;
using System.Text;

namespace bugrahanDurukan
{
    //Static class
    static class CateringSystem
    {
        //Use at least one generic collection and display the sorted output
        private static List<CateringAccount> eaters;
        private static int currentYear = 2021;

        //Create at least one enum and use it in your application.
        public enum Membership
        {
            FirstYear = 1,
            SecondYear = 2,
            ThirdYear = 3,
            FourthYear = 4,
            Terminated = 5,
        }

        //Create a static class with static constructor. This static constructor can be used to add objects to the collection
        static CateringSystem()
        {
            eaters = new List<CateringAccount>();
            Console.WriteLine("Welcome to Billkent Catering\n");
        }

        public static void addEaters(CateringAccount ca)
        {
            eaters.Add(ca);
        }

        public static List<CateringAccount> getEaters()
        {
            return eaters;
        }

        public static void sortEaters()
        {
            eaters.Sort();
        }

        //Create a method(s) so that it can be called with variable length of parameters
        public static void assignAllMemberships(params CateringAccount[] staff) // variable length parameters
        {
            //Create an use tuples
            foreach (CateringAccount caterAcc in staff)
            {
                var membershipTypes = (FirstYear: 1, SecondYear: 2, ThirdYear: 3, FourthYear: 4, Terminated: 5);//enum tuples
                int yearOfEntrance = takeNDigits(caterAcc.accountID, 4);
                int yearsInBillkent = currentYear - yearOfEntrance + 1;
                switch (yearsInBillkent)
                {
                    case 1:
                        caterAcc.membership = (Membership)membershipTypes.Item1;
                        break;
                    case 2:
                        caterAcc.membership = (Membership)membershipTypes.Item2;
                        break;
                    case 3:
                        caterAcc.membership = (Membership)membershipTypes.Item3;
                        break;
                    case 4:
                        caterAcc.membership = (Membership)membershipTypes.Item4;
                        break;
                    case 5:
                        caterAcc.membership = (Membership)membershipTypes.Item5;
                        break;
                }
            }
        }

        public static int takeNDigits(int number, int N)
        {
            // this is for handling negative numbers, we are only insterested in postitve number
            number = Math.Abs(number);
            // special case for 0 as Log of 0 would be infinity
            if (number == 0)
                return number;
            // getting number of digits on this input number
            int numberOfDigits = (int)Math.Floor(Math.Log10(number) + 1);
            // check if input number has more digits than the required get first N digits
            if (numberOfDigits >= N)
                return (int)Math.Truncate((number / Math.Pow(10, numberOfDigits - N)));
            else
                return number;
        }

        //Tuples
        public static void assignMembership(CateringAccount account)
        {
            var membershipTypes = (FirstYear: 1, SecondYear: 2, ThirdYear: 3, FourthYear: 4, Terminated: 5);//enum tuples
            int yearOfEntrance = takeNDigits(account.accountID, 4);
            int yearsInBillkent = currentYear - yearOfEntrance + 1;
            switch (yearsInBillkent)
            {
                case 1:
                    account.membership = (Membership)membershipTypes.Item1;
                    break;
                case 2:
                    account.membership = (Membership)membershipTypes.Item2;
                    break;
                case 3:
                    account.membership = (Membership)membershipTypes.Item3;
                    break;
                case 4:
                    account.membership = (Membership)membershipTypes.Item4;
                    break;
                case 5:
                    account.membership = (Membership)membershipTypes.Item5;
                    break;

            }
        }

        //Implement at least one method which has optional parameters
        //Call the methods by using the named arguments.
        public static List<CateringAccount> randomSort(CateringAccount firstAccount = null, CateringAccount ca2 = null, CateringAccount ca3 = null, CateringAccount ca4 = null, CateringAccount ca5 = null)//optional parameters
        {
            List<CateringAccount> randomEaters = new List<CateringAccount>();
            if (ca5 != null)
            {
                randomEaters.Add(firstAccount);
                randomEaters.Add(ca2);
                randomEaters.Add(ca3);
                randomEaters.Add(ca4);
                randomEaters.Add(ca5);
                randomEaters.Sort();
                return randomEaters;
            }else if (ca5 == null)
            {
                randomEaters.Add(firstAccount);
                randomEaters.Add(ca2);
                randomEaters.Add(ca3);
                randomEaters.Add(ca4);
                randomEaters.Sort();
                return randomEaters;
            }else if(ca4 == null)
            {
                randomEaters.Add(firstAccount);
                randomEaters.Add(ca2);
                randomEaters.Add(ca3);
                randomEaters.Sort();
                return randomEaters;
            }else if (ca3 == null)
            {
                randomEaters.Add(firstAccount);
                randomEaters.Add(ca2);
                randomEaters.Sort();
                return randomEaters;
            }else if(ca2 == null)
            {
                randomEaters.Add(firstAccount);
                return randomEaters;
            }
            else
            {
                return null;
            }
        }

    }
}
