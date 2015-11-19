using br.com.bemcomum.application;
using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.service.contracts;
using EZServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.iof.Map
{
    public class DashboardMap : ServiceMap
    {
        public override void Load()
        {
            For<IDashboardApp>().Use<DashboardApp>(
                new ConstructorDependency(
                    typeof(ICategoryService),
                    typeof(IInstitutionService),
                    typeof(IDonorService)
                ));
        }
    }
}
