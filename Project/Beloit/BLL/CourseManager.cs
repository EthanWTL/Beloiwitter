using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CourseManager
    {
        public static List<Course> getCourseList(int userId)
        {
            return CourseService.getCourseList(userId);
        }
    }
}
