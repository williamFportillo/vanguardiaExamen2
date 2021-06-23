using Hotel.Rates.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Interfaces
{
    public interface IRatePlansService
    {
        ServiceResult<RatePlan> GeyById(int id);

        ServiceResult<IReadOnlyList<RatePlan>> GetRatesPlans();
    }
}
