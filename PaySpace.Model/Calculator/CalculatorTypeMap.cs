using PaySpace.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Model.Calculator
{
    public class CalculatorTypeMap
    {
        [Key]
        public Guid Id { get; set; }    
        public CalculatorType CalculatorType { get; set; }
        public string PostalCode {  get; set; } = string.Empty;
    }
}
