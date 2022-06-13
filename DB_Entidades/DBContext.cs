using Microsoft.EntityFrameworkCore;

namespace DB_Entidades
{
    public class DBContext :DbContext
    {

        public DBContext( DbContextOptions<DBContext> options)
            : base(options)
        {

        }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Libros> Libros { get; set; }
        public DbSet<AlquiladosYVendidos> AlquiladosYVendidos { get; set; }

    }
}