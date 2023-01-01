using Domain.Hr;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contexts
{
    public interface IHrContext
    {
        public DbSet<HrEmployee> HrEmployees { get; set; }
        Task<int> SaveChanges();
    }
}
