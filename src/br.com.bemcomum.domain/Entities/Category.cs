﻿using br.com.bemcomum.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.domain.Entities
{
    public class Category : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime Save { get; set; }

        public DateTime Update { get; set; }
    }
}
