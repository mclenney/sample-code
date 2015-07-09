using System;
using System.Data;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication2
{
    class Calculation
    {

        public double Result = 0;
        public String Message = string.Empty;
        public bool IsError = false;
        public String CleanEquation = string.Empty;

        public Calculation(string input)
        {
            input = input.Trim().Replace(" ", "");
            
            Regex reg = new Regex("[-+*/]");
            if(!reg.IsMatch(input))
            {
                Message = "Please insert an equation that contains one or more of the following operators: +, -, /, *.";
                IsError = true;
                return;
            }

            reg = new Regex("[^0-9-+*/]");
            CleanEquation = reg.Replace(input, "");

            try
            {
                Result = Convert.ToDouble(new DataTable().Compute(CleanEquation, null));

            }
            catch (Exception ex)
            {
                IsError = true;
                //Log error if this was database connected
                Type type = ex.GetType();
                if(type.Name == "OverflowException")
                {
                    Message = "Error: the number that was equated was too big or small, please input a different equation.";
                }
            }

            if (double.IsInfinity(Result))
            {
                IsError = true;
                Message = "Error: unable to divide by zero, please input a different equation.";
            }
            else if(double.IsNaN(Result))
            {
                IsError = true;
                Message = "Error: unable to divide zero by zero, please input a different equation.";
            }
        }
    }
}
