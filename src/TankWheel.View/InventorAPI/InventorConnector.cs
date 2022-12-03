using Services;
using System;
using System.Runtime.InteropServices;
using TankWheel.Model;


namespace InventorAPI
{
    using Inventor;
    public class InventorConnector:IApiService
    {
        /// <summary>
        /// Ссылка на работу с документацией АПИ.
        /// </summary>
        private PartDocument PartDoc { get; set; }

        /// <summary>
        /// Ссылка на приложение Inventor.
        /// </summary>
        private Application InvApp { get; set; }

        /// <summary>
        /// Описание документа.
        /// </summary>
        private PartComponentDefinition PartDefinition { get; set; }

        /// <summary>
        /// Геометрия приложения.
        /// </summary>
        private TransientGeometry TransientGeometry { get; set; }

        /// <inheritdoc/>
        public void CreateDocument()
        {
            InvApp = null;
            try
            {
                InvApp = (Application)Marshal.GetActiveObject("Inventor.Application");
            }
            catch (COMException)
            {
                try
                {
                    //Если не получилось перехватить приложение - выкинется исключение на то,
                    //что такого активного приложения нет. Попробуем создать приложение вручную.
                    var invAppType = Type.GetTypeFromProgID("Inventor.Application");

                    InvApp = (Application)Activator.CreateInstance(invAppType);
                    InvApp.Visible = true;
                }
                catch (Exception)
                {
                    throw new ApplicationException(@"Не получилось запустить Inventor.");
                }
            }

            // В открытом приложении создаем документ
            PartDoc = (PartDocument)InvApp.Documents.Add
            (DocumentTypeEnum.kPartDocumentObject,
                InvApp.FileManager.GetTemplateFile
                (DocumentTypeEnum.kPartDocumentObject,
                    SystemOfMeasureEnum.kMetricSystemOfMeasure));

            // Описание документа
            PartDefinition = PartDoc.ComponentDefinition;
            // Инициализация метода геометрии
            TransientGeometry = InvApp.TransientGeometry;
        }

        /// <inheritdoc/>
        public Inventor.Point CreatePoint(double x, double y)
        {
            var point = TransientGeometry.CreatePoint(x, y);
            return point;
        }

        /// <inheritdoc/>
        public ISketch CreateNewSketch(int n, double offset)
        {
            return new InventorSketch(MakeNewSketch(n, offset), TransientGeometry);
        }
        /// <inheritdoc/>
        public ISketch CreateNewSketchOnSurface()
        {
            return new InventorSketch(MakeNewSketchOnSurface(), TransientGeometry);
        }

        /// <inheritdoc/>
        public void Extrude(ISketch sketch, double distance)
        {
            if (!(sketch is InventorSketch planarSketch))
            {
                throw new ArgumentException("Не подходящий экземпляр эскиза.");
            }

            Extrude(planarSketch.PlanarSketch, distance);
        }

        public void ThroughExtrude(ISketch sketch, double distance)
        {
            if (!(sketch is InventorSketch planarSketch))
            {
                throw new ArgumentException("Не подходящий экземпляр эскиза.");
            }

            ThroughExtrude(planarSketch.PlanarSketch, distance);
        }

        /// <inheritdoc/>
        public void CircleArray(ISketch sketch, double angle, double count)
        {
            if (!(sketch is InventorSketch planarSketch))
            {
                throw new ArgumentException("Не подходящий экземпляр эскиза.");
            }

            CircleArray(planarSketch.PlanarSketch, angle, count);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Inventor";
        }

        /// <summary>
        /// Создает новый эскиз на рабочей плоскости.
        /// </summary>
        /// <param name="n">1 - ZY; 2 - ZX; 3 - XY.</param>
        /// <param name="offset">Расстояние от поверхности.</param>
        /// <returns>Новый эскиз.</returns>
        private PlanarSketch MakeNewSketch(int n, double offset)
        {
            var mainPlane = PartDefinition.WorkPlanes[n];
            var offsetPlane = PartDefinition.WorkPlanes.AddByPlaneAndOffset(
                mainPlane, offset, false);
            offsetPlane.Visible = false;
            var sketch = PartDefinition.Sketches.Add(offsetPlane, false);
            return sketch;
        }
        /// <summary>
        /// Создаёт новый эскиз на плоскости
        /// </summary>
        /// <param name="point"> Точка</param>
        /// <returns></returns>
        private PlanarSketch MakeNewSketchOnSurface()
        {
            var mainPlane = PartDefinition.WorkPlanes[2];
            var offsetPlane = PartDefinition.WorkPlanes.AddByPlaneAndOffset(
                mainPlane, 3, false);
            offsetPlane.Visible = false;
            var sketch = PartDefinition.Sketches.Add(offsetPlane, false);
            return sketch;
        }

