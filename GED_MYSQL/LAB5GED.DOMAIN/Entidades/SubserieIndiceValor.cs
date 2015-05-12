using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_subserie_indice_valor")]
    public class SubserieIndiceValor
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("INDICE")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Índice")]
        public int Indice { get; set; }

        [Column("DOCUMENTO")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Documento")]
        public int Documento { get; set; }

        [Column("valor")]
        [Required(ErrorMessage = "campo obrigatório")]
        public string Valor { get; set; }

        #region ForeigKeys


        [ForeignKey("Indice")]
        public virtual SubserieIndice FK_SubserieIndice { get; set; }

        [ForeignKey("Documento")]
        public virtual Documento FK_Documento { get; set; }

        #endregion

        public SubserieIndiceValor()
        {

        }

        public SubserieIndiceValor(int _documento, int _subserieIndice, string _valor)
        {
            this.Documento = _documento;
            this.Indice = _subserieIndice;
            this.Valor = _valor;
        }
    }
}
