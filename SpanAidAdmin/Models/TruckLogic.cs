using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpanAidAdmin.Models
{
    public class TruckLogic
    {
        public long TLTicketId { get; set; }
        public string TLTicketNumber { get; set; }
        public string TLUserName { get; set; }
        public string TlEmailAddress { get; set; }
        public string TLModuleName { get; set; }
        public string TLTicketDescription { get; set; }
        public string TLTicketStatus { get; set; }
        public bool TLIsPushNotification { get; set; }
        public bool TlIsEmailSend { get; set; }
        public bool TLIsTextSend { get; set; }
        public string TLPriority { get; set; }
        public byte[] TLAttachment { get; set; }
        public string TLPhoneNumber { get; set; }
        public string TLTicketType { get; set; }
        public bool TLIsDeleted { get; set; }
        public System.DateTime TLTicketCreateDate { get; set; }
        public System.DateTime TLTicketUpdateDate { get; set; }
    }
}