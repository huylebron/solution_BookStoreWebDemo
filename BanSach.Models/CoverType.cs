﻿using System.ComponentModel.DataAnnotations;

namespace BanSach.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
