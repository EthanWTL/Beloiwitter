using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Student
    {
        //user id
        public int student_id { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string class_taken { get; set; }

        public string nick_name { get; set; }

        public string user_avatar { get; set; }

        public int state { get; set; }

        public string introduce { get; set; }

        public DateTime create_time { get; set; }


    }
}
