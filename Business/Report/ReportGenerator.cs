using College.Domain.DTO.Report;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace College.Business.Report
{
    public class ReportGenerator
    {
        public static void GenerateExcelReport(List<ReportDTO> reportData)
        {
            // Ruta de salida del archivo de Excel
            string outputPath = @"MarksReport.xlsx";
            // Crear una instancia de Excel y abrir un nuevo libro
            Excel.Application excelApp = new()
            {
                Visible = true
            };
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            // Agregar encabezados de columna
            AddColumnHeaders(worksheet);

            // Agregar datos al informe
            AddDataToReport(worksheet, reportData);

            // Guardar el libro de Excel y liberar recursos
            SaveAndCleanup(workbook, excelApp, outputPath);
            Marshal.ReleaseComObject(worksheet);

        }
        public static void AddColumnHeaders(Excel.Worksheet worksheet)
        {
            // Encabezados de columna
            worksheet.Cells[1, 1] = "Año Académico";
            worksheet.Cells[1, 2] = "Identificación del Alumno";
            worksheet.Cells[1, 3] = "Nombre del Alumno";
            worksheet.Cells[1, 4] = "Código de la Materia";
            worksheet.Cells[1, 5] = "Nombre de la Materia";
            worksheet.Cells[1, 6] = "Identificación del Profesor";
            worksheet.Cells[1, 7] = "Nombre del Profesor";
            worksheet.Cells[1, 8] = "Calificación";
            worksheet.Cells[1, 9] = "Aprobó";

            // Establecer estilo de encabezado (opcional)
            Excel.Range headerRange = (Excel.Range)worksheet.Cells[1, 1];
            headerRange.Font.Bold = true;
            headerRange.Interior.Color = Excel.XlRgbColor.rgbLightGray;
        }

        public static void AddDataToReport(Excel.Worksheet worksheet, List<ReportDTO> reportData)
        {
            int row = 2; // Comenzar desde la fila 2

            foreach (var record in reportData)
            {
                worksheet.Cells[row, 1] = record.AcademicYear;
                worksheet.Cells[row, 2] = record.IdentificationStudent;
                worksheet.Cells[row, 3] = record.NameStudent;
                worksheet.Cells[row, 4] = record.Code;
                worksheet.Cells[row, 5] = record.NameSubject;
                worksheet.Cells[row, 6] = record.IdentificationTeacher;
                worksheet.Cells[row, 7] = record.NameTeacher;
                worksheet.Cells[row, 8] = record.FinalMark;
                worksheet.Cells[row, 9] = record.FinalMark >= 3.0M ? "SÍ" : "NO";

                row++;
            }
        }
        public static void SaveAndCleanup(Excel.Workbook workbook, Excel.Application excelApp, string outputPath)
        {
            workbook.SaveAs(outputPath);
            //workbook.Close(false);
            //excelApp.Quit();

            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);

            GC.Collect();
        }
    }
}