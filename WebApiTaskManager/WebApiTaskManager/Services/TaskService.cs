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

        public async Task<Dictionary<string, string>> ChangeStatus(ChangeStatusModel requst)
        {
            return await _taskRepository.ChangeStatus(requst);
        }

        public async Task<Dictionary<string, string>> CreateTask(TaskModel request)
        {
            Domain.Models.Task taskForDB = new Domain.Models.Task
            {
                Name = request.Name,
                Description = request.Description,
                TimeEstimation = request.TimeEstimation,
                Status = "To Do",
                ProjectID = request.ProjectID
            };

            return await _taskRepository.CreateTask(taskForDB);
        }

        public async Task<GetTasksModel> getTasks(int projectID)
        {
            return await _taskRepository.getTasks(projectID);
        }

        public async Task<Dictionary<string, string>> TaskToMember(TaskToMemberModel requst)
        {
            return await _taskRepository.TaskToMember(requst);
        }
    }
}
