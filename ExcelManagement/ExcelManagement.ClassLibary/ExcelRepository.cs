using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExcelManagement.ClassLibary.Models;

using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;

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
            var workbook = new XLWorkbook(path);
            var data = new Dictionary<string, List<dynamic>>();

            foreach (var worksheet in workbook.Worksheets)
            {
                //IF Sheet empty header or data, add new data to header row, and save it.
                if (worksheet.FirstRow().CellsUsed().Count() == 0)
                {
                    var maxCols = 4; // If the sheet doesn't contain any rows, add data to header.

                    for (int col = 1; col <= maxCols; col++) //Header assign placeholder value
                    {
                        worksheet.Cell(1, col).Value = $"Column {col}";
                        var address = worksheet.Cell(1, col).Address;
                    }

                    workbook.SaveAs(path);
                }

                // If the sheet contains data
                var headers = worksheet.RowsUsed().First();
                var dataRows = worksheet.RowsUsed().Skip(1);
                var sheetData = new List<dynamic>();

                if (worksheet.RowsUsed().Skip(1).Count() != 0)
                {
                    foreach (var dataRow in dataRows)
                    {
                        dynamic item = new ExpandoObject();
                        var dictionary = (IDictionary<string, object>)item;

                        dictionary["GridId"] = dataRow.RowNumber();
                        for (int i = 0; i < headers.Cells().Count(); i++)
                        {
                            var xlCellView = new XlCellView(dataRow.Cell(i + 1));
                            dictionary[headers.Cell(i + 1).Value.ToString().Replace(" ", "")] = xlCellView;

                            //if (xlCellView.XlCell.HasFormula && xlCellView.XlCell.FormulaA1.StartsWith("HYPERLINK", StringComparison.OrdinalIgnoreCase))
                            //{

                            //}

                            //var value = @"=" + ((XlCellView)dataItem[property]).XlCell.FormulaA1; //display cell formel instead

                        }

                        sheetData.Add(item);
                    }

                }

                else //if header colum has data, but rest dossent. then select first 4 rows
                {
                    int maxRows = 2; //how many empty rows sould be fetched

                    for (int row = 2; row <= maxRows + 1; row++)
                    {
                        dynamic item = new ExpandoObject();
                        var dictionary = (IDictionary<string, object>)item;

                        dictionary["GridId"] = row;

                        for (int i = 0; i < headers.Cells().Count(); i++) //Cells assign placeholder values
                        {
                            var xlCellView = new XlCellView(worksheet.Cell(row, i + 1));
                            dictionary[headers.Cell(i + 1).Value.ToString().Replace(" ", "")] = xlCellView;
                        }

                        sheetData.Add(item);
                    }
                }

                data[worksheet.Name] = sheetData;
            }

            return data;
        }

        //get first row (assuming it has data) - new row in grid
        public dynamic GetFirstRow(string workbookName, string sheetName, string directory)
        {
            string path = GetFilePath(directory, workbookName);
            var workbook = new XLWorkbook(path);
            var worksheet = workbook.Worksheet(sheetName);

            var firstRow = worksheet.RowsUsed().First();

            var lastRow = worksheet.RowsUsed().Last();
            var newRow = lastRow.InsertRowsBelow(1).First();


            dynamic item = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)item;

            dictionary["GridId"] = 0;
            for (int i = 0; i < worksheet.RowsUsed().First().Cells().Count(); i++)
            {
                var xlCellView = new XlCellView(newRow.Cell(i + 1));
                dictionary[worksheet.RowsUsed().First().Cell(i + 1).Value.ToString().Replace(" ", "")] = xlCellView;
            }

            return item;
        }

        //---------------------------------------------------------------------------//
        /* Create                                                                    */
        //---------------------------------------------------------------------------//

        //Create worksheet
        //by workbook, directory, sheetname
        public bool CreateWorksheet(string workbookName, string sheetName, string directory)
        {
            bool operationSucess;
            try
            {
                string filePath = GetFilePath(directory, workbookName);

                if (File.Exists(filePath))
                {
                    using (var workbook = new XLWorkbook(filePath))
                    {
                        //If Default:
                        int i = 1;
                        string newSheetName;
                        if (sheetName == "")
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
                operationSucess = true;
            }
            catch
            {
                operationSucess = false;
            }

            return operationSucess;
        }

        //---------------------------------------------------------------------------//
        /* Update                                                                    */
        //---------------------------------------------------------------------------//

        public bool UpdateRowInExcel(string sheetName, object updatedDataItem, string fileName, string directory)
        {
            bool operationSucess;

            try
            {
                string path = GetFilePath(directory, fileName);
                using (var workbook = new XLWorkbook(path))
                {
                    var worksheet = workbook.Worksheet(sheetName);

                    int rowIndex = (int)((IDictionary<string, object>)updatedDataItem).First().Value;

                    //If new item find last alvalabe index that is empty
                    //this insure that 2 users cant overrite eachother
                    if (rowIndex == 0)
                    {
                        rowIndex = worksheet.LastRowUsed().RowNumber() + 1;
                    }

                    foreach (var cellObject in ((IDictionary<string, object>)updatedDataItem).Values.Skip(1))
                    {
                        var cell = (XlCellView)cellObject;
                        if (!cell.XlCell.HasFormula)
                        {
                            if (cell.XlCell.Value.Type == XLDataType.Text)
                            {
                                var cellValue = (string)cell.Value;
                                worksheet.Cell(rowIndex, cell.XlCell.Address.ColumnNumber).Value = cellValue;
                            }
                            else if (cell.XlCell.Value.Type == XLDataType.Blank)
                            {
                                var cellValue = (string)cell.Value;
                                worksheet.Cell(rowIndex, cell.XlCell.Address.ColumnNumber).Value = cellValue;
                            }
                            else if (cell.XlCell.Value.Type == XLDataType.Number)
                            {
                                var cellValue = (double)cell.Value;
                                worksheet.Cell(rowIndex, cell.XlCell.Address.ColumnNumber).Value = cellValue;
                            }
                            else if (cell.XlCell.Value.Type == XLDataType.DateTime)
                            {
                                var cellValue = (DateTime)cell.Value;
                                worksheet.Cell(rowIndex, cell.XlCell.Address.ColumnNumber).Value = cellValue;
                            }
                        }
                    }

                    workbook.SaveAs(path);
                }
                operationSucess = true;
            }
            catch
            {
                operationSucess = false;
            }

            return operationSucess;
        }



        //---------------------------------------------------------------------------//
        /* Delete                                                                    */
        //---------------------------------------------------------------------------//

        public bool DeleteRowInSheet(int rowIndex, string sheetName, string fileName, string directory)
        {
            bool operationSucess;

            try
            {
                string path = GetFilePath(directory, fileName);

                using (var workbook = new XLWorkbook(path))
                {
                    var worksheet = workbook.Worksheet(sheetName);
                    worksheet.Row(rowIndex).Delete();

                    workbook.SaveAs(path);
                }
                operationSucess = true;
            }
            catch
            {
                operationSucess = false;
            }

            return operationSucess;
        }
    }
}