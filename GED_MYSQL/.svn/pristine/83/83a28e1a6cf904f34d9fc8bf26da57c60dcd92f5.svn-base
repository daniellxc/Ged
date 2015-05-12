using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_documento_tipo_manipulacao")]
    public class DocumentoTipoManipulacao
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("descricao_acao")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Nome da Ação")]
        [StringLength(50)]
        public string DescricaoAcao { get; set; }

        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
        public bool Ativo { get; set; }

        public DocumentoTipoManipulacao()
        {
                
        }
    }
}
