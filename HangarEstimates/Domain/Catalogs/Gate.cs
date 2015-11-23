namespace HangarEstimates.Domain.Catalogs
{
    /// <summary>
    /// Ворота
    /// </summary>
    public class Gate : BaseObject
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
