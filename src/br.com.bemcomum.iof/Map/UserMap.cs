using System;
using EZServiceLocation;
using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.application;
using br.com.bemcomum.domain.service.contracts;
using br.com.bemcomum.domain.service;
using br.com.bemcomum.infra.data.contracts;
using br.com.bemcomum.infra.data.repositories;

namespace br.com.bemcomum.iof.Map
{
    public class UserMap : ServiceMap
    {
        public override void Load()
        {
            For<IUserRepository>().Use<UserRepository>();
            For<IUserService>().Use<UserService>(new ConstructorDependency(typeof(IUserRepository)));
            For<IUserApp>().Use<UserApp>(new ConstructorDependency(typeof(IUserService)));

            For<IDonorRepository>().Use<DonorRepository>();
            For<IDonorService>().Use<DonorService>(new ConstructorDependency(typeof(IDonorRepository)));
            For<IDonorApp>().Use<DonorApp>(new ConstructorDependency(typeof(IDonorService)));
        }
    }
}
