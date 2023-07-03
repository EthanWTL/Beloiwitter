using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Course
    {
        public int course_id { get; set; }

        public string course_code { get; set; }

        public int professor_id { get; set; }

        public DateTime time_offered { get; set; }

        public int average_rate { get; set; }
    }
}
