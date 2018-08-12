using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Command
{
    public abstract class Command : IRequest
    {
        public ValidationResult ValidationResult { get; set; }

        protected Command() { }

        public abstract bool IsValid();
    }
}
