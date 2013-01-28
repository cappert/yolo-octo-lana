using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project30.Models
{

    public class MessageContext : DbContext
    {
        public MessageContext() : base("DefaultConnection")
        {
        }

        public DbSet<Message> Messages { get; set; }

    }


    [Table("Message")]
    public class Message
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
    }
}