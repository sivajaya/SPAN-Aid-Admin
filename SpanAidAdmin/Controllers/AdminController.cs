using SpanAidAdmin.Entity;
using SpanAidAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using Twilio;

namespace SpanAidAdmin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _HealingRadiusTicket()
        {
            using (SpanAidEntities spanaidEntity = new SpanAidEntities())
            {
                List<HealingRadius> listHealingRadius = new List<HealingRadius>();

                var dbHealingRadius = (from hr in spanaidEntity.HealingRadius_Ticket

                                       select new
                                       {
                                           hr.HR_Ticket_Id,
                                           hr.HR_Ticket_Number,
                                           hr.HR_User_Name,
                                           hr.HR_Email_Address,
                                           hr.HR_Module_Name,
                                           hr.HR_Ticket_Description,
                                           hr.HR_Ticket_Status,
                                           hr.HR_Priority,
                                           hr.HR_Ticket_Type,
                                           hr.HR_Ticket_Create_Date,
                                           hr.HR_Ticket_Update_Date

                                       }).ToList();

                if (dbHealingRadius.Any())
                {

                    foreach (var item in dbHealingRadius)
                    {
                        HealingRadius healingRadius = new HealingRadius();
                        healingRadius.HRTicketId = item.HR_Ticket_Id;
                        healingRadius.HRTicketNumber = item.HR_User_Name;
                        healingRadius.HRUserName = item.HR_User_Name;
                        healingRadius.HREmailAddress = item.HR_Email_Address;
                        healingRadius.HRTicketNumber = item.HR_Ticket_Number;
                        healingRadius.HRModuleName = item.HR_Module_Name;
                        healingRadius.HRTicketDescription = item.HR_Ticket_Description;
                        healingRadius.HRTicketStatus = item.HR_Ticket_Status;
                        healingRadius.HRPriority = item.HR_Priority;
                        healingRadius.HRTicketType = item.HR_Ticket_Type;
                        healingRadius.HRTicketCreateDate = item.HR_Ticket_Create_Date;
                        healingRadius.HRTicketUpdateDate = item.HR_Ticket_Update_Date;
                        listHealingRadius.Add(healingRadius);
                    }

                }
                return PartialView(listHealingRadius);
            }

        }

        [HttpGet]
        public ActionResult _TruckLogicTicket()
        {
            using (SpanAidEntities spanaidEntity = new SpanAidEntities())
            {
                List<TruckLogic> listTruckLogic = new List<TruckLogic>();

                var dbTruckLogic = (from tl in spanaidEntity.TruckLogics_Ticket
                                    where !tl.TL_Is_Deleted
                                    select new
                                    {
                                        tl
                                    }).ToList();

                if (dbTruckLogic.Any())
                {

                    foreach (var item in dbTruckLogic)
                    {
                        TruckLogic truckLogic = new TruckLogic();
                        truckLogic.TLTicketId = item.tl.TL_Ticket_Id;
                        truckLogic.TLTicketNumber = item.tl.TL_User_Name;
                        truckLogic.TLUserName = item.tl.TL_User_Name;
                        truckLogic.TlEmailAddress = item.tl.Tl_Email_Address;
                        truckLogic.TLTicketNumber = item.tl.TL_Ticket_Number;
                        truckLogic.TLModuleName = item.tl.TL_Module_Name;
                        truckLogic.TLTicketDescription = item.tl.TL_Ticket_Description;
                        truckLogic.TLTicketStatus = item.tl.TL_Ticket_Status;
                        truckLogic.TLPriority = item.tl.TL_Priority;
                        truckLogic.TLTicketType = item.tl.TL_Ticket_Type;
                        truckLogic.TLTicketCreateDate = item.tl.TL_Ticket_Create_Date;
                        truckLogic.TLTicketUpdateDate = item.tl.TL_Ticket_Update_Date;
                        listTruckLogic.Add(truckLogic);
                    }
                    return PartialView(listTruckLogic);
                }
            }

            return View();

        }

        [HttpPost]
        public bool UpdateTLTicketStausByTicketId(long Id, string Status)
        {
            bool isUpdated = false;
            if (Id > 0 && Status != null)
            {
                using (SpanAidEntities spanaidEntity = new SpanAidEntities())
                {
                    TruckLogics_Ticket dbTLTicketDetails = spanaidEntity.TruckLogics_Ticket.SingleOrDefault(a => a.TL_Ticket_Id == Id && !a.TL_Is_Deleted);
                    if (dbTLTicketDetails != null)
                    {
                        dbTLTicketDetails.TL_Ticket_Status = Status;
                        dbTLTicketDetails.Tl_Is_Email_Send = false;
                        dbTLTicketDetails.TL_Is_Text_Send = false;
                        dbTLTicketDetails.TL_Is_PushNotification = false;
                        dbTLTicketDetails.TL_Ticket_Update_Date = DateTime.Now;
                        spanaidEntity.SaveChanges();

                        //SmtpClient smtpClient = new SmtpClient();
                        //MailMessage mailmsg = new MailMessage();
                        //mailmsg = new MailMessage();
                        //mailmsg.IsBodyHtml = true;
                        //mailmsg.To.Add(dbTLTicketDetails.Tl_Email_Address);
                        //mailmsg.Bcc.Add("sivakumar.kumarasamy@w3magix.com");
                        //mailmsg.From = new MailAddress("jagadeesh.gnanasekaran@spanllc.com", "Jagadeesh G");
                        //mailmsg.Subject = "Updates from TruckLogics Ticket - " + dbTLTicketDetails.TL_Ticket_Number;
                        //mailmsg.Body =
                        //"Hi " + dbTLTicketDetails.TL_User_Name + ", <br/><br/> Your requst for TruckLogics regarding (" + dbTLTicketDetails.TL_Ticket_Description + ") is " + dbTLTicketDetails.TL_Ticket_Status.ToLower();
                        //smtpClient.Credentials = new NetworkCredential("vistaemails@gmail.com", "poiuyt15");
                        //smtpClient.EnableSsl = true;
                        //smtpClient.Port = 587;
                        //smtpClient.Host = "smtp.gmail.com";
                        //smtpClient.Send(mailmsg);
                        //var twilio = new TwilioRestClient("AC35cd510eb6a492f8cedc2eddd44729f6", "23986cd90f949fb4d3f6bebb967b40cf");
                        //var message = twilio.SendMessage("+1 415-599-2671", "+91" + "8015312240", dbTLTicketDetails.TL_Ticket_Number + " has been " + dbTLTicketDetails.TL_Ticket_Status);

                    }
                }
            }
            return isUpdated;
        }
        [HttpPost]
        public bool UpdateHRTicketStausByTicketId(long Id, string Status)
        {
            bool isDeleted = false;
            if (Id > 0 && Status != null)
            {
                using (SpanAidEntities spanaidEntity = new SpanAidEntities())
                {
                    HealingRadius_Ticket dbHRTicketDetails = spanaidEntity.HealingRadius_Ticket.SingleOrDefault(a => a.HR_Ticket_Id == Id && !a.HR_Is_Deleted);
                    if (dbHRTicketDetails != null)
                    {
                        dbHRTicketDetails.HR_Ticket_Status = Status;
                        dbHRTicketDetails.HR_Is_Email_Send = false;
                        dbHRTicketDetails.HR_Is_Text_Send = false;
                        dbHRTicketDetails.HR_Is_PushNotification = false;
                        dbHRTicketDetails.HR_Ticket_Update_Date = DateTime.Now;
                        spanaidEntity.SaveChanges();

                        //SmtpClient smtpClient = new SmtpClient();
                        //MailMessage mailmsg = new MailMessage();
                        //mailmsg = new MailMessage();
                        //mailmsg.IsBodyHtml = true;
                        //mailmsg.To.Add(dbHRTicketDetails.HR_Email_Address);
                        //mailmsg.Bcc.Add("sivakumar.kumarasamy@w3magix.com");
                        //mailmsg.From = new MailAddress("jagadeesh.gnanasekaran@spanllc.com", "Jagadeesh G");
                        //mailmsg.Subject = "Updates from Healing Radius Ticket - " + dbHRTicketDetails.HR_Ticket_Number;
                        //mailmsg.Body
                        // = "Hi " + dbHRTicketDetails.HR_User_Name + ", <br/><br/> Your requst for Healing radius regarding (" + dbHRTicketDetails.HR_Ticket_Description + ") is " + dbHRTicketDetails.HR_Ticket_Status.ToLower();
                        //smtpClient.Credentials = new NetworkCredential("vistaemails@gmail.com", "poiuyt15");
                        //smtpClient.EnableSsl = true;
                        //smtpClient.Port = 587;
                        //smtpClient.Host = "smtp.gmail.com";
                        //smtpClient.Send(mailmsg);
                        //var twilio = new TwilioRestClient("AC35cd510eb6a492f8cedc2eddd44729f6", "23986cd90f949fb4d3f6bebb967b40cf");
                        //var message = twilio.SendMessage("+1 415-599-2671", "+91" + "8015312240", dbHRTicketDetails.HR_Ticket_Number + " has been " + dbHRTicketDetails.HR_Ticket_Status);
                        isDeleted = true;
                    }
                }
            }
            return isDeleted;
        }

    }
}