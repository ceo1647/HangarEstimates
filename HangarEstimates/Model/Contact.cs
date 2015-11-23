using PropertyChanged;

namespace HangarEstimates.Bll
{
    /// <summary>
    /// Контактная информация
    /// </summary>
    [ImplementPropertyChanged]
    public class Contact
    {
        /// <summary>
        /// Наименование контакт а
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Финансы
        /// </summary>
        public bool Finances { get; set; }
        /// <summary>
        /// договора
        /// </summary>
        public bool Contracts { get; set; }
    }
}
