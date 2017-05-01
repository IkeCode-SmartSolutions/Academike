using IkeCode.Data;

namespace Academike.Data
{
    public class Repository<TEntity> : IcRepository<TEntity, AcademikeContext>
        where TEntity : IcBaseModel
    {
        public Repository(AcademikeContext context)
            : base(context)
        {

        }
    }
}
