using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_estante")]
    public  class Estante
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("numero")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Número da Estante")]
        public int Numero { get; set; }

        [Column("CORREDOR")]
        [Required(ErrorMessage = "campo obrigatório")]
        public int Corredor { get; set; }

        [Column("descricao")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
        public bool Ativo { get; set; }

        #region Foreign Keys

        [ForeignKey("Corredor")]
        public virtual Corredor FK_Corredor { get; set; }

        #endregion

        public Estante()
        {

        }

    }
}
