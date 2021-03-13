using System;
using System.Collections.Generic;
/*
    Hello Hocam,
    For easy grading I commented every needed item with their promts from the requirement document.
    Hope it ease your job.

    Buğrahan Durukan.
*/
namespace bugrahanDurukan
{
    class Program
    {
        //Create at least one structure and use it in your application.
        //Implement at least one operator overload
        struct MembershipCalculator // struct
        {
            public int currentYear;
            public MembershipCalculator( ref int currentYear)// parameter
            {
                this.currentYear = currentYear;
            }
            public void calculateMembership(out int billkentMembership, CateringAccount cateringAccount) // out parameter
            {
                int yearOfEntrance = CateringSystem.takeNDigits(cateringAccount.accountID, 4);
                billkentMembership = currentYear - yearOfEntrance + 1;
                cateringAccount.membership = (CateringSystem.Membership)billkentMembership;
            }
            public static MembershipCalculator operator --(MembershipCalculator calc) //operator overload
            {
                calc.currentYear--;
                return calc;
            }
            public static MembershipCalculator operator ++(MembershipCalculator calc) //operator overload
            {
                calc.currentYear++;
                return calc;
            }
        }
        static void Main(string[] args)
        {
            int currentYear = 2021;
            List<CateringAccount> eaters;
            List<CateringAccount> randomEaters;
            List<CateringAccount> randomEaters2;

            //Create users
            OutsiderAccount oa1 = new OutsiderAccount(20182020, "Serpil Yüksel", (CateringSystem.Membership)1);
            SchoolMemberAccount oa2 = new SchoolMemberAccount(20185656, "Erinç Yüksel", (CateringSystem.Membership)1);
            OutsiderAccount oa3 = new OutsiderAccount(20192021, "Fatih İzzet Yüksel", (CateringSystem.Membership)1);
            SchoolMemberAccount oa4 = new SchoolMemberAccount(20185666, "Andaç Orta", (CateringSystem.Membership)1);
            SchoolMemberAccount oa5 = new SchoolMemberAccount(20171665, "Janbek Bog", (CateringSystem.Membership)1);

            //purchaseMeal
            oa1.purchaseMeals(5);
            oa2.purchaseMeals(5);

            //useMeal
            oa1.useMeal();
            oa3.useMeal();

            //viewAcc
            oa1.viewAccount();
            oa2.viewAccount();
            oa3.viewAccount();

            //Add to System
            CateringSystem.addEaters(oa5);
            CateringSystem.addEaters(oa4);
            CateringSystem.addEaters(oa3);
            CateringSystem.addEaters(oa2);
            CateringSystem.addEaters(oa1);
            CateringSystem.addEaters(new OutsiderAccount(20202021, "Ömer Durukan", (CateringSystem.Membership)1));
            CateringSystem.addEaters(new OutsiderAccount(20182022, "Emre Erkuş", (CateringSystem.Membership)1));
            CateringSystem.addEaters(new OutsiderAccount(20212023, "Mehmet Ardıç", (CateringSystem.Membership)1));

            //struct used here
            MembershipCalculator mc = new MembershipCalculator( ref currentYear); //ref usage
            mc.calculateMembership(out _, oa1);
            mc++;
            oa1.viewAccount();
            if (mc.currentYear.IsGreaterThan(currentYear))
            {
                Console.WriteLine("Extension method works!");
            }
            mc--;
            oa1.viewAccount();

            //Sorting by ID and returning
            CateringSystem.sortEaters();
            eaters = CateringSystem.getEaters();
            Console.WriteLine("Sorted output before assigning membership\n----------------------------------------");
            foreach (object o in eaters)
            {
                Console.WriteLine(o);
            }

            //assign membership
            CateringAccount[] cateArr = CateringSystem.getEaters().ToArray();
            CateringSystem.assignAllMemberships(cateArr);
            CateringSystem.assignMembership(oa4);

            //Sorting by ID and returning
            CateringSystem.sortEaters();
            eaters = CateringSystem.getEaters();
            Console.WriteLine("Sorted output\n-------------");
            foreach (object o in eaters)
            {
                Console.WriteLine(o);
            }

            //Optional Parameters and named arguments
            randomEaters = CateringSystem.randomSort(firstAccount: oa1, oa2);
            Console.WriteLine("Sorted output from selected values\n------------------------------------");
            foreach (object o in randomEaters)
            {
                Console.WriteLine(o);
            }

            randomEaters2 = CateringSystem.randomSort(oa1, oa2, oa3);
            Console.WriteLine("Sorted output from selected values\n------------------------------------");
            foreach (object o in randomEaters2)
            {
                Console.WriteLine(o);
            }

            oa5.viewLog();

        }
    }
}
