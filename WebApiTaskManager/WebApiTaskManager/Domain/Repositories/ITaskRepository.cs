﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTaskManager.HTTP.RequestModels;
using WebApiTaskManager.HTTP.ResponseModels;

namespace WebApiTaskManager.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<Dictionary<string, string>> CreateTask(WebApiTaskManager.Domain.Models.Task task);

        Task<Dictionary<string, string>> TaskToMember(TaskToMemberModel model);

        Task<Dictionary<string, string>> ChangeStatus(ChangeStatusModel model);

        Task<GetTasksModel> getTasks(int projectID);
    }
}
