using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicatonProcess.May2020.Domain.Models
{
    public interface IBaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}