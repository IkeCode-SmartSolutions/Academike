using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IkeCode.Data
{
    public interface IIcBaseModel
    {
        int Id { get; }
        DateTime CreatedAt { get; }
        byte[] LastUpdate { get; }
    }

    public class IcBaseModel : IIcBaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Timestamp]
        public byte[] LastUpdate { get; set; }
    }
}
