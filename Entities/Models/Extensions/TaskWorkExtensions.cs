using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Extensions
{
    public static class TaskWorkExtensions
    {
        public static void Map(this TaskWork dbTaskWork, TaskWork taskWork)
        {
            dbTaskWork.Start = taskWork.Start;
            dbTaskWork.End = taskWork.End;
            dbTaskWork.Title = taskWork.Title;
            dbTaskWork.ContactEmail = taskWork.ContactEmail;
        }
    }
}
