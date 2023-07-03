using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Discuss
    {
        public int discuss_id { get; set; }

        public string discuss { get; set; }

        public int student_id { get; set; }

        public string nick_name { get; set; }

        public string user_avatar { get; set; }

        public DateTime time { get; set; }

        public int comment_id { get; set; }
    }
}
