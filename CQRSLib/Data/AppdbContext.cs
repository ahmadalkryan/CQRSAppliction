using CQRSLib.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLib.Data
{
   public class AppdbContext:DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> op):base(op)
        {

        }

        public virtual DbSet<Item> Items { get; set; }
    }
}
