using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Integracao
{
    public class Academico
    {
        public static List<Documento> DocumentosDoAluno(string _matricula)
        {

            return new DocumentoBO().DocumentosDeUmaMatricula(_matricula);

        }
    }
}
