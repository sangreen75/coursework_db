using Application.DataModel.InputData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModel.ResultData
{
    public class AppointmentCall
    {
        [Key]
        public int Id { get; private set; }

        public Client Client { get; private set; }

        public Manager Manager { get; private set; }

        public CallCenter CallCenter { get; private set; }

        public DateTime StartCallTime { get; private set; }

        public DateTime EndCallTime { get; private set; }

        public AppointmentCall(Client client,
            Manager manager,
            CallCenter callCenter,
            DateTime startCallTime,
            DateTime endCallTime,
            int id)
        {
            Client = client;
            Manager = manager;
            CallCenter = callCenter;
            StartCallTime = startCallTime;
            EndCallTime = endCallTime;
            Id = id;
        }
    }
}
