using Custodian.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Custodian.DALs.InterfaceService.Financial_Plan_Data_Correct
{
    public sealed class INTMinMaxFormat_Correct : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (string.IsNullOrWhiteSpace(str))
            {
                return new ValidationResult(false, "string is Empty or Equals null");
            }

            try
            {
                var integ = Convert.ToInt32(str);
                if (integ <= Max && integ >= Min)
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "Property must be a minimum 1 and maximum 6");
                }

            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }

        }
    }
}
