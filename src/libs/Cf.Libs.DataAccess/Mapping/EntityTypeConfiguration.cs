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
            if (prop != null && prop.GetType().ToString() == typeof(int).ToString())
            {
                builder.HasKey("Id");
                builder.Property("Id").HasColumnType("integer").ValueGeneratedOnAdd();
                return;
            }

            prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.CreateDate));
            if (prop != null)
            {
                builder.Property(nameof(IChangeableEntity.CreateDate)).HasColumnType("timestamp");
                return;
            }

            prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.CreateUserId));
            if (prop != null)
            {
                builder.Property(nameof(IChangeableEntity.CreateUserId)).HasColumnType("nvarchar(50)");
                return;
            }

            prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.ModifiedDate));
            if (prop != null)
            {
                builder.Property(nameof(IChangeableEntity.ModifiedDate)).HasColumnType("timestamp");
                return;
            }


            prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.ModifyUserId));
            if (prop != null)
            {
                builder.Property(nameof(IChangeableEntity.ModifyUserId)).HasColumnType("nvarchar(50)");
                return;
            }

            prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.ModifyUserId));
            if (prop != null)
            {
                builder.Property(nameof(IChangeableEntity.ModifyUserId)).HasColumnType("nvarchar(50)");
                return;
            }

            prop = typeof(TEntity).GetProperty(nameof(IDeleteEntity.IsDeleted));
            if (prop != null)
            {
                builder.Property(nameof(IChangeableEntity.ModifyUserId)).HasColumnType("boolean");
                return;
            }

            prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.UpdatedToken));
            if(prop != null)
            {
                builder.Property(nameof(IChangeableEntity.UpdatedToken)).HasColumnType("nvarchar(50)");
                builder.Property(nameof(IChangeableEntity.UpdatedToken)).IsConcurrencyToken();
                return;
            }

            prop = typeof(TEntity).GetProperty("Note");
            if (prop != null)
            {
                builder.Property("Note").HasColumnType("nvarchar(300)");
                return;
            }
        }

        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}