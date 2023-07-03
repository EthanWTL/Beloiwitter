using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class ShowComment
    {
        public int comment_id { get; set; }

        public string title { get; set; }

        public DateTime time { get; set; }

        public string img { get; set; }

        public string nick_name { get; set; }

        public string user_avatar { get; set; }

        public string time_offered { get; set; }

        public string professor_name { get; set; }

        public string course_code { get; set; }

        public string department_name { get; set; }

    }
}
