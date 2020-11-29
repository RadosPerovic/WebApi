using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTaskManager.Domain.Models;
using WebApiTaskManager.Data.Context;
using WebApiTaskManager.Domain.Repositories;
using WebApiTaskManager.HTTP.RequestModels;
using WebApiTaskManager.HTTP.ResponseModels;

namespace WebApiTaskManager.Data.Repositories
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public TaskRepository(AppDbContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public async Task<Dictionary<string, string>> ChangeStatus(ChangeStatusModel model)
        {
            

            Dictionary<string, string> response = new Dictionary<string, string>();

            string first = "";
            string second = "";

            Domain.Models.Task task = await _dataBaseContext.Tasks.Where(t => t.ID == model.TaskID).FirstOrDefaultAsync();

            string oldStatus = task.Status;

            string[] statuses = { "To Do", "In Progress", "In Testing", "Done", "Closed" };

            int index = Array.IndexOf(statuses, oldStatus);

            if(index == 4)
            {
                response.Add("error", "Ilegal status. This task is Closed!");
                return response;
            }

            first = statuses[index + 1].ToString();
            second = statuses[4].ToString();

            string[] legalStatus = {first, second};

            if(!legalStatus.Contains(model.Status))
            {
                if(legalStatus[0] == legalStatus[1])
                {
                    response.Add("error", "Ilegal status. Must be " + legalStatus[0]);
                }
                response.Add("error", "Ilegal status. Must be " + legalStatus[0] + " or " + legalStatus[1]);
                return response;
            }

            task.Status = model.Status;

            try
            {
                await _dataBaseContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                response.Add("error", ex.InnerException.Message);
                return response;
            }

            response.Add("Message", "Successfull status change from " + oldStatus + " to " + task.Status);

            return response;


        }

        public async Task<Dictionary<string, string>> CreateTask(Domain.Models.Task task)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();
            Project project = await _dataBaseContext.Projects.Where(p => p.ID == task.ProjectID).FirstOrDefaultAsync();

            if(project==null)
            {
                response.Add("error","Project with ID = " + task.ProjectID + " doesn't exist");
                return response;
            }

            await _dataBaseContext.Tasks.AddAsync(task);

            try
            {
               await _dataBaseContext.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                response.Add("error", ex.InnerException.Message);
                return response;
            }
            response.Add("Inserted_ID", task.ID.ToString());

            return response;
        }

        public async Task<GetTasksModel> getTasks(int projectID)
        {
  
            List<Domain.Models.Task> tasks = await _dataBaseContext.Tasks.Include(t => t.Member).Include(t => t.Project).Where(t => t.ProjectID == projectID).ToListAsync();

            GetTasksModel response = new GetTasksModel();

            if (tasks.Count() == 0)
            {
                return response;
            }

            string projectName = tasks.Select(t=>t.Project.Name).First().ToString();

            response.ProjectName = projectName;

            foreach (var task in tasks)
            {
                string memberName = "";

                if(task.MemberID != null)
                {
                     memberName = task.Member.Name;
                }

                BaseGetTask t = new BaseGetTask()
                {
                    TaskName = task.Name,
                    MemberName = memberName,
                    Status = task.Status,
                };

                response.listOfTasks.Add(t);
            }

            return response;

        }

        public async Task<Dictionary<string, string>> TaskToMember(TaskToMemberModel model)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();

            Member member = await _dataBaseContext.Members.Where(m => m.ID == model.MemberID).FirstOrDefaultAsync();

            Domain.Models.Task task = await _dataBaseContext.Tasks.Include(t => t.Project.Members).Where(t=>t.ID == model.TaskID).FirstOrDefaultAsync();

            if (task == null)
            {
                response.Add("error" , "Task don't exists!");
                return response;
            }
            if (task.Project.Members.Contains(member))
            {

                task.MemberID = model.MemberID;

                try
                {
                    await _dataBaseContext.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    response.Add("error", ex.InnerException.Message);
                    return response;
                }

            }
            else
            {
                response.Add("error", "Member is not on the same project as Task");
                return response;
            }

            response.Add("Task", task.Name);
            response.Add("Project", task.Project.Name);
            response.Add("Member", task.Member.Name);

            return response;
        }






    }
}

