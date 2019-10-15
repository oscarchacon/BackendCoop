using Contracts.Models;
using Entities;
using Entities.Models;
using Entities.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Models
{
    public class TaskWorkRepository : RepositoryBase<TaskWork>, ITaskWorkRepository
    {
        public TaskWorkRepository(RepositoryContext repository) : base(repository) { }

        public void CreateTask(TaskWork taskWork)
        {
            taskWork.Id = new Guid();
            this.Create(taskWork);
        }

        public void DeleteTask(TaskWork taskWork)
        {
            this.Delete(taskWork);
        }

        public IEnumerable<TaskWork> GetAllTasks()
        {
            var taskWorksFind = this.FindAll();

            taskWorksFind = taskWorksFind.OrderBy(taskWork => taskWork.Start);

            return taskWorksFind.ToList();
        }

        public TaskWork GetTaskById(Guid Id)
        {
            var taskWorkFind = this.FindByCondition(taskWork => taskWork.Id.Equals(Id))
                                    .DefaultIfEmpty(new TaskWork())
                                    .FirstOrDefault();
            return taskWorkFind;
        }

        public void UpdateTask(TaskWork dbTaskWork, TaskWork taskWork)
        {
            dbTaskWork.Map(taskWork);
            this.Update(dbTaskWork);
        }
    }
}
