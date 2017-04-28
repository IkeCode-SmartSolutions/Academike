using IkeCode.Data;
using System;
using System.Collections.Generic;
using System.Text;

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
