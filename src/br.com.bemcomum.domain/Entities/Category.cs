﻿using System;

namespace br.com.bemcomum.domain.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
