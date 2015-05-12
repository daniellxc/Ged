using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades.Seguranca
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cod_usuario")]
        public int Registro { get; set; }

        [Column("nome_usuario")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Usuário")]
        public string NomeUsuario { get; set; }

        [Column("login")]
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(20)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Column("senha")]
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Column("data_expira")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Data de Expiração")]
        [DataType(DataType.Date)]
        public DateTime DataExpira { get; set; }

        [Column("nao_expira")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Não Expira")]
        public bool NaoExpira { get; set; }

        [Column("nao_muda_senha")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Não Muda Senha")]
        public bool NaoMudaSenha { get; set; }

        public Usuario()
        {

        }


    }
}
