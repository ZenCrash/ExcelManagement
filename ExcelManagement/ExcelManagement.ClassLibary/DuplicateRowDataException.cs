using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManagement.ClassLibary
{
    public class DuplicateRowDataException : Exception
    {
        public DuplicateRowDataException(string message) : base(message)
        {

        }
    }
}
