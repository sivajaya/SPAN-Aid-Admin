using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpanAidAdmin.Models
{
    public class HealingRadius
    {
        public long HRTicketId { get; set; }
        public string HRTicketNumber { get; set; }
        public string HRUserName { get; set; }
        public string HREmailAddress { get; set; }
        public string HRModuleName { get; set; }
        public string HRTicketDescription { get; set; }
        public string HRTicketStatus { get; set; }
        public bool HRIsPushNotification { get; set; }
        public bool HRIsEmailSend { get; set; }
        public bool HRIsTextSend { get; set; }
        public string HRPriority { get; set; }
        public byte[] HRAttachment { get; set; }
        public string HRPhoneNumber { get; set; }
        public string HRTicketType { get; set; }
        public bool HRIsDeleted { get; set; }
        public System.DateTime HRTicketCreateDate { get; set; }
        public System.DateTime HRTicketUpdateDate { get; set; }
    }
}