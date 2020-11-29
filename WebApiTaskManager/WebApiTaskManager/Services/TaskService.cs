using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTaskManager.Domain.Repositories;
using WebApiTaskManager.Domain.Services;
using WebApiTaskManager.HTTP.RequestModels;
using WebApiTaskManager.HTTP.ResponseModels;

namespace WebApiTaskManager.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Dictionary<string, string>> ChangeStatus(ChangeStatusModel model)
        {
            return await _taskRepository.ChangeStatus(model);
        }

        public async Task<Dictionary<string, string>> CreateTask(WebApiTaskManager.Domain.Models.Task task)
        {
            return await _taskRepository.CreateTask(task);
        }

        public async Task<GetTasksModel> getTasks(int projectID)
        {
            return await _taskRepository.getTasks(projectID);
        }

        public async Task<Dictionary<string, string>> TaskToMember(TaskToMemberModel model)
        {
            return await _taskRepository.TaskToMember(model);
        }
    }
}
