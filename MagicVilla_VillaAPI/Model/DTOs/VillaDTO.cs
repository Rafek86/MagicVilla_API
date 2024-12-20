﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Model.DTOs
{
    public class VillaDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
