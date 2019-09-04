using System.Collections.Generic;

namespace OpenPayApi
{
    public static class InstallmentRuleRepo
    {
        public static List<InstallmentRule> GetRules()
        {
            return new List<InstallmentRule>()
            {
                new InstallmentRule()
                {
                     MinPurchasePrice = 0,
                     MaxPurchasePrice = 99,
                     Deposit = Constants.Plan_Not_offered,
                     Interval = Constants.Plan_Not_offered,
                     Count = Constants.Plan_Not_offered

                },
                new InstallmentRule()
                {
                     MinPurchasePrice = 100,
                     MaxPurchasePrice = 999,
                     Deposit = "20",
                     Interval = "15",
                     Count = "5"
                },
                new InstallmentRule()
                {
                     MinPurchasePrice = 1000,
                     MaxPurchasePrice = 9999,
                     Deposit = "25",
                     Interval = "30",
                     Count = "4"
                },
                new InstallmentRule()
                {
                     MinPurchasePrice = 10000,
                     MaxPurchasePrice = 0,
                     Deposit = Constants.Plan_Not_offered,
                     Interval = Constants.Plan_Not_offered,
                     Count = Constants.Plan_Not_offered
                }
            };            
        }
    }
}
