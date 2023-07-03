using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Comment
    {
        public int comment_id { get; set; }

        public int student_id { get; set; }

        public int course_id { get; set; }

        public string comment_text { get; set; }

        public string title { get; set; }

        public string img { get; set; }

        public int course_rate { get; set; }

        public DateTime time { get; set; }
    }
}
