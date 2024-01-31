using PaySpace.Model.Calculator;
using PaySpace.Model.Progressive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Data.Abstract
{
    public interface IPaySpaceRepository
    {
        Task<CalculatorTypeMap> GetCalculatorTypeMap(string postalCode);
        Task<ProgressiveCalculatorRangeMap> GetProgressiveCalculatorRangeMap(double input);
        Task<Guid> CreateCalculatorResponse(CalculatorResponse response);
    }
}
