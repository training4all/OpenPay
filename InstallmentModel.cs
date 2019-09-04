using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OpenPayApi
{
    public static class InstallmentModel
    {
        public static InstallmentInfo GetInstallment(float purchasePrice, DateTime purchaseDate)
        {
            List<InstallmentRule> rules = InstallmentRuleRepo.GetRules();

            InstallmentRule rule = rules.Where(r => purchasePrice >= r.MinPurchasePrice
                                                                    && (r.MaxPurchasePrice != 0 ? purchasePrice <= r.MaxPurchasePrice : true)).FirstOrDefault();

            return new InstallmentInfo()
            {
                Deposit = GetDeposit(purchasePrice, rule),
                Amount = GetAmount(purchasePrice, rule),
                Dates = GetPaidDates(purchaseDate, rule)
            };
        }

        private static float GetDeposit(float purchasePrice, InstallmentRule rule)
        {
            if (rule.Deposit == Constants.Plan_Not_offered)
                return 0;

            float deposit = float.Parse(rule.Deposit, CultureInfo.InvariantCulture.NumberFormat);

            return (float)Math.Round(purchasePrice * deposit / 100, 2);
        }

        private static float GetAmount(float purchasePrice, InstallmentRule rule)
        {
            if (rule.Count == Constants.Plan_Not_offered)
                return 0;

            float remainingAmount = purchasePrice - GetDeposit(purchasePrice, rule);            
            int count = int.Parse(rule.Count, CultureInfo.InvariantCulture.NumberFormat);
            return (float)Math.Round(remainingAmount / count, 2);
        }

        private static List<string> GetPaidDates(DateTime purchaseDate, InstallmentRule rule)
        {
            List<string> dates = new List<string>();
            double interval;

            if (rule.Count == Constants.Plan_Not_offered)
                return dates;

            int count = int.Parse(rule.Count, CultureInfo.InvariantCulture.NumberFormat);
            DateTime paidDate = purchaseDate;
            for (int counter =0; counter < count; counter++)
            {
                interval = double.Parse(rule.Interval, CultureInfo.InvariantCulture.NumberFormat);
                paidDate = paidDate.AddDays(interval);
                dates.Add(TrimTimePart(paidDate));
            }

            return dates;
        }

        private static string TrimTimePart(DateTime date)
        {
            string dateAndTime = Convert.ToString(date.Date);
            return dateAndTime.Substring(0, dateAndTime.IndexOf(" "));
        }
    }
}
