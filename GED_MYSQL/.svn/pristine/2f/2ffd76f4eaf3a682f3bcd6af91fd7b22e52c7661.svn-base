using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_tipo_destinacao_subserie")]
    public class TipoDestinacaoSubserie
    {
        [Column("registro")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Registro { get; set; }

        [Column("descricao")]
        [Required(ErrorMessage="campo obrigatório")]
        public string Descricao { get; set; }

        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
        public bool Ativo { get; set; }

        public TipoDestinacaoSubserie()
        {

        }
    }
}
