﻿using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicatonProcess.May2020.Infrastructure.Models
{
    public abstract class BaseModel : IBaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}