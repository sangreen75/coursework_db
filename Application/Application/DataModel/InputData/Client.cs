using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModel.InputData
{
    public class Client
    {
        [Key] public int Id { get; private set; }

        public int Income { get; private set; }

        public int Region { get; private set; }

        public Client(int id, int income, int region)
        {
            Id = id;
            Income = income;
            Region = region;
        }
    }
}
