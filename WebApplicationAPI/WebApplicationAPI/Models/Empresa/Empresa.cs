using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.Empresa
{
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpresa { get; set; }
        public int IdUsuario { get; set; }
        public string CNPJEmpresa { get; set; }
        public string NFantasiaEmpresa { get; set; }
        public string RazaoEmpresa { get; set; }
        public string EmailEmpresa { get; set; }
        public string TelEmpresa { get; set; }
        public string EndEmpresa { get; set; }

    }
}