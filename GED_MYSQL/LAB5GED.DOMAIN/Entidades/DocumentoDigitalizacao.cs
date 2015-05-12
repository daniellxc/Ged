using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_documento_digitalizacao")]
    public class DocumentoDigitalizacao
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("nome")]
        [StringLength(60)]
        public string Nome { get; set; }

        [Column("dados")]
        [Required(ErrorMessage="Campo obrigatório")]
        public byte[] Dados { get; set; }

        [Column("extensao")]
        [StringLength(10)]
        [Required(ErrorMessage="Campo obrigatório")]
        public string Extensao { get; set; }

        [Column("DOCUMENTO")]
        [Required(ErrorMessage="Campo obrigatório")]
        public int Documento { get; set; }

        [Column("observacao")]
        public string Observacao { get; set; }

        [Column("ordem")]
        public string Ordem { get; set; }

        #region ForeignKeys

        [ForeignKey("Documento")]
        public virtual Documento FK_Documento { get; set; }
        #endregion

        public DocumentoDigitalizacao()
        {

        }
    }
}
