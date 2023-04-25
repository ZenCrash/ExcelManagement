using ExcelManagement.ClassLibary.Models;
using ExcelManagement.ClassLibary;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManagement.Testing
{
    public class ExcelRepository_Test
    {

        //---------------------------------------------------------------------------//
        /* GetAll                                                                    */
        //---------------------------------------------------------------------------//

        //GetAllSheets
        [Fact]
        public void GetAllSheets_DictionaryWorkSheetnamesAndListOfRowsAsExtendoObject_ReturnsData()
        {
            //---------//
            /* Arrange */
            //---------//

            string workbookName = "TestWorkbook 1";
            string directory = @"..\ExcelDocuments\";
            ExcelRepository excelRepository = new();

            //---------//
            /* Act     */
            //---------//

            //dictionay keys = sheet names
            Dictionary<string, List<dynamic>> sheetList = excelRepository.GetallSheets(workbookName, directory);

            //Sheet 1
            var SheetOneListOfRows = sheetList.ElementAt(0).Value;
            //Row 1
            var SheetOneRowOne = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetOneRowOneCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                  //Row 1 Cells
            var SheetOneRowOneCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetOneRowOneCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetOneRowOneCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetOneRowOneCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;
            //Row 2
            var SheetOneRowTwo = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetOneRowTwoCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                  //Row 2 Cells
            var SheetOneRowTwoCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetOneRowTwoCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetOneRowTwoCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetOneRowTwoCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;
            //Row 3
            var SheetOneRowThree = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetOneRowThreeCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                    //Row 3 Cells
            var SheetOneRowThreeCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetOneRowThreeCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetOneRowThreeCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetOneRowThreeCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;

            //Sheet 2
            var SheetTwoListOfRows = sheetList.ElementAt(0).Value;
            //Row 1
            var SheetTwoRowOne = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetTwoRowOneCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                  //Row 1 Cells
            var SheetTwoRowOneCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetTwoRowOneCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetTwoRowOneCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetTwoRowOneCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;
            //Row 2
            var SheetTwoRowTwo = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetTwoRowTwoCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                  //Row 2 Cells
            var SheetTwoRowTwoCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetTwoRowTwoCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetTwoRowTwoCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetTwoRowTwoCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;
            //Row 3
            var SheetTwoRowThree = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetTwoRowThreeCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                    //Row 3 Cells
            var SheetTwoRowThreeCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetTwoRowThreeCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetTwoRowThreeCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetTwoRowThreeCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;

            //Sheet 3
            var SheetThreeListOfRows = sheetList.ElementAt(0).Value;
            //Row 1
            var SheetThreeRowOne = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetThreeRowOneCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                    //Row 1 Cells
            var SheetThreeRowOneCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetThreeRowOneCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetThreeRowOneCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetThreeRowOneCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;
            //Row 2
            var SheetThreeRowTwo = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetThreeRowTwoCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                    //Row 2 Cells
            var SheetThreeRowTwoCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetThreeRowTwoCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetThreeRowTwoCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetThreeRowTwoCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;
            //Row 3
            var SheetThreeRowThree = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetThreeRowThreeCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                      //Row 3 Cells
            var SheetThreeRowThreeCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetThreeRowThreeCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetThreeRowThreeCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetThreeRowThreeCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;

            //---------//
            /* Assert  */
            //---------//

            //Partent Dictionary
            Assert.NotNull(sheetList);
            Assert.NotEmpty(sheetList);



            //Sheet 1
            Assert.NotNull(sheetList.ElementAt(0).Value);
            Assert.NotEmpty(sheetList.ElementAt(0).Value);
            Assert.Equal("Sheet1", sheetList.ElementAt(0).Key);

            //Row 1
            Assert.IsType<IDictionary<string, object>>(SheetOneRowOne);
            Assert.NotNull(SheetOneRowOne);
            Assert.NotEmpty(SheetOneRowOne);
            //Row 2
            Assert.IsType<IDictionary<string, object>>(SheetOneRowTwo);
            Assert.NotNull(SheetOneRowTwo);
            Assert.NotEmpty(SheetOneRowTwo);
            //Row 3
            Assert.IsType<IDictionary<string, object>>(SheetOneRowThree);
            Assert.NotNull(SheetOneRowThree);
            Assert.NotEmpty(SheetOneRowThree);

            //Row 2
            //Rowindex
            Assert.NotNull(SheetOneRowTwoCellIndex);
            Assert.IsType<int>(SheetOneRowTwoCellIndex);
            Assert.Equal(1, SheetOneRowTwoCellIndex);
            //Cell 1
            Assert.NotNull(SheetOneRowTwoCellOneXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowTwoCellOneXlCellView);
            Assert.Equal("Data1", SheetOneRowTwoCellOneXlCellView.Value);
            //Cell 2
            Assert.NotNull(SheetOneRowTwoCellTwoXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowTwoCellTwoXlCellView);
            Assert.Equal("Data2", SheetOneRowTwoCellTwoXlCellView.Value);
            //Cell 3
            Assert.NotNull(SheetOneRowTwoCellThreeXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowTwoCellThreeXlCellView);
            Assert.Equal("Data3", SheetOneRowTwoCellThreeXlCellView.Value);
            //Cell 4
            Assert.NotNull(SheetOneRowTwoCellFourXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowTwoCellFourXlCellView);
            Assert.Equal("Data4", SheetOneRowTwoCellFourXlCellView.Value);

            //Row 3
            //Rowindex
            Assert.NotNull(SheetOneRowThreeCellIndex);
            Assert.IsType<int>(SheetOneRowThreeCellIndex);
            Assert.Equal(1, SheetOneRowThreeCellIndex);
            //Cell 1
            Assert.NotNull(SheetOneRowThreeCellOneXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowThreeCellOneXlCellView);
            Assert.Equal("Data5", SheetOneRowThreeCellOneXlCellView.Value);
            //Cell 2
            Assert.NotNull(SheetOneRowThreeCellTwoXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowThreeCellTwoXlCellView);
            Assert.Equal("Data6", SheetOneRowThreeCellTwoXlCellView.Value);
            //Cell 3
            Assert.NotNull(SheetOneRowThreeCellThreeXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowThreeCellThreeXlCellView);
            Assert.Equal("Data7", SheetOneRowThreeCellThreeXlCellView.Value);
            //Cell 4
            Assert.NotNull(SheetOneRowThreeCellFourXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowThreeCellFourXlCellView);
            Assert.Equal("Data8", SheetOneRowThreeCellFourXlCellView.Value);



            //Sheet 2
            Assert.NotNull(sheetList.ElementAt(1).Value);
            Assert.NotEmpty(sheetList.ElementAt(1).Value);
            Assert.Equal("Sheet2", sheetList.ElementAt(1).Key);

            //Row 1
            Assert.IsType<IDictionary<string, object>>(SheetTwoRowOne);
            Assert.NotNull(SheetTwoRowOne);
            Assert.NotEmpty(SheetTwoRowOne);
            //Row 2
            Assert.IsType<IDictionary<string, object>>(SheetTwoRowTwo);
            Assert.NotNull(SheetTwoRowTwo);
            Assert.NotEmpty(SheetTwoRowTwo);
            //Row 3
            Assert.IsType<IDictionary<string, object>>(SheetOneRowThree);
            Assert.NotNull(SheetTwoRowThree);
            Assert.NotEmpty(SheetTwoRowThree);

            //Row 2
            //Rowindex
            Assert.NotNull(SheetTwoRowTwoCellIndex);
            Assert.IsType<int>(SheetTwoRowTwoCellIndex);
            Assert.Equal(1, SheetTwoRowTwoCellIndex);
            //Cell 1
            Assert.NotNull(SheetTwoRowTwoCellOneXlCellView);
            Assert.IsType<XlCellView>(SheetTwoRowTwoCellOneXlCellView);
            Assert.Equal("Data1", SheetTwoRowTwoCellOneXlCellView.Value);
            //Cell 2
            Assert.NotNull(SheetTwoRowTwoCellTwoXlCellView);
            Assert.IsType<XlCellView>(SheetTwoRowTwoCellTwoXlCellView);
            Assert.Equal("Data2", SheetTwoRowTwoCellTwoXlCellView.Value);
            //Cell 3
            Assert.NotNull(SheetTwoRowTwoCellThreeXlCellView);
            Assert.IsType<XlCellView>(SheetTwoRowTwoCellThreeXlCellView);
            Assert.Equal("Data3", SheetTwoRowTwoCellThreeXlCellView.Value);
            //Cell 4
            Assert.NotNull(SheetTwoRowTwoCellFourXlCellView);
            Assert.IsType<XlCellView>(SheetTwoRowTwoCellFourXlCellView);
            Assert.Equal("Data4", SheetTwoRowTwoCellFourXlCellView.Value);

            //Row 3
            //Rowindex
            Assert.NotNull(SheetTwoRowThreeCellIndex);
            Assert.IsType<int>(SheetTwoRowThreeCellIndex);
            Assert.Equal(1, SheetTwoRowThreeCellIndex);
            //Cell 1
            Assert.NotNull(SheetTwoRowThreeCellOneXlCellView);
            Assert.IsType<XlCellView>(SheetTwoRowThreeCellOneXlCellView);
            Assert.Equal("Data5", SheetTwoRowThreeCellOneXlCellView.Value);
            //Cell 2
            Assert.NotNull(SheetTwoRowThreeCellTwoXlCellView);
            Assert.IsType<XlCellView>(SheetTwoRowThreeCellTwoXlCellView);
            Assert.Equal("Data6", SheetTwoRowThreeCellTwoXlCellView.Value);
            //Cell 3
            Assert.NotNull(SheetTwoRowThreeCellThreeXlCellView);
            Assert.IsType<XlCellView>(SheetTwoRowThreeCellThreeXlCellView);
            Assert.Equal("Data7", SheetTwoRowThreeCellThreeXlCellView.Value);
            //Cell 4
            Assert.NotNull(SheetTwoRowThreeCellFourXlCellView);
            Assert.IsType<XlCellView>(SheetTwoRowThreeCellFourXlCellView);
            Assert.Equal("Data8", SheetTwoRowThreeCellFourXlCellView.Value);



            //Sheet 3
            Assert.NotNull(sheetList.ElementAt(2).Value);
            Assert.NotEmpty(sheetList.ElementAt(2).Value);
            Assert.Equal("Sheet3", sheetList.ElementAt(2).Key);

            //Row 1
            Assert.IsType<IDictionary<string, object>>(SheetThreeRowOne);
            Assert.NotNull(SheetThreeRowOne);
            Assert.NotEmpty(SheetThreeRowOne);
            //Row 2
            Assert.IsType<IDictionary<string, object>>(SheetThreeRowTwo);
            Assert.NotNull(SheetThreeRowTwo);
            Assert.NotEmpty(SheetThreeRowTwo);
            //Row 3
            Assert.IsType<IDictionary<string, object>>(SheetThreeRowThree);
            Assert.NotNull(SheetThreeRowThree);
            Assert.NotEmpty(SheetThreeRowThree);

            //Row 2
            //Rowindex
            Assert.NotNull(SheetThreeRowTwoCellIndex);
            Assert.IsType<int>(SheetThreeRowTwoCellIndex);
            Assert.Equal(1, SheetThreeRowTwoCellIndex);
            //Cell 1
            Assert.NotNull(SheetThreeRowTwoCellOneXlCellView);
            Assert.IsType<XlCellView>(SheetThreeRowTwoCellOneXlCellView);
            Assert.Equal("Data1", SheetThreeRowTwoCellOneXlCellView.Value);
            //Cell 2
            Assert.NotNull(SheetThreeRowTwoCellTwoXlCellView);
            Assert.IsType<XlCellView>(SheetThreeRowTwoCellTwoXlCellView);
            Assert.Equal("Data2", SheetThreeRowTwoCellTwoXlCellView.Value);
            //Cell 3
            Assert.NotNull(SheetThreeRowTwoCellThreeXlCellView);
            Assert.IsType<XlCellView>(SheetThreeRowTwoCellThreeXlCellView);
            Assert.Equal("Data3", SheetThreeRowTwoCellThreeXlCellView.Value);
            //Cell 4
            Assert.NotNull(SheetThreeRowTwoCellFourXlCellView);
            Assert.IsType<XlCellView>(SheetThreeRowTwoCellFourXlCellView);
            Assert.Equal("Data4", SheetThreeRowTwoCellFourXlCellView.Value);

            //Row 3
            //Rowindex
            Assert.NotNull(SheetThreeRowThreeCellIndex);
            Assert.IsType<int>(SheetThreeRowThreeCellIndex);
            Assert.Equal(1, SheetThreeRowThreeCellIndex);
            //Cell 1
            Assert.NotNull(SheetThreeRowThreeCellOneXlCellView);
            Assert.IsType<XlCellView>(SheetThreeRowThreeCellOneXlCellView);
            Assert.Equal("Data5", SheetThreeRowThreeCellOneXlCellView.Value);
            //Cell 2
            Assert.NotNull(SheetThreeRowThreeCellTwoXlCellView);
            Assert.IsType<XlCellView>(SheetThreeRowThreeCellTwoXlCellView);
            Assert.Equal("Data6", SheetThreeRowThreeCellTwoXlCellView.Value);
            //Cell 3
            Assert.NotNull(SheetThreeRowThreeCellThreeXlCellView);
            Assert.IsType<XlCellView>(SheetThreeRowThreeCellThreeXlCellView);
            Assert.Equal("Data7", SheetThreeRowThreeCellThreeXlCellView.Value);
            //Cell 4
            Assert.NotNull(SheetThreeRowThreeCellFourXlCellView);
            Assert.IsType<XlCellView>(SheetThreeRowThreeCellFourXlCellView);
            Assert.Equal("Data8", SheetThreeRowThreeCellFourXlCellView.Value);
        }

        //---------------------------------------------------------------------------//
        /* Get                                                                       */
        //---------------------------------------------------------------------------//

        //GetFilePath
        [Theory]
        [InlineData(@"user\Documents", @"Woorkbook 1")]
        [InlineData(@"user\Documents", @"Woorkbook 1.xlsx")]
        public void GetFilePath_GetsFulleFilePath_FullFilePathWithFilTypeAppended(string directory, string workbookName)
        {
            //Arrange
            ExcelRepository excelRepository = new();

            //Act
            string result = excelRepository.GetFilePath(directory, workbookName);

            //Assert
            Assert.Equal(@"Woorkbook 1.xlsx", result);
        }

        //GetSheet
        [Fact]
        public void GetWorksheetKeyValuePairWorkSheetnamesAndListOfRowsAsExtendoObject_ReturnsData()
        {
            //---------//
            /* Arrange */
            //---------//

            string workbookName = "TestWorkbook 1";
            string worksheetName = "Sheet 1";
            string directory = @"..\ExcelDocuments\";
            ExcelRepository excelRepository = new();

            //---------//
            /* Act     */
            //---------//

            //dictionay keys = sheet names
            KeyValuePair<string, List<dynamic>> sheetList = excelRepository.GetWorksheet(workbookName, worksheetName, directory);

            //Sheet 1
            var SheetOneListOfRows = sheetList.Value;

            //Row 1
            var SheetOneRowOne = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetOneRowOneCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                  //Row 1 Cells
            var SheetOneRowOneCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetOneRowOneCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetOneRowOneCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetOneRowOneCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;
            //Row 2
            var SheetOneRowTwo = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetOneRowTwoCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                  //Row 2 Cells
            var SheetOneRowTwoCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetOneRowTwoCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetOneRowTwoCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetOneRowTwoCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;
            //Row 3
            var SheetOneRowThree = (IDictionary<string, object>)SheetOneListOfRows.ElementAt(0).Value;
            var SheetOneRowThreeCellIndex = (int)SheetOneRowOne.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                    //Row 3 Cells
            var SheetOneRowThreeCellOneXlCellView = (XlCellView)SheetOneRowOne.ElementAt(1).Value;
            var SheetOneRowThreeCellTwoXlCellView = (XlCellView)SheetOneRowOne.ElementAt(2).Value;
            var SheetOneRowThreeCellThreeXlCellView = (XlCellView)SheetOneRowOne.ElementAt(3).Value;
            var SheetOneRowThreeCellFourXlCellView = (XlCellView)SheetOneRowOne.ElementAt(4).Value;

            //---------//
            /* Assert  */
            //---------//

            //Sheet 1
            Assert.NotNull(sheetList.Value);
            Assert.NotEmpty(sheetList.Value);
            Assert.Equal("Sheet1", sheetList.Key);

            //Row 1
            Assert.IsType<IDictionary<string, object>>(SheetOneRowOne);
            Assert.NotNull(SheetOneRowOne);
            Assert.NotEmpty(SheetOneRowOne);
            //Row 2
            Assert.IsType<IDictionary<string, object>>(SheetOneRowTwo);
            Assert.NotNull(SheetOneRowTwo);
            Assert.NotEmpty(SheetOneRowTwo);
            //Row 3
            Assert.IsType<IDictionary<string, object>>(SheetOneRowThree);
            Assert.NotNull(SheetOneRowThree);
            Assert.NotEmpty(SheetOneRowThree);

            //Row 2
            //Rowindex
            Assert.NotNull(SheetOneRowTwoCellIndex);
            Assert.IsType<int>(SheetOneRowTwoCellIndex);
            Assert.Equal(1, SheetOneRowTwoCellIndex);
            //Cell 1
            Assert.NotNull(SheetOneRowTwoCellOneXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowTwoCellOneXlCellView);
            Assert.Equal("Data1", SheetOneRowTwoCellOneXlCellView.Value);
            //Cell 2
            Assert.NotNull(SheetOneRowTwoCellTwoXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowTwoCellTwoXlCellView);
            Assert.Equal("Data2", SheetOneRowTwoCellTwoXlCellView.Value);
            //Cell 3
            Assert.NotNull(SheetOneRowTwoCellThreeXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowTwoCellThreeXlCellView);
            Assert.Equal("Data3", SheetOneRowTwoCellThreeXlCellView.Value);
            //Cell 4
            Assert.NotNull(SheetOneRowTwoCellFourXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowTwoCellFourXlCellView);
            Assert.Equal("Data4", SheetOneRowTwoCellFourXlCellView.Value);

            //Row 3
            //Rowindex
            Assert.NotNull(SheetOneRowThreeCellIndex);
            Assert.IsType<int>(SheetOneRowThreeCellIndex);
            Assert.Equal(1, SheetOneRowThreeCellIndex);
            //Cell 1
            Assert.NotNull(SheetOneRowThreeCellOneXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowThreeCellOneXlCellView);
            Assert.Equal("Data5", SheetOneRowThreeCellOneXlCellView.Value);
            //Cell 2
            Assert.NotNull(SheetOneRowThreeCellTwoXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowThreeCellTwoXlCellView);
            Assert.Equal("Data6", SheetOneRowThreeCellTwoXlCellView.Value);
            //Cell 3
            Assert.NotNull(SheetOneRowThreeCellThreeXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowThreeCellThreeXlCellView);
            Assert.Equal("Data7", SheetOneRowThreeCellThreeXlCellView.Value);
            //Cell 4
            Assert.NotNull(SheetOneRowThreeCellFourXlCellView);
            Assert.IsType<XlCellView>(SheetOneRowThreeCellFourXlCellView);
            Assert.Equal("Data8", SheetOneRowThreeCellFourXlCellView.Value);

        }

        [Fact]
        public void GetLastUnusedRow_GetsAnExtendoObjectAsDictionaryStringXlCellView()
        {
            //---------//
            /* Arrange */
            //---------//
            string workbookName = "TestWorkbook 2";
            string directory = @"..\ExcelDocuments\";
            string sheetName = "Sheet1";
            ExcelRepository excelRepository = new();

            //---------//
            /* Act     */
            //---------//

            dynamic lastUnusedRowDynamic = excelRepository.GetLastUnusedRow(workbookName, sheetName, directory);

            //Row 1 (Header)
            var lastUnusedHeaderRow = (IDictionary<string, object>)lastUnusedRowDynamic.ElementAt(0).Value;
            var lastUnusedHeaderRowCellIndex = (int)lastUnusedHeaderRow.ElementAt(0).Value; //Rowindex (not a cell bu and int added to the dictionary)
                                                                                            //Row 1 Cells
            var lastUnusedHeaderRowCellOneXlCellView = (XlCellView)lastUnusedHeaderRow.ElementAt(1).Value;
            var lastUnusedHeaderRowCellTwoXlCellView = (XlCellView)lastUnusedHeaderRow.ElementAt(2).Value;
            var lastUnusedHeaderRowCellThreeXlCellView = (XlCellView)lastUnusedHeaderRow.ElementAt(3).Value;
            var lastUnusedHeaderRowCellFourXlCellView = (XlCellView)lastUnusedHeaderRow.ElementAt(4).Value;

            //Row 2
            var lastUnusedRow = (IDictionary<string, object>)lastUnusedRowDynamic.ElementAt(1).Value;
            var lastUnusedRowCellIndex = (int)lastUnusedRow.ElementAt(1).Value; //Rowindex (not a cell bu and int added to the dictionary)

            var lastUnusedRowCellOneXlCellView = (XlCellView)lastUnusedRow.ElementAt(1).Value;
            var lastUnusedRowCellTwoXlCellView = (XlCellView)lastUnusedRow.ElementAt(2).Value;
            var lastUnusedRowCellThreeXlCellView = (XlCellView)lastUnusedRow.ElementAt(3).Value;
            var lastUnusedRowCellFourXlCellView = (XlCellView)lastUnusedRow.ElementAt(4).Value;

            //---------//
            /* Assert  */
            //---------//

            //Row 1
            Assert.IsType<IDictionary<string, object>>(lastUnusedRowDynamic);
            Assert.NotNull(lastUnusedRowDynamic);
            Assert.NotEmpty(lastUnusedRowDynamic);
            //Rowindex
            Assert.NotNull(lastUnusedRowCellIndex);
            Assert.IsType<int>(lastUnusedRowCellIndex);
            Assert.Equal(4, lastUnusedRowCellIndex);
            //Cell 1
            Assert.NotNull(lastUnusedRowCellOneXlCellView);
            Assert.IsType<XlCellView>(lastUnusedRowCellOneXlCellView);
            Assert.Equal("", lastUnusedRowCellOneXlCellView.Value);
            //Cell 2
            Assert.NotNull(lastUnusedRowCellTwoXlCellView);
            Assert.IsType<XlCellView>(lastUnusedRowCellTwoXlCellView);
            Assert.Equal("", lastUnusedRowCellTwoXlCellView.Value);
            //Cell 3
            Assert.NotNull(lastUnusedRowCellThreeXlCellView);
            Assert.IsType<XlCellView>(lastUnusedRowCellThreeXlCellView);
            Assert.Equal("", lastUnusedRowCellThreeXlCellView.Value);
            //Cell 4
            Assert.NotNull(lastUnusedRowCellFourXlCellView);
            Assert.IsType<XlCellView>(lastUnusedRowCellFourXlCellView);
            Assert.Equal("", lastUnusedRowCellFourXlCellView.Value);
        }

        //---------------------------------------------------------------------------//
        /* Create                                                                    */
        //---------------------------------------------------------------------------//

        [Theory]
        [InlineData("TestWorkbook 2", "New Sheet", @"..\ExcelDocuments\")]
        public void CreateWorksheet_CreateNewSheet(string workbookName, string sheetName, string directory)
        {
            //---------//
            /* Arrange */
            //---------//
            ExcelRepository excelRepository = new();

            //---------//
            /* Act     */
            //---------//
            excelRepository.CreateWorksheet(workbookName, sheetName, directory);
            var worksheet = excelRepository.GetWorksheet(workbookName, sheetName, directory);

            //---------//
            /* Assert  */
            //---------//

            Assert.NotNull(worksheet);
            Assert.Equal("New Sheet", worksheet.Key);
        }

        //---------------------------------------------------------------------------//
        /* Update                                                                    */
        //---------------------------------------------------------------------------//

        [Fact]

        public void UpdateRowInExcel_UpdatesAnExtendoobjectWithAnotherExtendoObject()
        {
            //---------//
            /* Arrange */
            //---------//

            //Fields
            string workbookName = "TestWorkbook 2";
            string worksheetName = "New Sheet";
            string directory = @"..\ExcelDocuments\";
            ExcelRepository excelRepository = new();

            var model = new ExpandoObject() as IDictionary<string, object>;
            var lastunusedrow = (IDictionary<string, object>)excelRepository.GetLastUnusedRow(workbookName, worksheetName, directory);

            var updatedItem = lastunusedrow;

            updatedItem["GridId"] = 2;
            ((XlCellView)updatedItem["Column 1"]).XlCell.Value = "Data1";
            ((XlCellView)updatedItem["Column 2"]).XlCell.Value = "Data2";
            ((XlCellView)updatedItem["Column 3"]).XlCell.Value = "Data3";
            ((XlCellView)updatedItem["Column 4"]).XlCell.Value = "Data4";

            //---------//
            /* Act     */
            //---------//

            excelRepository.UpdateRowInExcel(worksheetName, updatedItem, workbookName, directory);

            var worksheet = excelRepository.GetWorksheet(workbookName, worksheetName, directory);
            var rows = worksheet.Value;
            var selectedRow = (IDictionary<string, object>)rows[2];
            var selectedRowCellOne = (XlCellView)selectedRow["Column 1"];
            var selectedRowCellTwo = (XlCellView)selectedRow["Column 2"];
            var selectedRowCellThree = (XlCellView)selectedRow["Column 3"];
            var selectedRowCellFour = (XlCellView)selectedRow["Column 4"];

            //---------//
            /* Assert  */
            //---------//

            Assert.IsType<IDictionary<string, object>>(selectedRow);
            Assert.NotNull(selectedRow);

            Assert.Equal("Data 1", selectedRowCellOne.Value);
            Assert.NotNull(selectedRowCellOne.Value);
            Assert.Equal("Data 2", selectedRowCellOne.Value);
            Assert.NotNull(selectedRowCellOne.Value);
            Assert.Equal("Data 3", selectedRowCellOne.Value);
            Assert.NotNull(selectedRowCellOne.Value);
            Assert.Equal("Data 4", selectedRowCellOne.Value);
            Assert.NotNull(selectedRowCellOne.Value);
        }

    }
}