using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Entidades
{
    public class Libros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Genero { get; set; }
        public int Estado { get; set; }
        public double Precio { get; set; }
        public string Otros { get; set; }

    }
}
