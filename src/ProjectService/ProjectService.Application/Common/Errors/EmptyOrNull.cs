using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectService.Application.Common.Errors;

public class EmptyOrNullException : Exception
{
    public EmptyOrNullException(string name) : base($"Entity \"{name}\"was null or empty.") { }
}