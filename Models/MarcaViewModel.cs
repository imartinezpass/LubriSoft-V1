﻿using System.ComponentModel.DataAnnotations;

namespace LubriSoft.Models
{
    public class MarcaViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}