using System.Windows;

namespace Services
{
    using Inventor;
    /// <summary>
    /// Сервис для API.
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Создать документ API.
        /// </summary>
        void CreateDocument();

        /// <summary>
        /// Создание точки.
        /// </summary>
        /// <param name="x">X координата.</param>
        /// <param name="y">Y координата.</param>
        /// <returns>Точку.</returns>
        Point CreatePoint(double x, double y);

        /// <summary>
        /// Создание эскиза.
        /// </summary>
        /// <param name="n">Плоскость.</param>
        /// <param name="offset">Расстояние от плоскости.</param>
        /// <returns></returns>
        ISketch CreateNewSketch(int n, double offset);

        /// <summary>
        /// Выдавливание по эскизу.
        /// </summary>
        /// <param name="sketch">Эскиз.</param>
        /// <param name="distance">Расстояние выдавливания.</param>
        void Extrude(ISketch sketch, double distance);

        /// <summary>
        /// Создание кругового массива элементов
        /// </summary>
        /// <param name="sketch">Эскиз</param>
        /// <param name="angle">Угол</param>
        /// <param name="count">Число элементов</param>
        void CircleArray(ISketch sketch, double angle, double count);

        /// <summary>
        /// Выдавливание по эскизу насквозь
        /// </summary>
        /// <param name="sketch"></param>
        /// <param name="distance"></param>
        void ThroughExtrude(ISketch sketch, double distance);
    }
}