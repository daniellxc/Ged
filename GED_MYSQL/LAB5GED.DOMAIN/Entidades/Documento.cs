using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_documento")]
    public class Documento
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        //[Column("dados")]
        //[Required(ErrorMessage="campo obrigatório")]
        //public byte[] Dados { get; set; }

        [Column("SUBSERIE")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Subsérie do Documento")]
        public int Subserie { get; set; }

        [Column("data_criacao")]
        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name="Data de Criação")]
        public DateTime DataCriacao { get; set; }
        
        [Column("CAIXA")]
        public int  Caixa { get; set; }

        [Column("descricao")]
        [Display(Name="Descrição do Documento")]
        [Required(ErrorMessage="campo obrigatório")]
        public string Descricao { get; set; }
        #region ForeignKey

        [ForeignKey("Subserie")]
        public virtual Subserie FK_Subserie { get; set; }

        [ForeignKey("Caixa")]
        public virtual Caixa FK_Caixa { get; set; }
        #endregion

        public Documento()
        {

        }

        public Documento(int Registro)
        {
            this.Registro = Registro;
        }

    }
}
