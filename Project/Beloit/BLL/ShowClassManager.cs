using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ShowClassManager
    {
        public static List<ShowClass> getClassList(int student_id)
        {
            return ShowClassService.getClassList(student_id);
        }
    }
}
