using APICliente.Models;
using Microsoft.EntityFrameworkCore;

namespace APICliente.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }

        public DbSet<Cliente> Cliente { get; set; }


        //Es necesario instalar el paquete de Nuget:
        //MicrosoftEntityFrameworCore, MicrosoftEntityFrameworCore.SQLServer, MicrosoftEntityFrameworCore.Tools
        //Se aplica para cada solución


    }
}
