using DataLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Experience
    {
        public static List<String> getDetails(int ExperinceID)
        {
            PortfolioContext model = new PortfolioContext();
            List<String> details = model.ExperienceDetails.Where(w=>w.ExperienceId == ExperinceID).Select(s=>new String(s.Details)).ToList();
            return details;
        }

        public static List<DTO.Response.Experience> getExperienceList()
        {
            PortfolioContext model = new PortfolioContext();
            List<DTO.Response.Experience> list = model.Experience.Select(s => new DTO.Response.Experience
            {
                ID = s.Id,
                Title = s.JobTitle,
                Company = s.CompanyName,
                StartYear = s.StartYear.Value,
                EndYear = s.EndYear.Value,
                Location = s.Location,
                Details = getDetails(s.Id)
            }).ToList();
            return list;
        }


        public static void AddExperince(DTO.Request.Experience NewExperince)
        {
            PortfolioContext model = new PortfolioContext();
            DataLayer.Entities.Experience experince = new DataLayer.Entities.Experience();
            experince.JobTitle = NewExperince.Title;
            experince.CompanyName = NewExperince.Company;
            experince.StartYear = NewExperince.StartYear;
            experince.EndYear = NewExperince.EndYear;
            experince.Location = NewExperince.Location;
            model.Add(experince);
            model.SaveChanges();
        }


        public static void DeleteExperince(int id)
        {
            PortfolioContext model = new PortfolioContext();
            var myExperince = model.Experience.FirstOrDefault(f => f.Id == id);
            model.Experience.Remove(myExperince);
            model.SaveChanges();
        }
    }
}
