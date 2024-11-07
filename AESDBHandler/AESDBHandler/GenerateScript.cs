using System;
using System.IO;
using AESModel;
using ClosedXML.Excel;

namespace AESDBHandler
{
    public class GenerateScript
    {
        private const string ExcelFilePath = "ScriptData.xlsx";

        public bool ScriptData(ScriptModel scriptModel)
        {
            try
            {
                // Create the directory if it doesn't exist
                var fileInfo = new FileInfo(ExcelFilePath);
                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                IXLWorkbook workbook;
                IXLWorksheet worksheet;

                // Open or create the workbook
                if (File.Exists(ExcelFilePath))
                {
                    // Open the existing workbook
                    workbook = new XLWorkbook(ExcelFilePath);
                    worksheet = workbook.Worksheet(1); // Get the first worksheet
                }
                else
                {
                    // Create a new workbook and worksheet
                    workbook = new XLWorkbook();
                    worksheet = workbook.AddWorksheet("Script Data");

                    // Add headers for new file
                    worksheet.Cell(1, 1).Value = "Template";
                    worksheet.Cell(1, 2).Value = "Snippet Group";
                    worksheet.Cell(1, 3).Value = "SOSV Setup";
                }

                // Find the next available row
                int nextRow = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 2;

                // Write the data from ScriptModel to the next available row
                worksheet.Cell(nextRow, 1).Value = scriptModel.template;
                worksheet.Cell(nextRow, 2).Value = scriptModel.snippet_group;
                worksheet.Cell(nextRow, 3).Value = scriptModel.sosv_setup;

                // Save the workbook
                workbook.SaveAs(ExcelFilePath);

                // Dispose workbook manually
                workbook.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                // Log detailed error message
                Console.WriteLine($"Error while processing Excel file: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return false;
            }
        }
    }
}
