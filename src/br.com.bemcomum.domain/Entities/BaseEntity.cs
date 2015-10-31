using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.domain.Entities
{
    public abstract class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime Save { get; set; }

        public DateTime Update { get; set; }
    }
}
