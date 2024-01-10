using FleetProvider.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FleetProvider.Infrastructure.EntityConfigurations
{
    public abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id);

            ConfigureDerived(builder);
        }

        public abstract void ConfigureDerived(EntityTypeBuilder<TEntity> builder);

        private static readonly JsonSerializer Serializer = new JsonSerializer
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver()
        };

        internal static string Serialize<T>(T obj)
        {
            using (var writer = new StringWriter())
            {
                Serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        internal static T Deserialize<T>(string json)
        {
            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return Serializer.Deserialize<T>(jsonReader)!;
            }
        }
    }
}