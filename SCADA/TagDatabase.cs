using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SCADA
{
    public class TagDatabase : DbContext
    {
        public DbSet<DbTag> Tags { get; set; }

    }

    public class DbTag
    {
        [Key]
        public int Id { get; set; }

        public Tag tag { get; set; }
        public DateTime timeStamp { get; set; }
        public double value { get; set; }
        public DbTag() { }
        public DbTag(Tag t, DateTime dateTime, double val)
        {
            tag = t;
            timeStamp = dateTime;
            value = val;
        }
    }

}