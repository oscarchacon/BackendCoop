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


        public IEnumerable<TaskWork> GetAllDates(int? year = null, int? month = null)
        {
            try
            {
                var deathDatesFind = this.repository.DeathDate.GetAllDates(year, month);
                return deathDatesFind;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public TaskWork GetDateById (Guid Id)
        {
            try
            {
                var deathDateFind = this.repository.DeathDate.GetDateById(Id);
                return deathDateFind;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public bool CreateDate(TaskWork deathDateNew)
        {
            try
            {
                var deathDatesFind = this.repository.DeathDate.GetAllDateBetween(deathDateNew.Start, deathDateNew.End);
                if (deathDatesFind != null)
                {
                    if (deathDatesFind.Count() > 0) { return false; }
                }

                this.repository.DeathDate.CreateDate(deathDateNew);
                this.repository.Save();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public bool UdpdateDate(Guid dateId, TaskWork deathDateUpdated)
        {
            try
            {
                var dbDeathDate = this.repository.DeathDate.GetDateById(dateId);
                if (dbDeathDate.IsEmptyObject() || dbDeathDate.IsObjectNull()) { return false; }

                this.repository.DeathDate.UpdateDate(dbDeathDate, deathDateUpdated);
                this.repository.Save();

                deathDateUpdated.Id = dateId;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public bool DeleteDate(Guid dateId)
        {
            try
            {
                var dbDeathDate = this.repository.DeathDate.GetDateById(dateId);
                if (dbDeathDate.IsEmptyObject()) { return false; }


                this.repository.DeathDate.DeleteDate(dbDeathDate);
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
