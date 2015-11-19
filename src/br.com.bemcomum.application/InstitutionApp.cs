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
    public class InstitutionApp : BaseApp<PublicInstitution>, IInstitutionApp
    {
        public InstitutionApp(IInstitutionService service) : 
            base (service)
        {

        }
    }
}
