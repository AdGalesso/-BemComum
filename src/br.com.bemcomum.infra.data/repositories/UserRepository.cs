using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.infra.data.contracts;
using System;

namespace br.com.bemcomum.infra.data.repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository() {}

        public User Login(User user)
        {
            throw new NotImplementedException();
        }
    }
}
