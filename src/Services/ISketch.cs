using System.Windows;

namespace Services
{
    using Inventor;
    public interface ISketch
    {
        void CreateTwoPointRectangle(Point point1, Point point2);
    }
}
