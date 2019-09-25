using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.Pessoa
{
    public class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPessoa { get; set; }
        public int IdUsuario { get; set; }
        public string NomePessoa { get; set; }
        public string SobrenomePessoa { get; set; }
        public string CPFPessoa { get; set; }
        public string EmailPessoa { get; set; }
        public string TelPessoa { get; set; }
        public string EndPessoa { get; set; }
    }
}