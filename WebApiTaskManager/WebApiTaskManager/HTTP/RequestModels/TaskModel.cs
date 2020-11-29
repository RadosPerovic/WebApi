using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTaskManager.HTTP.RequestModels
{
    public class TaskModel
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string TimeEstimation { get; set; } = "";
        public int ProjectID { get; set; } = 0;

    }
}
