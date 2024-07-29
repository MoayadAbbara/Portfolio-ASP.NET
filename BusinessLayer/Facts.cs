using DataLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class Facts
    {
        public static List<DTO.Response.Facts> getFactsList() { 
            PortfolioContext model = new PortfolioContext();
            List<DTO.Response.Facts> list = model.Facts.Select(s => new DTO.Response.Facts { 
                ID = s.Id, 
                Num = s.Numbers.Value,
                Fact = s.Fact,
                IconClassName = s.IconClass
            }).ToList();
            return list;
        }

        public static void AddFact(DTO.Request.Facts NewFact)
        {
            PortfolioContext model = new PortfolioContext();
            DataLayer.Entities.Facts fact = new DataLayer.Entities.Facts();
            fact.Fact = NewFact.Fact;
            fact.Numbers = NewFact.Num;
            fact.IconClass = NewFact.IconClassName;
            model.Add(fact);
            model.SaveChanges();
        }


        public static void DeleteFact(int id)
        {
            PortfolioContext model = new PortfolioContext();
            var myFact = model.Facts.FirstOrDefault(f => f.Id == id);
            model.Facts.Remove(myFact);
            model.SaveChanges();
        }


        public static DTO.Response.Facts GetFactById(int id)
        {
            PortfolioContext model = new PortfolioContext();
            DTO.Response.Facts fact = model.Facts.Where(q => q.Id == id).Select(s => new DTO.Response.Facts
            {
                ID = s.Id,
                Fact = s.Fact,
                Num = s.Numbers.Value,
                IconClassName = s.IconClass,
            }).FirstOrDefault();
            return fact;
        }

        public static void EditFact(DTO.Request.Facts Fact)
        {
            PortfolioContext model = new PortfolioContext();
            var MyFact = model.Facts.FirstOrDefault(f => f.Id == Fact.Id);
            MyFact.Fact = Fact.Fact;
            MyFact.IconClass = Fact.IconClassName;
            MyFact.Numbers = Fact.Num;
            model.SaveChanges();
        }
    }
}
