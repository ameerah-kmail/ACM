using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace samuraiApp.Data
{
    public class SamuraiContextNoTracking: SamuraiContext
    {
        public SamuraiContextNoTracking(DbContextOptions<SamuraiContext> options)
            : base(options)
            
        {
            base.ChangeTracker.QueryTrackingBehavior
             =QueryTrackingBehavior.NoTracking;
        }
    }
}
