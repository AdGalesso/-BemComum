using br.com.bemcomum.application;
using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.service;
using br.com.bemcomum.domain.service.contracts;
using br.com.bemcomum.infra.data.contracts;
using br.com.bemcomum.infra.data.repositories;
using EZServiceLocation;

namespace br.com.bemcomum.iof.Map
{
    public class CategoryMap : ServiceMap
    {
        public override void Load()
        {
            For<ICategoryRepository>().Use<CategoryRepository>();
            For<ICategoryService>().Use<CategoryService>(new ConstructorDependency(typeof(ICategoryRepository)));
            For<ICategoryApp>().Use<CategoryApp>(new ConstructorDependency(typeof(ICategoryService)));
        }
    }
}
