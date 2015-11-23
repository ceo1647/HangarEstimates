using System.Collections.Generic;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace HangarEstimates.Bll
{
    [ImplementPropertyChanged]
    public class Client : BaseObject
    {
        public Client()
        {
            Contacts = new ObservableCollection<Contact>();
            BankAccounts = new List<BankAccount>();
        }
        /// <summary>
        /// Наименование клиента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Физический адрес
        /// </summary>
        public Address PhysicAddress { get; set; }
        /// <summary>
        /// Юридический адрес
        /// </summary>
        public Address LegalAddress { get; set; }
        /// <summary>
        /// Контакты
        /// </summary>
        public ObservableCollection<Contact> Contacts { get; set; }
        /// <summary>
        /// Банковские счета
        /// </summary>
        public IList<BankAccount> BankAccounts { get; set; } 
    }
}
