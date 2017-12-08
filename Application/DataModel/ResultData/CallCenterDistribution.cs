using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModel.ResultData
{
    public class CallCenterDistribution
    {
        #region Properties
        public CallCenter CallCenter { get; private set; }
        public DateTime StartWork { get; private set; } = DateTime.MaxValue;
        public DateTime EndWork { get; private set; }
        public int CountCalls { get; private set; }
        private int plannedAmount;
        public int PlannedAmount
        {
            get
            {
                var countOfWorking = (StartWork - EndWork).Hours;
                return plannedAmount
                    - 500 * countOfWorking * (LowSkillManagerCount + 2 * MediumSkillManagerCount + 3 * HighSkillManagerCount);
            }
            private set
            {
                plannedAmount = value;
            }
        }
        public int LowSkillManagerCount { get; private set; }
        public int MediumSkillManagerCount { get; private set; }
        public int HighSkillManagerCount { get; private set; }
        #endregion

        private Dictionary<int, Action> qulification;
        public CallCenterDistribution() { Init(); }

        public CallCenterDistribution(CallCenter callCenter)
        {
            CallCenter = callCenter;
            Init();
        }

        public CallCenterDistribution(AppointmentCall appointmentCall)
        {
            CallCenter = appointmentCall.CallCenter;
            Init();
            AddNewCall(appointmentCall);
        }

        public void AddNewCall(AppointmentCall appointmentCall)
        {
            CountCalls++;
            PlannedAmount += appointmentCall.Client.Income;
            if (appointmentCall.StartCallTime < StartWork)
                StartWork = Round(appointmentCall.StartCallTime, false);

            if (appointmentCall.EndCallTime > EndWork)
                EndWork = Round(appointmentCall.EndCallTime, true);

            if (qulification.ContainsKey(appointmentCall.Manager.Qualification))
                qulification[appointmentCall.Manager.Qualification]();
        }

        private DateTime Round(DateTime date, bool toUpper)
        {
            double divider = 60 * 60;
            double sec = date.Ticks / 10000000;
            var newSec = (toUpper ? Math.Ceiling(sec / divider) : Math.Floor(sec / divider)) * divider;
            var newTicks = (long)newSec * 10000000;
            return new DateTime(newTicks);
        }

        private void Init()
        {
            qulification = new Dictionary<int, Action>()
            {
                [1] = () => LowSkillManagerCount++,
                [2] = () => MediumSkillManagerCount++,
                [3] = () => HighSkillManagerCount++
            };
        }
    }
}
