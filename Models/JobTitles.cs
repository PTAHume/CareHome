﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class JobTitles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobTitlesId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DefaultSalary { get; set; }

        public Departments Departments { get; set; }
    }
}