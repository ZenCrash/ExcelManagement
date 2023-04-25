using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManagement.ClassLibary
{
    public class DuplicateWorkbookException : Exception
    {
        public DuplicateWorkbookException(string message) : base(message)
        {

        }
    }
}
