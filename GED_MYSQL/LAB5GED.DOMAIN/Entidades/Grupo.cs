using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_grupo")]
    public class Grupo
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("nome_grupo")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Nome do Grupo")]
        public string NomeGrupo { get; set; }


        [Column("descricao_grupo")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Descrição")]
        public string DescricaoGrupo { get; set; }

        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [InverseProperty("Grupos")]
        public virtual List<Acao> Acoes { get; set; }

      
    }
}
