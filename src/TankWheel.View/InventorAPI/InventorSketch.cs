using Inventor;
using Services;
using Point = System.Windows.Point;

namespace InventorAPI
{
    class InventorSketch : ISketch
    {
        /// <summary>
        /// Геометрия.
        /// </summary>
        private readonly TransientGeometry _transientGeometry;

        /// <summary>
        /// Возвращает эскиз.
        /// </summary>
        public PlanarSketch PlanarSketch { get; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="planarSketch">Эскиз.</param>
        /// <param name="transientGeometry">Геометрия приложения.</param>
        public InventorSketch(PlanarSketch planarSketch, TransientGeometry transientGeometry)
        {
            PlanarSketch = planarSketch;
            _transientGeometry = transientGeometry;
        }

        /// <inheritdoc/>
        public void CreateTwoPointRectangle(Point point1, Point point2)
        {
            var newPoint1 = _transientGeometry.CreatePoint2d(point1.X, point1.Y);
            var newPoint2 = _transientGeometry.CreatePoint2d(point2.X, point2.Y);
            PlanarSketch.SketchLines.AddAsTwoPointRectangle(newPoint1, newPoint2);
        }

        public void CreateCircle(Point point1, double radius)
        {
            var newCenter = _transientGeometry.CreatePoint2d(point1.X, point1.Y);
            PlanarSketch.SketchCircles.AddByCenterRadius(newCenter, radius);
        }

        void ISketch.CreateTwoPointRectangle(Inventor.Point point1, Inventor.Point point2)
        {
            var newPoint1 = _transientGeometry.CreatePoint2d(point1.X, point1.Y);
            var newPoint2 = _transientGeometry.CreatePoint2d(point2.X, point2.Y);
            PlanarSketch.SketchLines.AddAsTwoPointRectangle(newPoint1, newPoint2);
        }

        void ISketch.CreateCircle(Inventor.Point point1, double radius)
        {
            var newCenter = _transientGeometry.CreatePoint2d(point1.X, point1.Y);
            PlanarSketch.SketchCircles.AddByCenterRadius(newCenter, radius);
        }
    }
}
