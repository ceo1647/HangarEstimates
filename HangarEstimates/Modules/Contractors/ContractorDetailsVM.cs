using System.Collections.ObjectModel;
using HangarEstimates.Bll;

namespace HangarEstimates.Modules.Contractors
{
    public class ContractorDetailsVM
    {
        public Client Model { get; private set; }

        public ContractorDetailsVM(Client client)
        {
            Model = client;
            Contacts = new ObservableCollection<Contact>(client.Contacts);
            BankAccounts = new ObservableCollection<BankAccount>(client.BankAccounts);
         //   Contacts.CollectionChanged += Contacts_CollectionChanged;
        }
        
        public ObservableCollection<Contact> Contacts { get; set; }
        public ObservableCollection<BankAccount> BankAccounts { get; set; } 
    }
}
