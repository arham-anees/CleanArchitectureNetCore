using System;

namespace CleanArhitectureNetCore.Common.Exceptions
{
    public class InsertFailException : Exception
    {
        public InsertFailException() : base("Insert in database failed.") { }
    }
}
