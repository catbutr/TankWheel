using System.Windows;

namespace Services
{
    using Inventor;
    public interface ISketch
    {
        /// <summary>
        /// Создание круга по центру и радиусу
        /// </summary>
        /// <param name="point1">Центр</param>
        /// <param name="radius">Радиус</param>
        void CreateCircle(Point point1, double radius);
    }
}
