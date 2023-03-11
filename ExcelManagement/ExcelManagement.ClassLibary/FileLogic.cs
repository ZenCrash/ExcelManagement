using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManagement.ClassLibary
{
    public class FileLogic
    {
        public bool IsFileAccessable(string DirectoryPath, string selectedFileName)
        {
            try
            {
                using (FileStream fileStream = new FileStream(DirectoryPath + @"\" + selectedFileName + ".xlsx", FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}
