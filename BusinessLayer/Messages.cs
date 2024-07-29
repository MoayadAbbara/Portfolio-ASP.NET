using DataLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Messages
    {
        public static void SendMessage(DTO.Request.Message message)
        {
            PortfolioContext model = new PortfolioContext();
            DataLayer.Entities.Messages msg = new DataLayer.Entities.Messages();
            msg.Id = message.Id;
            msg.Name = message.Name;
            msg.Email = message.Email;
            msg.Subject = message.Subject;
            msg.Message = message.MessageText;
            model.Messages.Add(msg);
            model.SaveChanges();
        }

        public static List<DTO.Response.Message> getgetMessagesList()
        {
            PortfolioContext model = new PortfolioContext();
            List<DTO.Response.Message> List = model.Messages.Select(q => new DTO.Response.Message
            {
                Id = q.Id,
                Name = q.Name,
                Email = q.Email,
                MessageText = q.Message,
                Subject = q.Subject,
            }).ToList();
            return(List);
        }
    }
}
