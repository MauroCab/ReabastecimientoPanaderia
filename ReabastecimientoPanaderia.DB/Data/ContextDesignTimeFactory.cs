using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.DB.Data
{
    public class ContextDesignTimeFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            // Construye las opciones. Aquí debes usar la misma cadena de conexión
            // que usarías en tu aplicación real (pero puede ser una específica para diseño).
            var optionsBuilder = new DbContextOptionsBuilder<Context>();

            // EJEMPLO CON SQL SERVER:
            // Reemplaza "Server=...;Database=...;..." con tu cadena real.
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ReabastecimientoPanaderia;Trusted_Connection=True;MultipleActiveResultSets=true");

            // EJEMPLO CON SQLite:
            // optionsBuilder.UseSqlite("Data Source=MiBaseDeDatos.db");

            return new Context(optionsBuilder.Options);
        }
    }
}