using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Message
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email {  get; set; }
        public string Subject {  get; set; }
        public string MessageText { get; set; }
        public DateTime SendedAt { get; set; }
    }
}
