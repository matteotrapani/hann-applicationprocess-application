using System;

namespace Hahn.ApplicatonProcess.May2020.Data.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
