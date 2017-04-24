using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IkeCode.Data
{
    public interface IIcModel
    {
        int Id { get; }
        DateTime CreatedAt { get; }
        IcUser Owner { get; }
        int OwnerId { get; }
    }

    public class IcModel : IIcModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Required]
        public IcUser Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
