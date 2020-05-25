using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicatonProcess.May2020.Data.Entities
{
    public abstract class BaseEntity : AuditableEntity, IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}