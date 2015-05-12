using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_log")]
    public class Log
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public Int64 Registro { get; set; }

        [Column("data")]
        [Required(ErrorMessage="O log requer que uma data seja informada")]
        public DateTime Data { get; set; }

        [Column("acao")]
        [Required(ErrorMessage="É preciso informar a origem do log")]
        public string  Acao { get; set; }

        [Column("entidade")]
        public string Entidade { get; set; }

     
        [Column("usuario")]
        public string Usuario { get; set; }

        [Column("mensagem")]
        [Required(ErrorMessage="O log requer que uma mensagem seja passada")]
        public string Mensagem { get; set; }

  

        public Log()
        {
            this.Data = DateTime.Now;
        }

        public Log(string _usuario, string _mensagem)
        {
            this.Data = DateTime.Now;
            this.Usuario = _usuario;
            this.Mensagem = _mensagem;
        }

        public Log(string _acao, string _entidade, string _usuario, string _mensagem)
        {
            this.Data = DateTime.Now;
            this.Acao = _acao;
            this.Entidade = _entidade;
            this.Usuario = _usuario;
            this.Mensagem = _mensagem;
        }
    }
}
