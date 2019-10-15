using Contracts.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Models
{
    public interface ITaskWorkRepository : IRepositoryBase<TaskWork>
    {
        IEnumerable<TaskWork> GetAllTasks();

        TaskWork GetTaskById(Guid Id);

        void CreateTask(TaskWork deathDate);

        void UpdateTask(TaskWork dbTaskWork, TaskWork taskWork);

        void DeleteTask(TaskWork deathDate);
    }
}
