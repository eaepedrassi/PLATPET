using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models
{
    public class Usuario
    {

        public int IdUsuario { get; set; }
        public string UserUsuario { get; set; }
        public string PassUsuario { get; set; }
        public int StatusUsuario { get; set; }
        public int TipoUsuario { get; set; }

    }
}