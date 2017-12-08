using Application.DataModel.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModel.Distributor
{
    public class CallDistributor
    {
        private Dictionary<int, CallCenterDistribution> callCenterAllocation = new Dictionary<int, CallCenterDistribution>();

        public IEnumerable<AppointmentCall> AppointCalls()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CallCenterDistribution> UpdateStats()
        {
            throw new NotImplementedException();
        }

    }
}
