using System.ComponentModel.DataAnnotations;

namespace IkeCode.Data
{
    public interface IIcModel<TUser>
        where TUser : IcUser
    {
        TUser Owner { get; }
        int OwnerId { get; }
    }

    public class IcModel<TUser> : IcBaseModel, IIcModel<TUser>
        where TUser : IcUser
    {
        [Required]
        public virtual TUser Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
