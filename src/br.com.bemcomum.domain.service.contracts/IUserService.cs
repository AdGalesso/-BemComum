using br.com.bemcomum.domain.Entities;

namespace br.com.bemcomum.domain.service.contracts
{
    public interface IUserService 
    {
        User Login(User user);
    }
}
