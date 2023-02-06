using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TravelLibrary.Server.Models.dbTravelLIB
{
    [Table("autores_has_libros", Schema = "dbo")]
    public partial class AutoresHasLibro
    {
        [Key]
        [Required]
        public int autores_id { get; set; }

        [Key]
        [Required]
        public int libros_ISBN { get; set; }

        public Autore Autore { get; set; }

        public Libro Libro { get; set; }

    }
}