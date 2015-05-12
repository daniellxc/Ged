using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_classe")]
    public class Classe
    {
        [Column("registro")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Registro { get; set; }

        [StringLength(3)]
        [Column("id_classe")]
        [Display(Name="ID da Classe")]
        [Required(ErrorMessage="campo obrigatório")]
        public string Id_classe { get; set; }


        [Column("rotulo_classe")]
        [Required(ErrorMessage = "campo obrigatório")]
        public string Rotulo { get; set; }

        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
        public bool Ativo { get; set; }

        [Column("data_abertura")]
        [Required(ErrorMessage="campo obrigatório")]
        public DateTime DataAbertura { get; set; }



    
        public Classe()
        {
           
        }
    }
}
