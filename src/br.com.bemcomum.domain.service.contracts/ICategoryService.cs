using br.com.bemcomum.domain.Entities;

namespace br.com.bemcomum.domain.service.contracts
{
    public interface ICategoryService : IBaseService<Category>
    {
        int Count();
    }
}
