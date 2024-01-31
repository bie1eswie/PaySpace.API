using Microsoft.EntityFrameworkCore;
using PaySpace.Model.Calculator;
using PaySpace.Model.Progressive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Data.Respository
{
    public class PaySpaceContext : DbContext
    {
        public DbSet<CalculatorTypeMap> CalculatorTypeMaps { get; set; }
        public DbSet<ProgressiveCalculatorRangeMap> ProgressiveCalculatorRangeMaps { get; set; }
        public DbSet<CalculatorResponse> CalculatorResponses { get; set; }

        public PaySpaceContext() { }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public PaySpaceContext(DbContextOptions<PaySpaceContext> options) : base(options)
        {

        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CalculatorTypeMap
            modelBuilder.Entity<CalculatorTypeMap>().HasData(new CalculatorTypeMap { Id = new Guid("c12c5a45-950e-4911-ad18-a07bdc80acb7"),  CalculatorType = Common.Enums.CalculatorType.FlatRate, PostalCode = "7000" },
                                                             new CalculatorTypeMap { Id = new Guid("9662f04f-d363-4831-87ae-e159be869f9c"), CalculatorType = Common.Enums.CalculatorType.Progressive, PostalCode = "1000" },
                                                             new CalculatorTypeMap { Id = new Guid("40bbb4cc-3fb5-4d32-b29c-b839e38828ac"), CalculatorType = Common.Enums.CalculatorType.FlatValue, PostalCode = "A100" },
                                                             new CalculatorTypeMap { Id = new Guid("769edf75-2bd7-4688-b4f3-f433e79e54eb"), CalculatorType = Common.Enums.CalculatorType.Progressive, PostalCode = "7441" });

            #endregion

            #region ProgressiveCalculatorRangeMaps
            modelBuilder.Entity<ProgressiveCalculatorRangeMap>().HasData(new ProgressiveCalculatorRangeMap { Id = new Guid("e3c965f0-e8f3-45fc-ac17-ef8af23f5634"), From = 0,     To = 8350, Percentage = 0.1 },
                                                                         new ProgressiveCalculatorRangeMap { Id = new Guid("6cd0473e-3c9e-49e1-a010-82f634b5692c"), From = 8351,  To = 33950, Percentage = 0.15 },
                                                                         new ProgressiveCalculatorRangeMap { Id = new Guid("2218804c-3180-4470-85a8-512f9ec72224"), From = 33951, To = 82250, Percentage = 0.25 },
                                                                         new ProgressiveCalculatorRangeMap { Id = new Guid("4a3a1172-6563-415d-adcc-c503902023d9"), From = 82251, To = 171550, Percentage = 0.28 },
                                                                         new ProgressiveCalculatorRangeMap { Id = new Guid("46820772-0c01-4f1b-992b-9c5e4ba91242"), From = 171551,To = 372950, Percentage = 0.33},
                                                                         new ProgressiveCalculatorRangeMap { Id = new Guid("0c355928-9b7b-479c-9c61-09570402e6c9"), From = 372951,To = double.MaxValue, Percentage = 0.35});
            #endregion
        }
    }
}
