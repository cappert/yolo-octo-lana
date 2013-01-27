using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Project30.Models
{
    public class MessageContext : DbContext
    {
        public MessageContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Message> Messages { get; set; }

    }
}