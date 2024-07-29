using DataLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Education
    {
        public static List<DTO.Response.Education> getEducationList()
        {
            PortfolioContext model = new PortfolioContext();
            List<DTO.Response.Education> list = model.Education.Select(s => new DTO.Response.Education
            {
                ID = s.Id,
                Degree = s.Title , 
                StartYear = s.StartYear.Value,
                EndYear = s.EndYear.Value,
                School = s.Institution,
                Description = s.Description
            }).ToList();
            return list;
        }

        public static void AddEducation(DTO.Request.Education NewEducation)
        {
            PortfolioContext model = new PortfolioContext();
            DataLayer.Entities.Education education= new DataLayer.Entities.Education();
            education.Title = NewEducation.Degree;
            education.StartYear = NewEducation.StartYear;
            education.EndYear = NewEducation.EndYear;
            education.Institution = NewEducation.School;
            education.Description = NewEducation.Description;
            model.Add(education);
            model.SaveChanges();
        }


        public static void DeleteEducation(int id)
        {
            PortfolioContext model = new PortfolioContext();
            var myEducation = model.Education.FirstOrDefault(f => f.Id == id);
            model.Education.Remove(myEducation);
            model.SaveChanges();
        }
    }
}
