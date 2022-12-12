using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Inventor;
using Microsoft.VisualBasic.Devices;
using TankWheel.Model;
using Builder;

namespace StressTest
{
    public class StressTest
    {
        private static Application InvApp;
        public static PartComponentDefinition PartDefinition { get; set; }
        public static TransientGeometry TransientGeometry { get; private set; }
        public static PartDocument PartDoc { get; set; }
        private static void TestApp(WheelValues wheelValues)
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
            var newBuilder = new WheelBuilder(wheelValues);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var streamWriter = new StreamWriter($"log.txt", true);
            Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            var count = 0;
            while (true)
            {
                newBuilder.BuildWheel(wheelValues);
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory) *
                                 0.000000000931322574615478515625;
                streamWriter.WriteLine(
                    $"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();
            }
        }
    }
}
