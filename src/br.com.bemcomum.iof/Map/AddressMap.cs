using br.com.bemcomum.application;
using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.service;
using br.com.bemcomum.domain.service.contracts;
using br.com.bemcomum.infra.data.contracts;
using br.com.bemcomum.infra.data.repositories;
using EZServiceLocation;

namespace br.com.bemcomum.iof.Map
{
    public class AddressMap : ServiceMap
    {
        public override void Load()
        {
            For<IAddressRepository>().Use<AddressRepository>();
            For<IAddressService>().Use<AddressService>(new ConstructorDependency(typeof(IAddressRepository)));
            For<IAddressApp>().Use<AddressApp>(new ConstructorDependency(typeof(IAddressService)));
        }
    }
}
