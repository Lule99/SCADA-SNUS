using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SCADA
{
    public class AlarmDB : DbContext
    {
        public DbSet<DbAlarm> Alarms { get; set; }
    
    }

    public class DbAlarm
    {
        [Key]
        public int Id { get; set; }
        public Alarm alarm { get; set; }
        public DateTime timeStamp { get; set; }

        public DbAlarm() { }

        public DbAlarm(Alarm alrm, DateTime dateTime)
        {
            alarm = alrm;
            timeStamp = dateTime;
        }
    }
}