﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    public class ApplicationResponse
    {


        [Required]
        [Key]
        public int TaskId { get; set; }
        [Required]

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public string Task { get; set; }

        public string DueDate { get; set; }
        [Required]
        public string Quadrant
        { get; set; }

        public bool Completed { get; set; }


    }
}
