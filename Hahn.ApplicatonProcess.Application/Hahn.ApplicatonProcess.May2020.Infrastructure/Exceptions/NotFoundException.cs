using System;

namespace Hahn.ApplicatonProcess.May2020.Infrastructure.Exceptions
{
    [Serializable]
    public class NotFoundException : System.Exception
    {
        public NotFoundException(Type type, object id) : base(
            $"The element of type '{type.Name}' with  '{nameof(id)}={id}' was not found")
        { }
        public NotFoundException(string message) : base(message)
        { }
    }
}