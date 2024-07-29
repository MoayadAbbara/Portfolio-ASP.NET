using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request
{
    public class Experience
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public String Company { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public String Location { get; set; }
    }
}
