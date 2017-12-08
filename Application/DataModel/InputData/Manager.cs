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

        public float Effiency { get; private set; }

        public DateTime StartWorkTime { get; private set; }

        public DateTime EndWorkTime { get; private set; }

        public int Salary { get; private set; }

        public DateTime? LastCall => (Calls.Count == 0) ? new DateTime?() : Calls.Peek().EndCallTime;

        public bool CanWork(DateTime time) => StartWorkTime <= time && time <= EndWorkTime && FreeTime(time);

        private bool FreeTime(DateTime time)
        {
            return (Calls.Count == 0 || Calls.Peek().EndCallTime < time);
        }

        private Queue<AppointmentCall> Calls { get; set; }
        #endregion

        #region Constructor
        public Manager(
            int id,
            CallCenter callCenter,
            int qualification,
            float effiency,
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
            Calls = new Queue<AppointmentCall>();
        }

        public Manager() { }
        #endregion

        public AppointmentCall RegisterCall(Client client, DateTime startCall, DateTime endCall)
        {
            if (client == null)
                throw new ArgumentNullException("Client");
            if (!CheckCorrectTime(startCall, endCall))
                return null;
            var appointCall = new AppointmentCall(client, this, this.CallCenter, startCall, endCall);
            Calls.Enqueue(appointCall);
            return appointCall;
        }

        private bool CheckCorrectTime(DateTime startCall, DateTime endCall)
        {
            return (CanWork(startCall) && CanWork(endCall) && startCall < endCall);
        }
    }
}
