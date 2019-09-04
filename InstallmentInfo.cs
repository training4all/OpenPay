using System.Collections.Generic;

namespace OpenPayApi
{
    public class InstallmentInfo
    {
        public float Deposit { get; set; }

        public float Amount { get; set; }

        public  List<string> Dates{ get; set; }

    }
}
