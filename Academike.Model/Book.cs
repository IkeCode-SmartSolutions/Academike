using IkeCode.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academike.Model
{
    public class Book : IcModel
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
    }
}