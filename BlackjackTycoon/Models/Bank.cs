using System.Collections.Generic;

namespace BlackjackTycoon.Models
{
    public class Bank
    {
        // These are the default loan options.
        private static readonly List<decimal> DefaultLoanOptions = new List<decimal> {50.00m, 100.00m, 500.00m, 1000.00m};
        public string Name { get; set; }
        public List<decimal> LoanOptions { get; set; }       
        public decimal Reimbursement { get; set; }

        public Bank(string name, List<decimal> loanOptions=null) // If you want to customize loan options, do it here.
        {
            Name = name;
            if (loanOptions is null) // If not customized, do the default loan options.
            {
                LoanOptions = DefaultLoanOptions;
            }
        }
    }
}
