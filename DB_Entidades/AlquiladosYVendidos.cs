using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Entidades
{
    public class AlquiladosYVendidos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Clientes Clientes { get; set; }
        public int IdLibro { get; set; }
        [ForeignKey("IdLibro")]
        public virtual Libros Libros { get; set; }
        public int Estado { get; set; }
        public DateTime Desde { get; set; }
        public DateTime? Hasta { get; set; }

        


    }
}
