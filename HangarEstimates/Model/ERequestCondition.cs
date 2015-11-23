namespace HangarEstimates.Bll
{
    public enum ERequestCondition
    {
        /// <summary>
        /// Без состояния
        /// </summary>
        Обрабатывается,
        /// <summary>
        /// Только создан
        /// </summary>
        Завершено,
        /// <summary>
        /// В работе
        /// </summary>
        
        /// <summary>
        /// Удален
        /// </summary>
        Удален,
        /// <summary>
        /// Отменен
        /// </summary>
        CanceledByUs,
        /// <summary>
        /// Отменен клиентом
        /// </summary>
        CanceledByClient,
    }
}
