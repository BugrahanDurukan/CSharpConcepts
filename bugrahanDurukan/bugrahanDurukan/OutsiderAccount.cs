using System;
using System.Collections.Generic;
using System.Text;

namespace bugrahanDurukan
{
    //Last sub class in the in the inheritance must be the final class and cannot be extended.
    sealed class OutsiderAccount: CateringAccount //is-a relation
    {
        private readonly int discountMultiplier = 1;

        public OutsiderAccount(int accountID, string accountName, CateringSystem.Membership membership) : base(accountID, accountName, membership) //Call the base class constructor from sub class
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
                accountBalance.addMealCount(in neededMealCount);//in usage
                Console.WriteLine(neededMealCount + " meals were added to " + accountName + "'s account");
                Console.WriteLine(neededMealCount * 12 / discountMultiplier + "TL were taken from " + accountName);
                return true;
            }

        }

        // Override the base class method in the sub class and from the sub class overridden method, call the base class overridden method.
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

        //Implement at least one interface with at least one method.
        public override void viewAccount()
        {
            Console.WriteLine("\nOutsider Account Information\n-------------------\n" + ToString());
        }
    }
}
