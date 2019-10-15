using Contracts.Models;
using Entities;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Wrapper
{
    public class RepositoryModelsWrapper : IRepositoryModelsWrapper
    {
        private readonly RepositoryContext repository;

        ITaskWorkRepository taskWork;

        public RepositoryModelsWrapper(RepositoryContext repository)
        {
            this.repository = repository;
        }

        public ITaskWorkRepository TaskWork
        {
            get
            {
                if (this.taskWork == null)
                {
                    this.taskWork = new TaskWorkRepository(this.repository);
                }
                return this.taskWork;
            }
        }

        public void Save()
        {
            this.repository.SaveChanges();
        }
    }
}
