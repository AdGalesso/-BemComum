using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using EZServiceLocation;
using System.Web.Http;

namespace br.com.bemcomum.api.Controllers
{
    public class DashboardController : ApiController
    {
        private IDashboardApp _app = null;

        public DashboardController()
        {
            _app = ServiceLocator.Current.GetService<IDashboardApp>();
        }

        [HttpGet]
        public Dashboard GetData()
        {
            return _app.GetData();
        }
    }
}
