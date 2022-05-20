using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs.Log
{
    public class LogDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public object UserEmail { get; set; }
        public object LoginTime { get; set; }
    }
}