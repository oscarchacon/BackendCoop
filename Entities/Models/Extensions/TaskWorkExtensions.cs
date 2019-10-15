using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Extensions
{
    public static class TaskWorkExtensions
    {
        public static void Map(this TaskWork dbTaskWork, TaskWork taskWork)
        {
            dbTaskWork.Title = taskWork.Title;
            dbTaskWork.Description = taskWork.Description;
        }
    }
}
