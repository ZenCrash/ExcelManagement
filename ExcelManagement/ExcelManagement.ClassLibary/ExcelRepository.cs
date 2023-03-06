﻿using System;
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
        public void CreateWorksheet(string workbookName, string sheetName, string directory)
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
        }

        //---------------------------------------------------------------------------//
        /* Update                                                                    */
        //---------------------------------------------------------------------------//

        public void UpdateRowInExcel(string sheetName, object updatedDataItem, string fileName, string directory)
        {
            string path = GetFilePath(directory, fileName);
            using (var workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheet(sheetName);

                int rowIndex = (int)((IDictionary<string, object>)updatedDataItem).First().Value;

                foreach (var cellObject in ((IDictionary<string, object>)updatedDataItem).Values.Skip(1))
                {
                    var cell = (XlCellView)cellObject;
                    if (!cell.XlCell?.HasFormula ?? true)
                    {
                        if (cell.Type == XLDataType.Text)
                        {
                            var cellValue = (string)cell.Value;
                            worksheet.Cell(rowIndex, cell.ColumnNumber).Value = cellValue;
                        }
                        else if (cell.Type == XLDataType.Blank)
                        {
                            var cellValue = (string)cell.Value;
                            worksheet.Cell(rowIndex, cell.ColumnNumber).Value = cellValue;
                        }
                        else if (cell.Type == XLDataType.Number)
                        {
                            var cellValue = (double)cell.Value;
                            worksheet.Cell(rowIndex, cell.ColumnNumber).Value = cellValue;
                        }
                        else if (cell.Type == XLDataType.DateTime)
                        {
                            var cellValue = (DateTime)cell.Value;
                            worksheet.Cell(rowIndex, cell.ColumnNumber).Value = cellValue;
                        }
                    }
                }

                workbook.SaveAs(path);
            }
        }

        //---------------------------------------------------------------------------//
        /* Delete                                                                    */
        //---------------------------------------------------------------------------//

        public void DeleteRowInSheet(int rowIndex, string sheetName, string fileName, string directory)
        {
            string path = GetFilePath(directory, fileName);
            using (var workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheet(sheetName);
                worksheet.Row(rowIndex).Delete();

                workbook.SaveAs(path);
            }
        }
    }
}