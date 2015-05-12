using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_documento_caixa")]
    public class DocumentoCaixa
    {
        [Key]
        [Column(Order=1)]
        public int DOCUMENTO { get; set; }

        [Key]
        [Column(Order=2)]
        public int CAIXA { get; set; }

        [ForeignKey("DOCUMENTO")]
        public virtual Documento FK_Documento { get; set; }

        [ForeignKey("CAIXA")]
        public virtual Caixa FK_Caixa { get; set; }

        public DocumentoCaixa()
        {

        }
    }
}