        /// <summary>
        /// Выдавливание.
        /// </summary>
        /// <param name="sketch">Эскиз.</param>
        /// <param name="distance">Значение, на которое происходит выдавливание.</param>
        private void Extrude(PlanarSketch sketch, double distance)
        {
            sketch.Visible = false;
            var sketchProfile = sketch.Profiles.AddForSolid();
            var extrudeDef =
                PartDefinition.Features.ExtrudeFeatures
                    .CreateExtrudeDefinition(sketchProfile,
                        PartFeatureOperationEnum.kJoinOperation);
            if (distance >= 0)
            {
                extrudeDef.SetDistanceExtent(distance,
                    PartFeatureExtentDirectionEnum.kPositiveExtentDirection);
            }
            else
            {
                extrudeDef.SetDistanceExtent(-distance,
                    PartFeatureExtentDirectionEnum.kNegativeExtentDirection);
            }
            var extrude = PartDefinition.Features.ExtrudeFeatures.Add(extrudeDef);
            var objectCollection = CreateObjectCollection();
            objectCollection.Add(extrude);
        }

        private void ThroughExtrude(PlanarSketch sketch, double distance)
        {
            sketch.Visible = false;
            var sketchProfile = sketch.Profiles.AddForSolid();
            var extrudeDef =
                PartDefinition.Features.ExtrudeFeatures
                    .CreateExtrudeDefinition(sketchProfile,
                        PartFeatureOperationEnum.kCutOperation);
            if (distance >= 0)
            {
                extrudeDef.SetThroughAllExtent(PartFeatureExtentDirectionEnum.kPositiveExtentDirection);
            }
            else
            {
                extrudeDef.SetThroughAllExtent(PartFeatureExtentDirectionEnum.kNegativeExtentDirection);
            }
            var extrude = PartDefinition.Features.ExtrudeFeatures.Add(extrudeDef);
            var objectCollection = CreateObjectCollection();
            objectCollection.Add(extrude);
        }

        /// <summary>
        /// Круговой массив
        /// </summary>
        /// <param name="sketch">Эскиз</param>
        /// <param name="angle">Угол</param>
        /// <param name="count">Кол-во элементов</param>
        private void CircleArray(PlanarSketch sketch, double angle, double count)
        {
            var partDocument = (PartDocument)InvApp.ActiveDocument;
            var oCD = partDocument.ComponentDefinition;
            var features = oCD.Features.CircularPatternFeatures;
            var zAxis = PartDefinition.WorkAxes[3];
            var objectCollection = CreateObjectCollection();
            CircularPatternFeatureDefinition circularDefinition = features.CreateDefinition(objectCollection, zAxis, true, count, angle, true);
            var circularPattern = features.AddByDefinition(circularDefinition);
            objectCollection.Add(circularPattern);
        }

        /// <summary>
        /// Создание объекта коллекции.
        /// </summary>
        /// <returns>Коллекция объектов</returns>
        private ObjectCollection CreateObjectCollection()
        {
            return InvApp.TransientObjects.CreateObjectCollection();
        }

        Point IApiService.CreatePoint(double x, double y)
        {
            throw new NotImplementedException();
        }

        void IApiService.CreateDocument()
        {
            throw new NotImplementedException();
        }

        ISketch IApiService.CreateNewSketch(int n, double offset)
        {
            throw new NotImplementedException();
        }

        void IApiService.Extrude(ISketch sketch, double distance)
        {
            throw new NotImplementedException();
        }

        void IApiService.CircleArray(ISketch sketch, double angle, double count)
        {
            throw new NotImplementedException();
        }

        ISketch IApiService.CreateNewSketchOnSurface(Point point)
        {
            throw new NotImplementedException();
        }
    }
}
