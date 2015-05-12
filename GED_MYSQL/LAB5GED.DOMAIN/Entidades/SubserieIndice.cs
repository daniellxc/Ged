using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_subserie_indice")]
    public class SubserieIndice
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("nome_indice")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Nome do Índice")]
        [StringLength(50)]
        public string NomeIndice { get; set; }

        [Column("descricao_indice")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Descrição do Índice")]
        [StringLength(255)]
        public string DescricaoIndice { get; set; }

        [Column("SUBSERIE")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Subsérie do Índice")]
        public int Subserie { get; set; }

        [Column("obrigatorio")]
        [Display(Name="Obrigatório")]
        [Required(ErrorMessage = "campo obrigatório")]
        public bool Obrigatorio { get; set; }

        #region ForeignKey

        [ForeignKey("Subserie")]
        public virtual Subserie FK_Subserie { get; set; }

        #endregion

        public SubserieIndice()
        {

        }
    }
}
