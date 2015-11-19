using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.service.contracts;

namespace br.com.bemcomum.application
{
    public class CategoryApp : BaseApp<Category>, ICategoryApp
    {
        public CategoryApp(ICategoryService service)
            : base(service)
        {

        }
    }
}
