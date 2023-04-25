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
        FileLogic fileLogic = new();

        public string GetFilePath(string directory, string workbookName)
        {
            string fileType = ".xlsx";
            if (workbookName.EndsWith(fileType))
            {
                return Path.Combine(directory, workbookName);
            }
            else
            {
                return Path.Combine(directory, workbookName + fileType);
            }

        }

        //---------------------------------------------------------------------------//
        /* GetAll                                                                    */
        //---------------------------------------------------------------------------//

        //Getall Worksheets
        public Dictionary<string, List<dynamic>> GetallSheets(string workbookName, string directory)
        {
            string fullFilePath = GetFilePath(directory, workbookName);

            if (!fileLogic.IsFileAccessable(fullFilePath))
            {
                throw new IOException();
            }

            var workbook = new XLWorkbook(fullFilePath);
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
                    }

                    workbook.SaveAs(fullFilePath);
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

        //---------------------------------------------------------------------------//
        /* Get                                                                       */
        //---------------------------------------------------------------------------//

        //New Row / get first row (assuming it has data)
        public dynamic GetFirstRow(string workbookName, string sheetName, string directory)
        {
            string fullFilePath = GetFilePath(directory, workbookName);
            var workbook = new XLWorkbook(fullFilePath);
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

        //Get Workbook
        public KeyValuePair<string, Dictionary<string, List<dynamic>>> GetWorkbook(string workbookName, string directory)
        {
            string fullFilePath = GetFilePath(directory, workbookName);

            if (!fileLogic.IsFileAccessable(fullFilePath))
            {
                throw new IOException();
            }

            var workbook = new XLWorkbook(fullFilePath);
            var dataSheets = new Dictionary<string, List<dynamic>>();

            foreach (var worksheet in workbook.Worksheets)
            {
                //IF Sheet empty header or data, add new data to header row, and save it.
                if (worksheet.FirstRow().CellsUsed().Count() == 0)
                {
                    var maxCols = 4; // If the sheet doesn't contain any rows, add data to header.

                    for (int col = 1; col <= maxCols; col++) //Header assign placeholder value
                    {
                        worksheet.Cell(1, col).Value = $"Column {col}";
                    }

                    workbook.SaveAs(fullFilePath);
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

                dataSheets[worksheet.Name] = sheetData;
            }
            KeyValuePair<string, Dictionary<string, List<dynamic>>> WorkbookData = new(workbookName, dataSheets);

            return WorkbookData;
        }

        //---------------------------------------------------------------------------//
        /* Create                                                                    */
        //---------------------------------------------------------------------------//

        public void CreateWorksheet(string workbookName, string sheetName, string directory)
        {
            string fullFilePath = GetFilePath(directory, workbookName);

            if (!fileLogic.IsFileAccessable(fullFilePath))
            {
                throw new IOException();
            }

            using (var workbook = new XLWorkbook(fullFilePath))
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
                workbook.SaveAs(fullFilePath);
            }
        }

        //Add column to header row (adds value to first row in sheet)
        //private void AddColumn(string workbookName, string sheetName, string newColumnHeader, string directory)
        //{
        //    string fullFilePath = GetFilePath(directory, workbookName);

        //    if (!fileLogic.IsFileAccessable(fullFilePath))
        //    {
        //        throw new IOException();
        //    }


        //    using (var workbook = new XLWorkbook(fullFilePath))
        //    {
        //        var worksheet = workbook.Worksheet(sheetName);
        //        var headers = worksheet.Rows().First();



        //        ////If Default:
        //        //int i = 1;
        //        //string newColumnName;
        //        //if (newColumnHeader == "")
        //        //{
        //        //    newColumnHeader = "Column";
        //        //    newColumnName = newColumnHeader + $" {i}";
        //        //}
        //        //else
        //        //{
        //        //    newColumnName = newColumnHeader;
        //        //}

        //        //while (headers.Cells().Any(cell => cell.Value.ToString() == newColumnName))
        //        //{
        //        //    i++;
        //        //    newColumnName = newColumnHeader + $" {i}";
        //        //}

        //        //workbook.cell
        //        //workbook.SaveAs(fullFilePath);
        //    }
        //}

        //---------------------------------------------------------------------------//
        /* Update                                                                    */
        //---------------------------------------------------------------------------//

        public void UpdateRowInExcel(string sheetName, object updatedDataItem, string fileName, string directory)
        {
            string fullFilePath = GetFilePath(directory, fileName);

            if (!fileLogic.IsFileAccessable(fullFilePath))
            {
                throw new IOException();
            }

            using (var workbook = new XLWorkbook(fullFilePath))
            {
                var worksheet = workbook.Worksheet(sheetName);

                int rowIndex = (int)((IDictionary<string, object>)updatedDataItem).First().Value;

                //If new item, find last alvalabe index that is empty
                //this insure that 2 users cant overrite eachother
                if (rowIndex == 0)
                {
                    rowIndex = worksheet.LastRowUsed().RowNumber() + 1;
                }

                //Duplicate Data Counter
                int NewCellData = 0;
                foreach (var cellObject in ((IDictionary<string, object>)updatedDataItem).Values.Skip(1))
                {
                    var cell = (XlCellView)cellObject;
                    int columnIndex = cell.XlCell.Address.ColumnNumber;

                    if (worksheet.Cell(rowIndex, columnIndex).Value.ToString() != cell.Value.ToString()) //all new = old?
                    {
                        NewCellData++;
                    }
                }

                //If Duplicate
                if (NewCellData == 0)
                {
                    throw new DuplicateRowDataException("");
                }

                //Add new Data to cells
                foreach (var cellObject in ((IDictionary<string, object>)updatedDataItem).Values.Skip(1))
                {
                    var cell = (XlCellView)cellObject;
                    int columnIndex = cell.XlCell.Address.ColumnNumber;

                    if (!cell.XlCell.HasFormula)
                    {
                        if (cell.XlCell.Value.Type == XLDataType.Text)
                        {
                            //trypase as int before insert
                            var cellValue = (string)cell.Value;
                            double cellValueAsDouble;
                            if (double.TryParse(cellValue, out cellValueAsDouble))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Value = cellValueAsDouble;
                            }
                            else
                            {
                                worksheet.Cell(rowIndex, columnIndex).Value = cellValue;
                            }
                        }
                        else if (cell.XlCell.Value.Type == XLDataType.Number)
                        {
                            var cellValue = (double)cell.Value;
                            worksheet.Cell(rowIndex, columnIndex).Value = cellValue;
                        }
                        else if (cell.XlCell.Value.Type == XLDataType.Blank)
                        {
                            var cellValue = (string)cell.Value;
                            worksheet.Cell(rowIndex, columnIndex).Value = cellValue;
                        }
                        else if (cell.XlCell.Value.Type == XLDataType.DateTime)
                        {
                            var cellValue = (DateTime)cell.Value;
                            worksheet.Cell(rowIndex, columnIndex).Value = cellValue;
                        }
                    }
                }
                Console.WriteLine($"New data added to {directory} Sheet: {sheetName} at row {rowIndex}");

                workbook.SaveAs(fullFilePath);
            }
        }

        //---------------------------------------------------------------------------//
        /* Delete                                                                    */
        //---------------------------------------------------------------------------//

        public void DeleteRowInSheet(int rowIndex, string sheetName, string fileName, string directory)
        {
            string fullFilePath = GetFilePath(directory, fileName);
            if (!fileLogic.IsFileAccessable(fullFilePath))
            {
                throw new IOException();
            }

            using (var workbook = new XLWorkbook(fullFilePath))
            {
                //var worksheet = workbook.Worksheet(sheetName);
                //worksheet.Row(rowIndex).Delete();

                workbook.SaveAs(fullFilePath);
            }
        }
    }
}