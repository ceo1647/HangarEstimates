// -----------------------------------------------------------------------
// <copyright file="$safeitemrootname$.cs" company="$registeredorganization$">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using HangarEstimates.Bll.Catalogs;
using PropertyChanged;

namespace HangarEstimates.Bll
{
    /// <summary>
    /// Требование пользователя
    /// </summary>
    [ImplementPropertyChanged]
    public class Request : BaseObject
    {
        /// <summary>
        /// Имя заявки (это может быть уникальный ее номер, к примеру)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Клиент
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Город в котором будет строится ангар
        /// </summary>
        public City HangarCity { get; set; }

        /// <summary>
        /// Ангар, который хочет клиент
        /// </summary>
        public Hangar Hangar { get; set; }

        /// <summary>
        /// Дата запроса
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Сосотояние запроса клиента
        /// </summary>
        public ERequestCondition Condition { get; set; }
    }
}
