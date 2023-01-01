using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Hr
{
    public class HrEmployee : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
