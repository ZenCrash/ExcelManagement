using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClosedXML.Excel;

namespace ExcelManagement.ClassLibary.Models
{
    public class XlCellView
    {
        public IXLCell? XlCell { get; set; }
        public XLDataType Type { get; set; }
        public int ColumnNumber { get; set; }

        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        private object _value = (object)string.Empty;

        public XlCellView() { }

        public XlCellView(IXLCell cell)
        {
            XlCell = cell;
            ColumnNumber = cell.Address.ColumnNumber;

            switch (cell.Value.Type)
            {
                case XLDataType.Text:
                    Type = XLDataType.Text;
                    _value = XlCell.Value.GetText();
                    break;
                case XLDataType.Number:
                    Type = XLDataType.Number;
                    _value = XlCell.Value.GetNumber();
                    break;
                case XLDataType.Boolean:
                    Type = XLDataType.Boolean;
                    _value = XlCell.Value.GetBoolean();
                    break;
                case XLDataType.DateTime:
                    Type = XLDataType.DateTime;
                    _value = XlCell.Value.GetDateTime();
                    break;
                case XLDataType.Blank:
                    Type = XLDataType.Text;
                    _value = "";
                    break;
            }
        }

        public override string ToString()
        {
            return Value + "";
        }

    }
}