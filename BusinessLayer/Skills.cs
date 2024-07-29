using DataLayer.Contexts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Skills
    {
        public static List<DTO.Response.Skills> getSkillsList()
        {
            PortfolioContext model = new PortfolioContext();
            List<DTO.Response.Skills> list = model.Skills.Select(s => new DTO.Response.Skills
            {
                ID = s.Id,
                Name = s.Skill , 
                Ratio = s.Ratio.Value,
            }).ToList();
            return list;
        }

        public static void AddSkill(DTO.Request.Skills Newskill)
        {
            PortfolioContext model = new PortfolioContext();
            DataLayer.Entities.Skills skill = new DataLayer.Entities.Skills();
            skill.Skill = Newskill.Name;
            skill.Ratio = Newskill.Ratio;
            model.Add(skill);
            model.SaveChanges();
        }


        public static void EditSkill(DTO.Request.Skills skill)
        {
            PortfolioContext model = new PortfolioContext();
            var Skill = model.Skills.FirstOrDefault(f => f.Id == skill.ID);
            Skill.Skill = skill.Name;
            Skill.Ratio = skill.Ratio;
            model.SaveChanges();
        }

        public static void DeleteSkill(int id)
        {
            PortfolioContext model = new PortfolioContext();
            var mySkill = model.Skills.FirstOrDefault(f => f.Id == id);
            model.Skills.Remove(mySkill);
            model.SaveChanges();
        }

        public static DTO.Response.Skills GetSkillById(int id)
        {
            PortfolioContext model = new PortfolioContext();
            DTO.Response.Skills skill = model.Skills.Where(q=>q.Id == id).Select(s => new DTO.Response.Skills
            {
                ID = s.Id,
                Name = s.Skill,
                Ratio = s.Ratio.Value,
            }).FirstOrDefault();
            return skill;
        }
    }
}
