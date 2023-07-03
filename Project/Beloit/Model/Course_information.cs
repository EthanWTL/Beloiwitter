using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Course_information
    {
        public string course_code { get; set; }

        public int department_id { get; set; }

        public string course_name { get; set; }

        public string course_introduction { get; set; }
    }
}
