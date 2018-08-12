using FluentValidation.Validators;
using IR.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Command.CustomValidators
{
    public class CpfValidator : PropertyValidator
    {
        public CpfValidator() : base("{PropertyName} não é um Cpf válido.")
        {

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return CpfCnpjUtils.IsCpf(context.PropertyValue.ToString());
        }
    }
}
