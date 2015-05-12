using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB5GED.MVC.Acessorio
{
    public class Seguranca
    {
        /// <summary>
        /// Retorna NULL se nenhum usuário estiver logado;
        /// </summary>
        /// <returns></returns>
        public static Usuario UsuarioLogado()
        {
            try
            {
                return new UsuarioBO().GetByRegistro(int.Parse(HttpContext.Current.User.Identity.Name));
            }
            catch
            {
                return null;
            }
        }

        public string getMD5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}