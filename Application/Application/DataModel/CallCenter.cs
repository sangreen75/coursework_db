using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModel
{
    public class CallCenter
    {
        [Key]
        public int Id { get; private set; }

        public CallCenter(int id)
        {
            Id = id;
        }

        public CallCenter() { }
    }
}
