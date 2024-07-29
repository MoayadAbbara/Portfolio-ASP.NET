using DataLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Services
    {
        public static List<DTO.Response.Services> getServicesList()
        {
            PortfolioContext model = new PortfolioContext();
            List<DTO.Response.Services> list = model.Services.Select(s => new DTO.Response.Services
            {
                ID = s.Id,
                Name = s.Title , 
                Description = s.Description , 
                IconClass = s.Icon,
            }).ToList();
            return list;
        }

        public static void AddService(DTO.Request.Services NewService)
        {
            PortfolioContext model = new PortfolioContext();
            DataLayer.Entities.Services Service = new DataLayer.Entities.Services();
            Service.Title = NewService.Name; 
            Service.Description = NewService.Description;
            Service.Icon = NewService.IconClass;
            model.Add(Service);
            model.SaveChanges();
        }


        public static void DeleteService(int id)
        {
            PortfolioContext model = new PortfolioContext();
            var myService = model.Services.FirstOrDefault(f => f.Id == id);
            model.Services.Remove(myService);
            model.SaveChanges();
        }
    }
}
