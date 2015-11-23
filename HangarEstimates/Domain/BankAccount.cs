using PropertyChanged;

namespace HangarEstimates.Domain
{
    [ImplementPropertyChanged]
    public class BankAccount
    {
        public string Bank { get; set; }
        public string PaymentAccount { get; set; }
        public string CorrespondentAccount { get; set; }
        public string BIC { get; set; }
    }
}
