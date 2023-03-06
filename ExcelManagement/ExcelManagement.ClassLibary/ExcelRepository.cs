using ClosedXML.Excel;
using ExcelManagement.ClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManagement.ClassLibary
{
    public class ExcelRepository
    {
        public string GetFilePath(string directory, string workbookName)
        {
            string fileType = ".xlsx";
            if (workbookName.EndsWith(fileType))
            {
                return directory + @"\" + workbookName;
            }

            else
            {
                return directory + @"\" + workbookName + fileType;
            }

        }

        //---------------------------------------------------------------------------//
        /* GetAll                                                                    */
        //---------------------------------------------------------------------------//

        //Getall Worksheets and cells.
        public Dictionary<string, List<dynamic>> GetSheetsByBookname(string workbookName, string directory)
        {
            string path = GetFilePath(directory, workbookName);
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) // file can be accessed even when open.
            {
                using (var workbook = new XLWorkbook(path))
                {
                    var data = new Dictionary<string, List<dynamic>>();

                    foreach (var worksheet in workbook.Worksheets)
                    {
                        var rows = worksheet.RowsUsed();
                        if (!rows.Any())
                        {
                            // If the sheet doesn't contain any rows, return the first 4 rows and columns and add them to the list.
                            var sheetData = new List<dynamic>();
                            var maxRows = 4;
                            var maxCols = 4;

                            for (int row = 1; row <= maxRows; row++)
                            {
                                dynamic item = new ExpandoObject();
                                var dictionary = (IDictionary<string, object>)item;

                                dictionary["GridId"] = row;
                                for (int col = 1; col <= maxCols; col++)
                                {
                                    dictionary[string.Format("Column {0}", col)] = new XlCellView(worksheet.Cell(row, col));
                                }

                                sheetData.Add(item);
                            }

                            data[worksheet.Name] = sheetData;
                        }
                        else
                        {
                            // If the sheet contains data
                            var headers = rows.First();
                            var dataRows = rows.Skip(1);
                            var sheetData = new List<dynamic>();

                            foreach (var dataRow in dataRows)
                            {
                                dynamic item = new ExpandoObject();
                                var dictionary = (IDictionary<string, object>)item;

                                dictionary["GridId"] = dataRow.RowNumber();
                                for (int i = 0; i < headers.Cells().Count(); i++)
                                {
                                    dictionary[headers.Cell(i + 1).Value.ToString().Replace(" ", "")] = new XlCellView(dataRow.Cell(i + 1));
                                }

                                sheetData.Add(item);
                            }

                            data[worksheet.Name] = sheetData;
                        }
                    }

                    return data;
                }
            }
        }

        //---------------------------------------------------------------------------//
        /* Create                                                                    */
        //---------------------------------------------------------------------------//

        //Create worksheet
        //by workbook, directory, sheetname
        public void CreateWorksheet(string workbookName, string directory, string sheetName = "DefaultProp")
        {
            string filePath = GetFilePath(directory, workbookName);

            if (File.Exists(filePath))
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    //If Default:
                    int i = 1;
                    string newSheetName;
                    if (sheetName == "DefaultProp")
                    {
                        sheetName = "Sheet";
                        newSheetName = sheetName + $" {i}";
                    }
                    else
                    {
                        newSheetName = sheetName;
                    }

                    while (workbook.Worksheets.Any(ws => ws.Name == newSheetName))
                    {
                        i++;
                        newSheetName = sheetName + $" {i}";
                    }

                    workbook.Worksheets.Add(newSheetName);
                    workbook.SaveAs(filePath);
                }
            }
        }

    }
}