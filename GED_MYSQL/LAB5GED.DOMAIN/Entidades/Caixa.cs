using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_caixa")]
    public class Caixa
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("id_caixa")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Identificação")]
        [StringLength(100)]
        public string IdCaixa { get; set; }

        [Column("descricao")]
        [DataType(DataType.Text)]
        [Display(Name = "Descrição")]
        [StringLength(255)]
        public string Descricao { get; set; }

        [Column("PRATELEIRA")]
        [Display(Name = "Prateleira")]
        [Required(ErrorMessage="campo obrigatório")]
        public int Prateleira { get; set; }


        [Column("SUBSERIE")]
        [Display(Name = "Subsérie")]
        [Required(ErrorMessage = "campo obrigatório")]
        public int Subserie { get; set; }


        [Column("aberta")]
        [Required(ErrorMessage="campo obrigatório")]
        public bool Aberta { get; set; }

        public virtual List<Documento> Documentos { get; set; }

        #region ForeignKeys

        [ForeignKey("Prateleira")]
        public virtual Prateleira FK_Prateleira { get; set; }

        [ForeignKey("Subserie")]
        public virtual Subserie FK_Subserie { get; set; }

        #endregion


        public Caixa()
        {

        }

    }
}
