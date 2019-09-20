using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlatPetWebApplicationAPI.Models
{
    public class PlatPetUsuario
    {
        public PlatPetUsuario()
        {
        }   
        [Key]
        public int IdUsuario { get; set; }
        public string UserUsuario { get; set; }
        public string PassUsuario { get; set; }
        public int StatusUsuario { get; set; }
        public string TipoUsuario { get; set; }
    
}
}
