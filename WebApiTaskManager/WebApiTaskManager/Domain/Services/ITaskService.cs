using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTaskManager.Domain.Models;
using WebApiTaskManager.RequestModels;
using WebApiTaskManager.ResponseModels;

namespace WebApiTaskManager.Domain.Services
{
    public interface ITaskService
    {
        Task<Dictionary<string, string>> CreateTask(WebApiTaskManager.Domain.Models.Task task);

        Task<Dictionary<string, string>> TaskToMember(TaskToMemberModel model);

        Task<Dictionary<string, string>> ChangeStatus(ChangeStatusModel model);

        Task<GetTasksModel> getTasks(int projectID);
    }
}
