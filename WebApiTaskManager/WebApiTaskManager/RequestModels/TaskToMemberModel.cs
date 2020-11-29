using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTaskManager.RequestModels
{
    public class TaskToMemberModel
    {
        public int TaskID { get; set; }
        public int MemberID { get; set; }
    }
}
