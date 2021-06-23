using Hotel.Rates.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Interfaces
{
    public interface IRatePlansRepository
    {
        IReadOnlyList<RatePlan> GetRatesPlan();

        RatePlan GetById(int id);
    }
}
