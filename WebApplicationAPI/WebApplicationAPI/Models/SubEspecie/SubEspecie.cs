using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.SubEspecie
{
    public class SubEspecie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSubEspecie { get; set; }
        public int IdEspecie { get; set; }
        public string NomeSubEspecie { get; set; }
    }
}