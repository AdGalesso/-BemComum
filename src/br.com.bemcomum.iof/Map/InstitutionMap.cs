using br.com.bemcomum.application;
using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.service;
using br.com.bemcomum.domain.service.contracts;
using br.com.bemcomum.infra.data.contracts;
using br.com.bemcomum.infra.data.repositories;
using EZServiceLocation;

namespace br.com.bemcomum.iof.Map
{
    public class InstitutionMap : ServiceMap
    {
        public override void Load()
        {
            For<IInstitutionRepository>().Use<InstitutionRepository>();
            For<IInstitutionService>().Use<InstitutionService>(new ConstructorDependency(typeof(IInstitutionRepository)));
            For<IInstitutionApp>().Use<InstitutionApp>(new ConstructorDependency(typeof(IInstitutionService)));
        }
    }
}
