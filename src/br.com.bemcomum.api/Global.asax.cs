using br.com.bemcomum.iof;
using System.Web.Http;

namespace br.com.bemcomum.api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bootstrap.Go();
        }
    }
}