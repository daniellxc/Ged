using LAB5GED.DOMAIN.Entidades.Seguranca;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.AppContext
{
    public class SegurancaContexto:DbContext
    {
              #region DbSets

       public DbSet<Usuario> Usuarios { get; set; }
     
      


 
        #endregion

        public SegurancaContexto() : base("Seguranca") { }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
        
            base.OnModelCreating(modelBuilder);
            base.Configuration.LazyLoadingEnabled = true;
           
        }
    }
}
