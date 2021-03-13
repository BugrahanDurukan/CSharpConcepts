using System;
using System.Collections.Generic;
using System.Text;

namespace bugrahanDurukan
{
    sealed class SchoolMemberAccount : CateringAccount
    {
        private readonly int discountMultiplier = 2;

        public SchoolMemberAccount(int accountID, string accountName, CateringSystem.Membership membership) : base(accountID, accountName, membership)
        {

        }

        public Boolean purchaseMeals(int neededMealCount)
        {
            if (neededMealCount <= 0)
            {
                Console.WriteLine("No meals were purchased by " + accountName);
                return false;
            }
            else
            {
                accountBalance.addMealCount(in neededMealCount);//Create a method(s) with in parameter
                Console.WriteLine(neededMealCount + " meals were added to " + accountName + "'s account");
                Console.WriteLine(neededMealCount * 12 / discountMultiplier + "TL were taken from " + accountName);
                return true;
            }

        }

        public override Boolean useMeal()
        {
            if (accountBalance.mealCount <= 0)
            {
                Console.WriteLine("Not enough meals in " + accountName + "'s account.");
                return true;
            }
            else
            {
                accountBalance.useMeal();
                Console.WriteLine("A meal were used by " + accountName);
                return false;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void viewAccount()
        {
            Console.WriteLine("\nSchool Member Account Information\n-------------------\n" + ToString());
        }
    }
}
