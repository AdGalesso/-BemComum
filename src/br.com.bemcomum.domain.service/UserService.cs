using System;
using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.service.contracts;
using br.com.bemcomum.infra.data.contracts;

namespace br.com.bemcomum.domain.service
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository repository) {

        }

        public User Login(User user)
        {
            throw new NotImplementedException();
        }
    }
}
