using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response
{
    public class Projects
    {
        public int id { get; set; }
        public string Title { get; set; }
        public String Type { get; set; }
        public int TypeID { get; set; }
        public String Link { get; set; }
        public DateTime ProjectDate { get; set; }
        public String Description { get; set; }
        public List<String>? Images { get; set; }
    }

    public class ProjectTypes
    {
        public int id { get; set; }
        public String Type { get; set; }
    }
}
