﻿using System;

namespace Hahn.ApplicatonProcess.May2020.Data.Entities
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}