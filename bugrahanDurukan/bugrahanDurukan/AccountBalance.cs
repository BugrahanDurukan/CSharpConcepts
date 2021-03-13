using System;
using System.Collections.Generic;
using System.Text;

namespace bugrahanDurukan
{
    class AccountBalance
    {
        public int mealCount { get; set; }

        public AccountBalance(int mealCount)
        {
            this.mealCount = mealCount;
        }

        public void addMealCount(in int neededMealCount)
        {
            mealCount += neededMealCount;
        }

        public Boolean useMeal()
        {
            if (mealCount <= 0)
            {
                return false;
            }
            else
            {
                mealCount--;
                return true;
            }
        }
    }
}
