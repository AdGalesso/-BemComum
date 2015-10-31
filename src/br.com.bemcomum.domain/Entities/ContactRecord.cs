using br.com.bemcomum.domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.domain.Entities
{
    public class ContactRecord : Records
    {
        public ContactStatus Status { get; set; }
    }
}
