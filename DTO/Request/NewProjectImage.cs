using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request
{
    public class NewProjectImage
    {
        public int id { get; set; }
        public int ProjectID { get; set; }
        public string Link { get; set; }
    }
}
