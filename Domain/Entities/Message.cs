using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Message:BaseEntity
    {
        public string SenderEmail { get; set; } = default!;
        public User? Sender { get; set; }
        public string RecieverEmail { get; set; } = default!;
        public User? Reciever { get; set; }
        public string Context {  get; set; } = default!;
        public Message(string context, string senderEmail, string recieverEmail,string createdBy)
        {
            SenderEmail = senderEmail;
            RecieverEmail = recieverEmail;
            Context = context;
            CreatedBy = createdBy;
        }
        public void Update(string context, string senderEmail, string recieverEmail,  string updatedBy, bool isDeleted)
        {
            Context = context;
            SenderEmail= senderEmail;
            RecieverEmail = recieverEmail;
            IsDeleted = isDeleted;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
