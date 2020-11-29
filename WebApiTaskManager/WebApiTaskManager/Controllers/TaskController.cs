using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTaskManager.Domain.Models;
using WebApiTaskManager.Domain.Services;
using WebApiTaskManager.RequestModels;
using WebApiTaskManager.ResponseModels;

namespace WebApiTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("create/")]

        public async Task<IActionResult> createTask([FromBody]TaskModel request)
        {
            if(request == null)
            {
                return BadRequest("NULL");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            Domain.Models.Task taskForDB = new Domain.Models.Task
            {
                Name = request.Name,
                Description = request.Description,
                TimeEstimation = request.TimeEstimation,
                Status = "To Do",
                ProjectID = request.ProjectID
            };

            Dictionary<string, string> response = await _taskService.CreateTask(taskForDB);

            string errorMessage = "";

            if (response.TryGetValue("error", out errorMessage))
                return Ok(new { status = errorMessage });

            return Ok(new {Status = "Success", Task_ID = response["Inserted_ID"], Message = "Task is successfully created"});

            }

        [HttpPost("addToMember/")]

        public async Task<IActionResult> taskToMember([FromBody]TaskToMemberModel request)
        {

            if (request == null)
            {
                return BadRequest("NULL");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            Dictionary<string, string> response = await _taskService.TaskToMember(request);

            string errorMessage = "";

            if (response.TryGetValue("error", out errorMessage))
                return Ok(new { status = errorMessage });

            return Ok(new { Status = "Success", Task = response["Task"], Project = response["Project"], Member = response["Member"], Message = "Successfully added task to member"});

        }

        [HttpPost("changeStatus/")]

        public async Task<IActionResult> changeStatus([FromBody]ChangeStatusModel request)
        {

            string[] statuses = { "To Do", "In Progress", "In Testing", "Done", "Closed" };

            if (request == null)
            {
                return BadRequest("NULL");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            if(!statuses.Contains(request.Status))
            {
                return Ok(new { error = "Status string is not valid. You must entry some of this statuses : To Do, In Progress, In Testing, Done, Closed" });
            }

            Dictionary<string, string> response = await _taskService.ChangeStatus(request);

            string errorMessage = "";

            if (response.TryGetValue("error", out errorMessage))
                return Ok(new { status = errorMessage });

            return Ok(new { Status = "Success", Message = response["Message"]});

        }

        [HttpGet("get/{projectID}")]

        public async Task<IActionResult> getTasks(int projectID)
        {
            if (projectID == null)
            {
                return BadRequest("NULL");
            }

            GetTasksModel response = await _taskService.getTasks(projectID);

            if(response.listOfTasks.Count == 0)
            {
                return Ok( new { errorMessage = "This project don't have tasks!" });
            }


            return Ok(new { Status = "Success", NumberOfTasks = response.listOfTasks.Count , Project = response.ProjectName, Tasks = response.listOfTasks}) ;
        }

    }
}