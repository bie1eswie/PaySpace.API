using PaySpace.Data.Abstract;
using PaySpace.Model.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaySpace.Model.Progressive;

namespace PaySpace.Data.Respository
{
    public class PaySpaceRepository : IPaySpaceRepository
    {
        private readonly PaySpaceContext _paySpaceContext;

        public PaySpaceRepository()
        {

        }

        public PaySpaceRepository(PaySpaceContext paySpaceContext)
        {
            _paySpaceContext = paySpaceContext;
        }

        public async Task<Guid> CreateCalculatorResponse(CalculatorResponse response)
        {
            response.Id = Guid.NewGuid();
            _paySpaceContext.CalculatorResponses.Add(response);
            await _paySpaceContext.SaveChangesAsync();
            return response.Id;
        }

        public async Task<CalculatorTypeMap> GetCalculatorTypeMap(string postalCode) => await _paySpaceContext.CalculatorTypeMaps.FirstOrDefaultAsync(x => x.PostalCode == postalCode);

        public async Task<ProgressiveCalculatorRangeMap> GetProgressiveCalculatorRangeMap(double input) => await _paySpaceContext.ProgressiveCalculatorRangeMaps.FirstOrDefaultAsync(x => input >= x.From && input <= x.To);
    }
}
