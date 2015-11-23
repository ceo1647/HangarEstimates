namespace HangarEstimates.Bll.Catalogs
{
    /// <summary>
    /// Окно
    /// </summary>
    public class Wind : BaseObject
    {
        /// <summary>
        /// Ширина ворот
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// Высота ворот
        /// </summary>
        public double Height { get; set; }

        public override string ToString()
        {
            return string.Format("Высота: {0} Ширина: {1}", Height, Width);
        } 
    }
}
