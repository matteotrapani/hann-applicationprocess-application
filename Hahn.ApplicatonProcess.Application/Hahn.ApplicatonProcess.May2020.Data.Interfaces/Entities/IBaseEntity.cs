using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicatonProcess.May2020.Data.Entities
{
    // This interface could be useful whenever we add other CRUD entities to the app and we want to create a generic infrastructure
    public interface IBaseEntity : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
    }
}