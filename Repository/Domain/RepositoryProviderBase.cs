using Repository.Interface;

namespace Repository.Domain
{
    public abstract class RepositoryProviderBase
    {
        protected abstract IRepositoryContext Context();
    }
}
