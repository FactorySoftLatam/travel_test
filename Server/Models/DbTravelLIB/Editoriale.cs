using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TravelLibrary.Server.Models.dbTravelLIB
{
    [Table("editoriales", Schema = "dbo")]
    public partial class Editoriale
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string sede { get; set; }

        public ICollection<Libro> Libros { get; set; }

    }
}