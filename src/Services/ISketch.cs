using System.Windows;

namespace Services
{
    using Inventor;
    public interface ISketch
    {
        void CreateCircle(Point point1, double radius);
    }
}
