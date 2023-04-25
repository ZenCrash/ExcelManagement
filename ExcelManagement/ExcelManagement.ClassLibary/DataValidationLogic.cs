using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManagement.ClassLibary
{
    public static class DataValidationLogic
    {
        public static List<string> ConvertStringToList(string input)
        {
            input = input.Trim().Trim('"');
            //If Input ends with ","
            input = (input.EndsWith(",")) ? input = input.Remove(input.Length - 1) : input;

            string[] elements = input.Split(',');
            List<string> output = new List<string>();

            foreach (string element in elements)
            {
                output.Add(element.Trim());
            }

            return output;
        }
    }
}