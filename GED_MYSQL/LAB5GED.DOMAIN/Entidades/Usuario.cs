using LAB5GED.DOMAIN.DAO.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_usuario")]
    public class Usuario
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("nome_usuario")]
        [StringLength(100)]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Nome")]
        public string NomeUsuario { get; set; }

        [Column("login")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Column("senha")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Column("data_cadastro")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name="Data de Cadastro")]
        public DateTime DataCadastro { get; set; }


        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
        public bool Ativo { get; set; }

      
        public virtual List<Grupo> Grupos{ get; set; }

        public Usuario()
        {

            
        }



    }
}
