using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlatPetWebApplicationAPI.Models
{
    public class PlatPetContext : DbContext
    {

        public PlatPetContext(DbContextOptions<PlatPetContext> options)
            : base(options)
        {

        }

        public DbSet<PlatPetUsuario> PlatPetUsuarios { get; set; }
        
    }
}
