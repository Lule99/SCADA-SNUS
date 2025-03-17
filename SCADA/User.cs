using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCADA
{
    public class User
    {


        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(25)]
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public bool isAdmin { get; set; }
        public User() { }
        public User(string username, string encryptedPassword, bool admin)
        {
            Username = username;
            EncryptedPassword = encryptedPassword;
            isAdmin = admin;
        }
    }
}