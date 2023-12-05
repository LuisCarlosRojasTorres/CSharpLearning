using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dummy_ASPNET_CAM.Models;

namespace Dummy_ASPNET_CAM.Data
{
    public class Dummy_ASPNET_CAMContext : DbContext
    {
        public Dummy_ASPNET_CAMContext (DbContextOptions<Dummy_ASPNET_CAMContext> options)
            : base(options)
        {
        }

        public DbSet<Dummy_ASPNET_CAM.Models.Movie> Movie { get; set; } = default!;
    }
}
