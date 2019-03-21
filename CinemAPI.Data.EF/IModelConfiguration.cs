using System.Data.Entity;

namespace CinemAPI.Data.EF
{
    public interface IModelConfiguration
    {
        void Configure(DbModelBuilder modelBuilder);
    }
}
