using Cf.Libs.Core.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Cf.Libs.DataAccess.Mapping
{
    public class EntityTypeConfiguration<TEntity> : IMappingConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            PropertyInfo prop = typeof(TEntity).GetProperty("Id");
            if (prop != null)
            {
                builder.HasKey("Id");

                if (prop.PropertyType.ToString() == typeof(int).ToString())
                {
                    builder.Property("Id").HasColumnType("integer").ValueGeneratedOnAdd();
                    builder.Property("Id").UseNpgsqlIdentityAlwaysColumn();
                }
            }

            prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.CreateDate));
            if (prop != null)
            {
                builder.Property(nameof(IChangeableEntity.CreateDate)).HasColumnType("timestamp");
            }

            prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.CreateUserId));
            if (prop != null)
            {
                builder.Property(nameof(IChangeableEntity.CreateUserId)).HasColumnType("varchar(50)");
            }

            prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.ModifiedDate));
            if (prop != null)
            {
                builder.Property(nameof(IChangeableEntity.ModifiedDate)).HasColumnType("timestamp");
            }

            prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.ModifyUserId));
            if (prop != null)
            {
                builder.Property(nameof(IChangeableEntity.ModifyUserId)).HasColumnType("varchar(50)");
            }

            prop = typeof(TEntity).GetProperty(nameof(IDeleteEntity.IsDeleted));
            if (prop != null)
            {
                builder.Property(nameof(IDeleteEntity.IsDeleted)).HasColumnType("boolean");
            }

            prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.UpdatedToken));
            if(prop != null)
            {
                builder.Property(nameof(IChangeableEntity.UpdatedToken)).HasColumnType("varchar(50)");
                builder.Property(nameof(IChangeableEntity.UpdatedToken)).IsConcurrencyToken();
            }

            prop = typeof(TEntity).GetProperty("Note");
            if (prop != null)
            {
                builder.Property("Note").HasColumnType("varchar(300)");
            }
        }

        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}