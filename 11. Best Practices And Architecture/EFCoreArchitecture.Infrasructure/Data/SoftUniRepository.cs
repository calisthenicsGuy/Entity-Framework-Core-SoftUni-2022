using EFCoreArchitecture.Infrastructure.Data.Common;

namespace EFCoreArchitecture.Infrastructure.Data
{
    public class SoftUniRepository : Repository, ISoftUniRepository
    {
        public SoftUniRepository(SoftUniContext context)
        {
            this.Context = context;
        }
    }
}
