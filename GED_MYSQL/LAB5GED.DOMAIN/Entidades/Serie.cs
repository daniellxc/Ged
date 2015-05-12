using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_serie")]
    public class Serie
    {
        [Column("registro")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Registro { get; set; }

        [StringLength(3)]
        [Column("id_serie")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="ID da Série")]
    
        public string Id_serie { get; set; }


        [Column("rotulo_serie")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name="Rótulo")]
        public string Rotulo_serie { get; set; }

        [Column("SUBCLASSE")]
        [Required(ErrorMessage="campo obrigatório")]
        public int Subclasse { get; set; }

        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
        public bool Ativo { get; set; }

    #region ForeignKey

        [ForeignKey("Subclasse")]
        public virtual Subclasse FK_Subclasse{ get; set; }

    #endregion

        public Serie()
        {

        }

        public Serie(string _rotulo)
        {
            this.Rotulo_serie = _rotulo;
        }






    }
}
