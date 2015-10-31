using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.service.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.application
{
    public class UserApp : IUserApp
    {
        public UserApp(IUserService service) {

        }

        public User Login(User user)
        {
            throw new NotImplementedException();
        }
    }
}
