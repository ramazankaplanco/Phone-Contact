﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PhoneContact.Entities
{
    public class UserLogin : IdentityUserLogin<int>
    {
        public override string LoginProvider { get; set; }

        public override string ProviderKey { get; set; }

        public override int UserId { get; set; }

        [MaxLength(4096)]
        public string Note { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}