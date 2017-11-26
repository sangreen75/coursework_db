using Application.DataModel.ResultData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModel.InputData
{
    public class Manager
    {
        #region Properties
        [Key]
        public int Id { get; private set; }

        public CallCenter CallCenter { get; private set; }

        public int Qualification { get; private set; }

        public int Effiency { get; private set; }

        public DateTime StartWorkTime { get; private set; }

        public DateTime EndWorkTime { get; private set; }

        public int Salary { get; private set; }
        #endregion

        public bool CanWork(DateTime time) => StartWorkTime <= time && time <= EndWorkTime && FreeTime(time);

        private bool FreeTime(DateTime time)
        {
            return (Calls.Count == 0 || Calls.Peek().EndCallTime < time);
        }

        private Queue<AppointmentCall> Calls { get; set; }


        #region Constructor
        public Manager(
            int id,
            CallCenter callCenter,
            int qualification,
            int effiency,
            DateTime startWorkTime,
            DateTime endWorkTime,
            int salary)
        {
            Id = id;
            CallCenter = callCenter;
            Qualification = qualification;
            Effiency = effiency;
            StartWorkTime = startWorkTime;
            EndWorkTime = endWorkTime;
            Salary = salary;
        }
        #endregion

        public AppointmentCall RegisterCall(Client client, int id, DateTime startCall, DateTime endCall)
        {
            var appointCall = new AppointmentCall(client, this, this.CallCenter, startCall, endCall, id);
            Calls.Enqueue(appointCall);
            return appointCall;
        }
    }
}
