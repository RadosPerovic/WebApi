﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTaskManager.Domain.Models;
using WebApiTaskManager.HTTP.RequestModels;
using WebApiTaskManager.HTTP.ResponseModels;

namespace WebApiTaskManager.Domain.Services
{
    public interface ITaskService
    {
        Task<Dictionary<string, string>> CreateTask(TaskModel request);

        Task<Dictionary<string, string>> TaskToMember(TaskToMemberModel request);

        Task<Dictionary<string, string>> ChangeStatus(ChangeStatusModel request);

        Task<GetTasksModel> getTasks(int projectID);
    }
}
