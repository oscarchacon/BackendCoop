using System;
using System.Collections.Generic;
using System.Text;
using Contracts.Models;

namespace Repository.Interfaces
{
    public interface IRepositoryModelsWrapper
    {
        ITaskWorkRepository TaskWork { get; }

        void Save();
    }
}
