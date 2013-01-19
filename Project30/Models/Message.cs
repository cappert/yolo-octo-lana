using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project30.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public String Title {get; set;}
        public string Content { get; set; }
        public string Type { get; set; }
    }
}