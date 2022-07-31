﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Chatroom.Repositories.Models.EFCoreRepositories.ORM
{
    public partial class User
    {
        public User()
        {
            UsersWithRole = new HashSet<UsersWithRole>();
        }

        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTimeOffset CreateDatetime { get; set; }
        public DateTimeOffset UpdatedDatetime { get; set; }
        public bool Gender { get; set; }
        public int StarSignID { get; set; }

        public virtual ICollection<UsersWithRole> UsersWithRole { get; set; }
    }
}