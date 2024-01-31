using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Model.Progressive
{
    public class ProgressiveCalculatorRangeMap
    {
        [Key]
        public Guid Id { get; set; }
        public double From { get; set; }
        public double To { get; set; }
        public double Percentage { get; set; }
    }
}
