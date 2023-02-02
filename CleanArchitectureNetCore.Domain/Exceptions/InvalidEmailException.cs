using System;

namespace CleanArchitectureNetCore.Domain.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base("Invalid Username") { }
        public InvalidEmailException(string message) : base(message) { }
    }
}
