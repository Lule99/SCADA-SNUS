﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SCADA
{
    public class UserDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}