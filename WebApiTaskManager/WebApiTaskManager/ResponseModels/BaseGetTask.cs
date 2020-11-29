using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTaskManager.ResponseModels
{
    public class BaseGetTask
    {
        public string TaskName { get; set; }

        public string MemberName { get; set; }

        public string Status { get; set; }
    }
}
