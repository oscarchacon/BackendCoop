using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Models
{
    [Table("DeathDate")]
    public class TaskWork: IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Column]
        public DateTime CreateDate { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public string Description { get; set; }
    }
}
