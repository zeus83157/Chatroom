﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Chatroom.Repositories.Models.EFCoreRepositories.ORM
{
    public partial class Role
    {
        public Role()
        {
            UsersWithRole = new HashSet<UsersWithRole>();
        }

        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public DateTimeOffset CreateDatetime { get; set; }
        public DateTimeOffset UpdatedDatetime { get; set; }

        public virtual ICollection<UsersWithRole> UsersWithRole { get; set; }
    }
}