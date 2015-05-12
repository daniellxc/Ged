using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Acessorio
{
    public class UsoGeral
    {
        /// <summary>
        /// Retorna a string informada sem acentos.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoverAcentos(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            else
            {
                byte[] bytes = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(input);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }
    }
}
