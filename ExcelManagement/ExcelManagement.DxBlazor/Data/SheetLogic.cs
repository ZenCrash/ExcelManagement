using ExcelManagement.ClassLibary;
using Newtonsoft.Json;
using System.Data;

namespace ExcelManagement.DxBlazor.Data
{
    public class SheetLogic
    {
        string jsonReservedFileFilePath = @"..\" + Path.Combine("ExcelManagement.DxBlazor", "Data", "ReservedFile.json");
        string jsonReservedRowFilePath = @"..\" + Path.Combine("ExcelManagement.DxBlazor", "Data", "ReservedRow.json");

        //---------------------------------------------------------------------------//
        /* Reserve File                                                              */
        //---------------------------------------------------------------------------//

        public void ReserverWorkbook(string userId, string fileName, string directory)
        {
            FileLogic fileLogic = new();
            if (!fileLogic.IsFileAccessable(directory, fileName))
            {
                throw new IOException();
            }

            //Convert newRow to Json
            ReservedWorkbookModel reservedFile = new ReservedWorkbookModel { UserId = userId, FileName = fileName, Directory = directory };
            string newJsonObject = JsonConvert.SerializeObject(reservedFile, Formatting.Indented);

            //Load Jsonfile into a c# instance
            List<ReservedWorkbookModel> existingData = new();

            string json = File.ReadAllText(jsonReservedFileFilePath);

            if (!(string.IsNullOrEmpty(json) || json == @"[]"))
            {
                existingData = JsonConvert.DeserializeObject<List<ReservedWorkbookModel>>(json);
            }

            //add the new class to list
            existingData.Add(reservedFile);

            //convert to Json and add to Jsonfile
            string updatedJson = JsonConvert.SerializeObject(existingData, Formatting.Indented);
            File.WriteAllText(jsonReservedFileFilePath, updatedJson);
        }

        //is the workbook reserved by any other users?
        public bool IsWorkbookReserved(string fileName, string directory)
        {
            string json = File.ReadAllText(jsonReservedRowFilePath);
            List<ReservedWorkbookModel> data = JsonConvert.DeserializeObject<List<ReservedWorkbookModel>>(json);

            if (data != null && data.Exists(x => x.FileName == fileName &&
                                                x.Directory == directory))
            {
                throw new WorkbookReservedException("");
            }

            else
            {
                return false;
            }
        }

        //Dispose all resoucres partaining to a user.
        public void UnreserveUseresWorkbooks(string userId)
        {
            List<ReservedWorkbookModel> existingData = new();

            string json = File.ReadAllText(jsonReservedFileFilePath);
            existingData = JsonConvert.DeserializeObject<List<ReservedWorkbookModel>>(json);

            existingData.RemoveAll(x => x.UserId == userId);
            string updatedJson = JsonConvert.SerializeObject(existingData, Formatting.Indented);
            File.WriteAllText(jsonReservedFileFilePath, updatedJson);
        }

        //---------------------------------------------------------------------------//
        /* Reserve Row                                                               */
        //---------------------------------------------------------------------------//

        //Reserver a row if not in use
        public void ReserveSheetRow(string userId, int rowIndex, string sheetName, string fileName, string directory)
        {
            FileLogic fileLogic = new();
            if (!fileLogic.IsFileAccessable(directory, fileName))
            {
                throw new IOException();
            }

            if (!IsRowReserved(userId, rowIndex, sheetName, fileName, directory))
            {
                //Convert newRow to Json
                ReservedRowModel reservedRow = new ReservedRowModel { UserId = userId, RowIndex = rowIndex, SheetName = sheetName, BookName = fileName, Directory = directory };
                string newJsonObject = JsonConvert.SerializeObject(reservedRow, Formatting.Indented);

                //Load Jsonfile into a c# instance
                List<ReservedRowModel> existingData = new();

                string json = File.ReadAllText(jsonReservedRowFilePath);

                if (!(string.IsNullOrEmpty(json) || json == @"[]"))
                {
                    existingData = JsonConvert.DeserializeObject<List<ReservedRowModel>>(json);
                }

                //add the new class to list
                existingData.Add(reservedRow);

                //convert to Json and add to Jsonfile
                string updatedJson = JsonConvert.SerializeObject(existingData, Formatting.Indented);
                File.WriteAllText(jsonReservedRowFilePath, updatedJson);
            }
            else
            {
                throw new DataException();
            }
        }

        //is the row reserved by any other user?
        public bool IsRowReserved(string userId, int rowIndex, string sheetName, string fileName, string directory)
        {
            string json = File.ReadAllText(jsonReservedRowFilePath);
            List<ReservedRowModel> data = JsonConvert.DeserializeObject<List<ReservedRowModel>>(json);

            if (data != null && data.Exists(x => x.RowIndex == rowIndex &&
                                                x.SheetName == sheetName &&
                                                x.BookName == fileName &&
                                                x.Directory == directory))
            {
                throw new RowReservedException("");
            }

            else
            {
                return false;
            }
        }

        // Dipose => dispose of un-managed resources. For instance native windows file handles, native windows socket resources
        public void UnReserveSheetRow(string userId, int rowIndex, string sheetName, string fileName, string directory)
        {
            List<ReservedRowModel> existingData = new();

            string json = File.ReadAllText(jsonReservedRowFilePath);
            existingData = JsonConvert.DeserializeObject<List<ReservedRowModel>>(json);

            existingData.RemoveAll(x => x.UserId == userId &&
                                        x.RowIndex == rowIndex &&
                                        x.SheetName == sheetName &&
                                        x.BookName == fileName &&
                                        x.Directory == directory);

            string updatedJson = JsonConvert.SerializeObject(existingData, Formatting.Indented);
            File.WriteAllText(jsonReservedRowFilePath, updatedJson);
        }

        //Dispose all resoucres partaining to a user.
        public void UnreserveUseresSheetRows(string userId)
        {
            List<ReservedRowModel> existingData = new();

            string json = File.ReadAllText(jsonReservedRowFilePath);
            existingData = JsonConvert.DeserializeObject<List<ReservedRowModel>>(json);

            existingData.RemoveAll(x => x.UserId == userId);
            string updatedJson = JsonConvert.SerializeObject(existingData, Formatting.Indented);
            File.WriteAllText(jsonReservedRowFilePath, updatedJson);
        }

        //---------------------------------------------------------------------------//
        /* other                                                                     */
        //---------------------------------------------------------------------------//

        //Clean json
        public void CleanJsonFiles()
        {
            var empty = @"[]";
            File.WriteAllText(jsonReservedFileFilePath, empty);
            File.WriteAllText(jsonReservedRowFilePath, empty);
        }
    }

}