using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManagement.ClassLibary
{
    public class WorkbookReservedException : Exception
    {
        public WorkbookReservedException(string message) : base(message)
        {

        }
    }
}
