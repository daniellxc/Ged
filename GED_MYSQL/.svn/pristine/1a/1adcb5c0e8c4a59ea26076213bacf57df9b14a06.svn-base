using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_acao")]
    public class Acao
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("nome_acao")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Ação")]
        public string NomeAcao { get; set; }

        [Column("descricao_acao")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Descrição da Ação")]
        public string DescricaoAcao { get; set; }

        [InverseProperty("Acoes")]
        public virtual List<Grupo> Grupos { get; set; }
        public Acao()
        {

        }
    }
}
