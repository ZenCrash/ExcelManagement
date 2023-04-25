using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClosedXML.Excel;

namespace ExcelManagement.ClassLibary.Models
{
    public class XlCellView : IComparable<XlCellView>
    {
        public IXLCell XlCell { get; set; }
        public XLDataType Type { get; set; }
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

        public XlCellView(IXLCell cell)
        {
            XlCell = cell;

            switch (cell.Value.Type)
            {
                case XLDataType.Text:
                    double doubleValue;
                    if (double.TryParse(XlCell.Value.GetText(), out doubleValue))
                    {
                        _value = doubleValue;
                        Type = XLDataType.Number;
                    }
                    else
                    {
                        _value = XlCell.Value.GetText();
                        Type = XLDataType.Text;
                    }
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

        public int CompareTo(XlCellView other)
        {
            if (other == null) return 1;

            if (Type == other.Type)
            {
                switch (Type)
                {
                    case XLDataType.Number:
                        return ((double)Value).CompareTo((double)other.Value);
                    case XLDataType.Boolean:
                        return ((bool)Value).CompareTo((bool)other.Value);
                    case XLDataType.DateTime:
                        return ((DateTime)Value).CompareTo((DateTime)other.Value);
                    default:
                        return string.Compare((string)Value, (string)other.Value);
                }
            }
            else
            {
                return string.Compare(Type.ToString(), other.Type.ToString());
            }
        }
    }
}