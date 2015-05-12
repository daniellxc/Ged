using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Acessorio
{
    public class Erros
    {
        public class ErroDeValidacao : DbEntityValidationException
        {
            public ErroDeValidacao(DbEntityValidationException vldEx)
                : base(ExtrairErrosValidationResult(vldEx))
            {

            }


        }

        public class ErroGeral : Exception
        {
            public ErroGeral(string msgErro) : base(msgErro) { }
        }



        private static string ExtrairErrosValidationResult(DbEntityValidationException vldEx)
        {
            string retorno = "";

            foreach (DbEntityValidationResult vr in vldEx.EntityValidationErrors)
            {
                foreach (DbValidationError ve in vr.ValidationErrors)

                    retorno += "Campo: " + ve.PropertyName + " [ Erro: " + ve.ErrorMessage + " ]<br>";
            }

            return retorno;
        }
    }
}
