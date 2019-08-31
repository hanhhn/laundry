namespace Cf.Libs.Core.Infrastructure.Entity
{
    public interface IDeleteEntity
    {
        bool IsDeleted { get; }
        void Delete();
        void UnDelete();
    }
}