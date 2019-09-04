namespace OpenPayApi
{
    public class InstallmentRule
    {
        public float MinPurchasePrice { get; set; }

        public float MaxPurchasePrice { get; set; }

        public string Deposit { get; set; }

        public string Interval { get; set; }

        public string Count { get; set; }

    }
}
