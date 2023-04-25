using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManagement.ClassLibary
{
    public class RowReservedException : Exception
    {
        public RowReservedException(string message) : base(message)
        {

        }
    }
}
