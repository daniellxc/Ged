using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_subclasse")]
     public class Subclasse
    {
        [Column("registro")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Registro { get; set; }

        [StringLength(3)]
        [Column("id_subclasse")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Id Subclasse")]
        public string Id_subclasse
        {
            get;
            set;

        }


        [Column("rotulo_subclasse")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Rótulo")]
        public string Rotulo_subclasse { get; set; }

        
        [Column("CLASSE")]
        [Required(ErrorMessage="campo obrigatório")]
        public  int Classe { get; set; }


        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
 
        public bool Ativo { get; set; }

        #region ForeignKeys

        [ForeignKey("Classe")]
        public virtual Classe FK_Classe { get; set; }

        #endregion

        public Subclasse()
        {

        }
    }
}
