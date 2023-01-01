using Application.Contexts;
using Domain.Hr;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class HrContext : DbContext, IHrContext
    {
        public HrContext(DbContextOptions<HrContext> options):base(options)
        {

        }

        public DbSet<HrEmployee> HrEmployees { get ; set; }

        async Task<int> IHrContext.SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
