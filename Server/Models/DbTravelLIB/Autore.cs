using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TravelLibrary.Server.Models.dbTravelLIB
{
    [Table("autores", Schema = "dbo")]
    public partial class Autore
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string apellidos { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string autor { get; set; }

        public ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }

    }
}