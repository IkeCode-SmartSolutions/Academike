using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkeCode.Data
{
    public static class ExtensionMethods
    {
        public static T Clone<T>(this T toClone)
            where T : class
        {
            string tmp = JsonConvert.SerializeObject(toClone);
            return JsonConvert.DeserializeObject<T>(tmp);
        }

        public static void ConfigureIcModel<T>(this EntityTypeBuilder<T> entity, Action<EntityTypeBuilder<T>> configure = null)
            where T : IcBaseModel
        {
            entity
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getutcdate()");

            entity.HasKey(i => i.Id);

            entity.Configure(configure);
        }

        public static void Configure<T>(this EntityTypeBuilder<T> entity, Action<EntityTypeBuilder<T>> configure = null)
            where T : class
        {
            configure?.Invoke(entity);
        }
    }
}
