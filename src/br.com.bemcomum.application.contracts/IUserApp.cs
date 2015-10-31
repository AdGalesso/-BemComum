using br.com.bemcomum.domain.Entities;

namespace br.com.bemcomum.application.contracts
{
    public interface IUserApp
    {
        User Login(User user);
    }
}