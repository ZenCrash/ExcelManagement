using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManagement.ClassLibary
{
    public class FileLogic
    {
        //File Accessability
        public bool IsFileAccessable(string DirectoryPath, string fileName)
        {
            try
            {
                using (FileStream fileStream = new FileStream(Path.Combine(DirectoryPath, fileName + ".xlsx"), FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return true;
                }
            }

            catch (Exception)
            {
                return false;
            }
        }
        public bool IsFileAccessable(string FullFilePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(Path.Combine(FullFilePath), FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return true;
                }
            }

            catch (Exception)
            {
                return false;
            }
        }

        //Overrite current workbook with new workbook
        public void UpdateWorkbook(string newFileName, string uploadDirectory, string originalFilename, string directory)
        {
            ExcelRepository excelRepository = new();

            string originalFileFullFilePath = excelRepository.GetFilePath(directory, originalFilename);
            string uploadedFileFullFilePath = excelRepository.GetFilePath(uploadDirectory, newFileName);

            if (!IsFileAccessable(originalFileFullFilePath))
            {
                throw new IOException();
            }

            //File.SetAttributes(uploadedFileFullFilePath, FileAttributes.Normal);
            //File.SetAttributes(originalFileFullFilePath, FileAttributes.Normal);

            byte[] uploadedBytes = File.ReadAllBytes(uploadedFileFullFilePath);
            byte[] originalFile = File.ReadAllBytes(originalFileFullFilePath);

            File.Copy(uploadedFileFullFilePath, originalFileFullFilePath, true);

            byte[] fileAfterCopy = File.ReadAllBytes(originalFileFullFilePath);

            File.Delete(uploadedFileFullFilePath);
        }

        //Clean temp folder
        public void DeleteFilesInTempFolder(string directoryPath = @"..\ExcelDocuments\temp")
        {
            if (Directory.Exists(directoryPath))
            {
                DirectoryInfo directory = new DirectoryInfo(directoryPath);

                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
            }
        }
    }
}