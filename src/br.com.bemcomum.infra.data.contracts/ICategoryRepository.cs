using br.com.bemcomum.domain.Entities;

namespace br.com.bemcomum.infra.data.contracts
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        int Count();
    }
}
