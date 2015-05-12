using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_documento_manipulacao")]
    public class DocumentoManipulacao
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("data")]
        [Required(ErrorMessage="campo obrigatório")]
        public DateTime Data { get; set; }

        [Column("DOCUMENTO")]
        [Required(ErrorMessage="campo obrigatório")]
        public int Documento { get; set; }

        [Column("TIPO_MANIPULACAO")]
        [Required(ErrorMessage="campo obrigatório")]
        public int TipoManipulacao { get; set; }

        [Column("USUARIO")]
        [Required(ErrorMessage = "campo obrigatório")]
        public int Usuario { get; set; }

        #region ForeignKey

        [ForeignKey("Documento")]
        public virtual Documento  FK_Documento { get; set; }

        [ForeignKey("TipoManipulacao")]
        public virtual DocumentoTipoManipulacao FK_TipoManipulacao { get; set; }

        [ForeignKey("Usuario")]
        public virtual Usuario FK_Usuario { get; set; }

        #endregion

        public DocumentoManipulacao()
        {

        }
    }
}
