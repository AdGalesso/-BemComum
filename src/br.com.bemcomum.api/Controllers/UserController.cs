using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using EZServiceLocation;
using System;
using System.Web.Http;

namespace br.com.bemcomum.api.Controllers
{
    public class UserController : ApiController
    {
        private IUserApp app = null;

        public UserController()
        {
            app = ServiceLocator.Current.GetService<IUserApp>();
        }

        [HttpGet]
        public User Login(User user)
        {
            return app.Login(user);
        }
    }
}
