using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_prazo_guarda")]
    public class PrazoGuarda
    {
        [Column("registro")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Registro { get; set; }

        [Column("corrente")]
        [Required(ErrorMessage="campo obrigatório")]
        public string Corrente { get; set; }

        [Column("intermediario")]
        [Required(ErrorMessage = "campo obrigatório")]
        public string Itermediario { get; set; }

        [Column("permanente")]
        [Required(ErrorMessage = "campo obrigatório")]
        public bool Permanente { get; set; }

        [Column("SUBSERIE")]
        [Required(ErrorMessage="campo obrigatório")]
        public int Subserie { get; set; }


        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
        public bool Ativo { get; set; }


        #region ForeignKeys

        [ForeignKey("Subserie")]
        public virtual Subserie  FK_Subserie { get; set; }

        #endregion
        public PrazoGuarda()
        {

        }
    }
}
