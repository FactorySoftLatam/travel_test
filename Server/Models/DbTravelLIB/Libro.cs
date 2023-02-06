using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TravelLibrary.Server.Models.dbTravelLIB
{
    [Table("libros", Schema = "dbo")]
    public partial class Libro
    {
        [Key]
        [Required]
        public int ISBN { get; set; }

        public int? editoriales_id { get; set; }

        [Required]
        public string titulo { get; set; }

        public string sinopsis { get; set; }

        public string n_paginas { get; set; }

        public ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }

        public Editoriale Editoriale { get; set; }

    }
}