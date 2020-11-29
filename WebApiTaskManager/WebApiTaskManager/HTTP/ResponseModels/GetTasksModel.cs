using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTaskManager.HTTP.ResponseModels
{
    public class GetTasksModel
    {
        public string ProjectName { get; set; }

        public List<BaseGetTask> listOfTasks = new List<BaseGetTask>();

       
    }
}
