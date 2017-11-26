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
        [Key] public int Id { get; private set; }

        public CallCenter CallCenter { get; private set; }

        public int Qualification { get; private set; }

        public int Effiency { get; private set; }

        public DateTime StartWorkTime { get; private set; }

        public DateTime EndWorkTime { get; private set; }

        public int Salary { get; private set; }

        public Manager(int id,
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
    }
}
