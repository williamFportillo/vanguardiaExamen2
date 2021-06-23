using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Services
{
    public class RatesPlansService : IRatePlansService
    {
        private readonly IRatePlansRepository ratePlansRepository;

        public RatesPlansService(IRatePlansRepository ratePlansRepository)
        {
            this.ratePlansRepository = ratePlansRepository;
        }
        public ServiceResult<IReadOnlyList<RatePlan>> GetRatesPlans()
        {
            var result = ratePlansRepository.GetRatesPlan();
            return ServiceResult<IReadOnlyList<RatePlan>>.SuccessResult(result);
        }

        public ServiceResult<RatePlan> GeyById(int id)
        {
            var result = ratePlansRepository.GetById(id);
            return ServiceResult<RatePlan>.SuccessResult(result);
        }
    }
}
