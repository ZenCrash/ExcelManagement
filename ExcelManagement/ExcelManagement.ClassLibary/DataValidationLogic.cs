using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManagement.ClassLibary
{
    public class DataValidationLogic
    {
        public static List<string> ConvertStringToList(string input)
        {
            // Remove the backslashes and quotation marks from the input string
            string trimmedInput = input.Replace("\\", "").Replace("\"", "");

            // Split the trimmed input string into an array of strings
            string[] stringArray = trimmedInput.Split(',');

            // Create a new list to hold the output
            List<string> outputList = new List<string>();

            // Add each element from the string array to the output list
            foreach (string element in stringArray)
            {
                outputList.Add(element);
            }

            return outputList;
        }
    }
}
