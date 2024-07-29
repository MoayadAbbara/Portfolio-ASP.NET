using DataLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Projects
    {
        public static List<DTO.Response.ProjectTypes> getProjectCategories()
        {
            PortfolioContext model = new PortfolioContext();
            List <DTO.Response.ProjectTypes> TypesList = model.ProjectTypes.Select(s=> new DTO.Response.ProjectTypes
            {
                id = s.Id,
                Type = s.Title,

            }).ToList();
            return TypesList;
        }

        public static List<String> getImages(int ProjectID)
        {
            PortfolioContext model = new PortfolioContext();
            List<String> ImagesLink = model.ProjectPhotos.Where(q=>q.ProjectId == ProjectID).Select(s=>new string(s.PhotoUrl)).ToList();
            return ImagesLink;
        }

        public static List<DTO.Response.Projects> getProjectList()
        {
            PortfolioContext model = new PortfolioContext();
            List<DTO.Response.Projects> ProjectList = model.Projects.Select(s => new DTO.Response.Projects
            {
                id = s.Id,
                Title = s.Title,
                Type = s.Type.Title,
                Link = s.Link,
                ProjectDate = s.ProjectDate.Value,
                Description = s.Description,
                Images = getImages(s.Id),
            }).ToList();
            return ProjectList;
        }


        public static void AddProject(DTO.Request.Projects NewProject)
        {
            PortfolioContext model = new PortfolioContext();
            DataLayer.Entities.Projects project = new DataLayer.Entities.Projects();
            project.Title = NewProject.Title;
            project.TypeId = NewProject.Type;
            project.Link = NewProject.Link;
            project.ProjectDate = NewProject.ProjectDate;
            project.Description = NewProject.Description;
            model.Add(project);
            model.SaveChanges();
        }


        public static void DeleteProject(int id)
        {
            PortfolioContext model = new PortfolioContext();
            var MyProject = model.Projects.FirstOrDefault(f => f.Id == id);
            var ProjectImages = model.ProjectPhotos.Where(f => f.ProjectId == id).ToList();
            foreach ( var image in ProjectImages )
            {
                model.ProjectPhotos.Remove(image);
            }
            model.Projects.Remove(MyProject);
            model.SaveChanges();
        }


        public static DTO.Response.Projects GetProjectById(int id)
        {
            PortfolioContext model = new PortfolioContext();
            DTO.Response.Projects Project = model.Projects.Where(q=>q.Id == id).Select(s => new DTO.Response.Projects
            {
                id = s.Id,
                Title = s.Title,
                Type = s.Type.Title,
                TypeID = s.Type.Id,
                Link = s.Link,
                ProjectDate = s.ProjectDate.Value,
                Description = s.Description,
                Images = getImages(s.Id),
            }).FirstOrDefault();
            return Project;
        }


        public static void EditProject(DTO.Request.Projects EditedProject)
        {
            PortfolioContext model = new PortfolioContext();
            var project = model.Projects.FirstOrDefault(f => f.Id == EditedProject.id);
            project.Title = EditedProject.Title;
            project.TypeId = EditedProject.Type;
            project.Link = EditedProject.Link;
            project.ProjectDate = EditedProject.ProjectDate;
            project.Description = EditedProject.Description;
            model.SaveChanges();
        }


        public static void AddNewImage(DTO.Request.NewProjectImage image)
        {
            PortfolioContext model = new PortfolioContext();
            DataLayer.Entities.ProjectPhotos newimage = new DataLayer.Entities.ProjectPhotos();
            newimage.PhotoUrl = image.Link;
            newimage.ProjectId = image.ProjectID;
            model.ProjectPhotos.Add(newimage);
            model.SaveChanges();
        }
    }
}
