﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.domain.Entities
{
    public class Admin : User
    {
        public DateTime LastAccess { get; set; }

        public override void Login()
        {
            LastAccess = DateTime.Now;
            base.GetPhoto();
        }
    }
}
