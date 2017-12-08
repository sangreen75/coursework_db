using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModel.InputData
{
    public class Contact
    {
        [Key] public int Id { get; set; }
        public Client Client { get; }

        public Manager Manager { get; }

        public DateTime StartCallTime { get; }

        public DateTime EndCallTime { get; }

        public Contact(Client client, 
            Manager manager, 
            DateTime startCallTime, 
            DateTime endCallTime)
        {
            Client = client;
            Manager = manager;
            StartCallTime = startCallTime;
            EndCallTime = endCallTime;
        }
    }
}
