using IkeCode.Data;
using System.ComponentModel.DataAnnotations;

namespace Academike.Model
{
    public class Note : IcModel<AcademikeUser>
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
        
        public string Content { get; set; }

        public virtual Book Book { get; set; }
    }
}
