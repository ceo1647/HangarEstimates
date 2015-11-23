using System.Collections.Generic;
using System.Linq;
using HangarEstimates.Domain.Catalogs;
using HangarEstimates.Infrastructure.Utils;
using PropertyChanged;

namespace HangarEstimates.Domain
{
    /// <summary>
    /// Класс конструктивных элементов ангара
    /// </summary>
    [ImplementPropertyChanged]
    public class Hangar : BaseObject
    {
        public Hangar()
        {
            FirstEndWall = new EndWall();
            SecondEndWall = new EndWall();
            AdditionConstructions = new List<AdditionConstruction>();
        }

        /// <summary>
        /// Длина ангара
        /// </summary>
        public double Lenght { get; set; }
        /// <summary>
        /// Ширина ангара
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// Высота ангара
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Площадь
        /// </summary>
         [AlsoNotifyFor("Width", "Lenght")]
        public double Area
        {
            get { return Lenght * Width; }
        }
        [AlsoNotifyFor("Width", "Lenght")]
        public double Perimeter
        {
            get { return 2*Lenght + 2*Width; }
        }
        /// <summary>
        /// Тип фундамента
        /// </summary>
        public SubstuctureType SubstuctureType { get; set; }
        /// <summary>
        /// Торец 1
        /// </summary>
        public EndWall FirstEndWall { get; set; }
        /// <summary>
        /// Торец 2
        /// </summary>
        public EndWall SecondEndWall { get; set; }
        /// <summary>
        /// Утепление
        /// </summary>
        public InsulationType Insulation { get; set; }
        /// <summary>
        /// Дополнительные работы
        /// </summary>
        public IList<AdditionConstruction> AdditionConstructions { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Ширина: {0}, Длина: {1}, Высота: {2}\r\nФундамент:{3}\r\nТорец №1:{4}\r\nТорец №2:{5}", Width, Lenght, Height, SubstuctureType, FirstEndWall, SecondEndWall);
        }

        public Hangar CreateCopy()
        {
            var otherHangar = this.ConvertTo<Hangar>();
            otherHangar.FirstEndWall = this.FirstEndWall.ConvertTo<EndWall>();
            otherHangar.SecondEndWall = this.SecondEndWall.ConvertTo<EndWall>();
            otherHangar.SubstuctureType = this.SubstuctureType.ConvertTo<SubstuctureType>();
            if (this.Insulation != null)
                otherHangar.Insulation = this.Insulation.ConvertTo<InsulationType>();

            otherHangar.AdditionConstructions = new List<AdditionConstruction>(this.AdditionConstructions.Select(x => x.ConvertTo<AdditionConstruction>()));

            return otherHangar;
        }

        public void Init(Hangar other)
        {
            
        }
    }
}
