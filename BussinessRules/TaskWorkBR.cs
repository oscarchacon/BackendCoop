using Entities.Models;
using Entities.Utils;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRules
{
    public class TaskWorkBR
    {
        private readonly IRepositoryModelsWrapper repository;
        public TaskWorkBR(IRepositoryModelsWrapper repository)
        {
            this.repository = repository;
        }


        public IEnumerable<TaskWork> GetAllTasks()
        {
            try
            {
                var taskWorksFind = this.repository.TaskWork.GetAllTasks();
                return taskWorksFind;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public TaskWork GetTaskById (Guid Id)
        {
            try
            {
                var taskWorkFind = this.repository.TaskWork.GetTaskById(Id);
                return taskWorkFind;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void CreateTask(TaskWork taskWorkNew)
        {
            try
            {
                this.repository.TaskWork.CreateTask(taskWorkNew);
                this.repository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public bool UdpdateTask(Guid taskId, TaskWork taskWorkUpdated)
        {
            try
            {
                var dbTaskWork = this.repository.TaskWork.GetTaskById(taskId);
                if (dbTaskWork.IsEmptyObject() || dbTaskWork.IsObjectNull()) { return false; }

                this.repository.TaskWork.UpdateTask(dbTaskWork, taskWorkUpdated);
                this.repository.Save();

                taskWorkUpdated.Id = taskId;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public bool DeleteTask(Guid taskId)
        {
            try
            {
                var dbTaskWork = this.repository.TaskWork.GetTaskById(taskId);
                if (dbTaskWork.IsEmptyObject()) { return false; }


                this.repository.TaskWork.DeleteTask(dbTaskWork);
                this.repository.Save();

                return true;
            }
            catch (ArgumentNullException anex)
            {
                throw new Exception(anex.Message, anex.InnerException);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }

    
}
