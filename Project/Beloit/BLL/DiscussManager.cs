using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DiscussManager
    {
        //execute save process
        public static bool saveDiscuss(Discuss discussInfo)
        {
            return DiscussService.saveDiscuss(discussInfo);
        }

        //get discuss list
        public static List<Discuss> getDiscussList(int commentId)
        {
            return DiscussService.getDiscussList(commentId);
        }
    }
}
