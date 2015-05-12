using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_prateleira")]
    public class Prateleira
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("numero")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Número da Prateleira")]
        public int Numero { get; set; }

        [Column("ESTANTE")]
        [Required(ErrorMessage = "campo obrigatório")]
        public int Estante { get; set; }

        [Column("descricao")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
        public bool Ativo { get; set; }

        #region Foreign Keys

        [ForeignKey("Estante")]
        public virtual Estante FK_Estante { get; set; }

        #endregion

        public Prateleira()
        {

        }

    }
}
