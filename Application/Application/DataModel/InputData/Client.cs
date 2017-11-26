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
        [Key]
        public int Id { get; private set; }

        public int Income { get; private set; }

        public string Region { get; private set; }

        public Client(int id, int income, string region)
        {
            Id = id;
            Income = income;
            Region = region;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Client)) return false;
            var client = obj as Client;
            return (this.Id == client.Id && Income == client.Income);
        }

        public override string ToString()
        {
            return $"ID {Id} | Income {Income} | Region {Region}";
        }
    }
}
